namespace TvcLesson4Lap.Models
{
    

    public class TvcProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int SalePrice { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
