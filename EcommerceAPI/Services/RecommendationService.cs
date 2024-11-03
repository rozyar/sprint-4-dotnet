using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;
        private readonly EcommerceContext _dbContext;

        public RecommendationService(EcommerceContext dbContext)
        {
            _mlContext = new MLContext();
            _dbContext = dbContext;
        }

        private async Task TrainModelAsync()
        {
            // Verificar se existem dados de avaliações
            var ratings = await _dbContext.Ratings.Select(r => new ProductRating
            {
                UserId = (uint)r.UserId, // Convertendo para uint
                ProductId = (uint)r.ProductId, // Convertendo para uint
                Label = r.RatingValue
            }).ToListAsync();

            if (!ratings.Any())
            {
                // Caso não haja dados, lança uma exceção
                throw new InvalidOperationException("Não há dados de avaliações disponíveis para treinar o modelo.");
            }

            var dataView = _mlContext.Data.LoadFromEnumerable(ratings);

            // Definir o pipeline
            var options = new MatrixFactorizationTrainer.Options
            {
                LabelColumnName = nameof(ProductRating.Label),
                MatrixColumnIndexColumnName = nameof(ProductRating.UserId),
                MatrixRowIndexColumnName = nameof(ProductRating.ProductId),
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var pipeline = _mlContext.Recommendation().Trainers.MatrixFactorization(options);

            // Treinar o modelo
            _model = pipeline.Fit(dataView);
        }

        public async Task<IEnumerable<int>> GetRecommendationsAsync(int userId, int numberOfRecommendations = 5)
        {
            // Treinar o modelo se ainda não estiver treinado
            if (_model == null)
            {
                await TrainModelAsync();
            }

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ProductRating, ProductRatingPrediction>(_model);

            // Obter todos os IDs de produtos
            var allProducts = await _dbContext.Products.Select(p => p.Id).ToListAsync();

            // Obter produtos que o usuário já avaliou
            var ratedProducts = await _dbContext.Ratings
                .Where(r => r.UserId == userId)
                .Select(r => r.ProductId)
                .ToListAsync();

            // Excluir produtos já avaliados pelo usuário
            var productsToRecommend = allProducts.Except(ratedProducts);

            var scoredProducts = new List<Tuple<int, float>>();

            foreach (var productId in productsToRecommend)
            {
                var prediction = predictionEngine.Predict(
                    new ProductRating
                    {
                        UserId = (uint)userId, // Convertendo para uint
                        ProductId = (uint)productId // Convertendo para uint
                    });

                scoredProducts.Add(new Tuple<int, float>(productId, prediction.Score));
            }

            // Ordenar produtos pelo score
            var recommendedProducts = scoredProducts.OrderByDescending(x => x.Item2)
                                                    .Take(numberOfRecommendations)
                                                    .Select(x => x.Item1);

            return recommendedProducts;
        }
    }
}
