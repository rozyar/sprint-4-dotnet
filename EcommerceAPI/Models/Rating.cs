namespace EcommerceAPI.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Chave estrangeira para User
        public int ProductId { get; set; } // Chave estrangeira para Product
        public float RatingValue { get; set; } // Avaliação dada pelo usuário

        // Propriedades de navegação
        public User User { get; set; }
        public Product Product { get; set; }
    }
}