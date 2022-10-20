namespace TeachTask.Models
{
    public class PrimarySecondaryModels
    {
        public List<PrimarySecondary> PrimarySecondaryList { get; set; }
    }
    public class PrimarySecondary
    {
        public int? PrimaryId { get; set; }
        public string Address { get; set; }
        public int? SecondaryId { get; set; }
        public string NamePhotographer { get; set; }
    }
}
