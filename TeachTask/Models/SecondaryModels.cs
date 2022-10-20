namespace TeachTask.Models
{
    public class SecondaryModels
    {
        public List<Secondary> SecondaryList { get; set; }
    }
    public class Secondary
    {
        public int? SecondaryId { get; set; }
        public string NamePhotographer { get; set; } = null!;

    }
}
