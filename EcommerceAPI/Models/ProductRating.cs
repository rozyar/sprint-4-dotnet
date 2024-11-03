using Microsoft.ML.Data;

namespace EcommerceAPI.Models
{
    public class ProductRating
    {
        [LoadColumn(0)]
        [KeyType(count: 1000)] // Defina uma cardinalidade alta o suficiente para cobrir todos os IDs de usuários
        public uint UserId { get; set; }

        [LoadColumn(1)]
        [KeyType(count: 1000)] // Defina uma cardinalidade alta o suficiente para cobrir todos os IDs de produtos
        public uint ProductId { get; set; }

        [LoadColumn(2)]
        public float Label { get; set; } // Avaliação (Rating)
    }

    public class ProductRatingPrediction
    {
        public float Score { get; set; }
    }
}