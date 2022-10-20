namespace TeachTask.Models
{
    public class GraphicProductModels
    {
        public List<GraphicProduct> GraphicProductsList { get; set; }
    }
    public class GraphicProduct
    {
        public int? GraphicProductId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
