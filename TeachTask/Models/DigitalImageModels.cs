namespace TeachTask.Models
{
    public class DigitalImageModels
    {
        public List<DigitalImage> DigitalImageList { get; set; }
    }
    public class DigitalImage
    {
        public int? DigitalImagesId { get; set; }
        public int GraphicProductId { get; set; }
        public int ResourcesId { get; set; }
    }
}
