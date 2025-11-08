namespace api.Models
{
    public partial class OrderingFood
    {
        public int IdOrderingFood { get; set; }
        public int? FoodId { get; set; }
        public int? ClientId { get; set; }
    }
}
