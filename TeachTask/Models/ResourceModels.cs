namespace TeachTask.Models
{
    public class ResourceModels
    {
        public List<Resource> ResourceList { get; set; }
    }
    public class Resource
    {
        public int? ResourcesId { get; set; }
        public int PrimaryId { get; set; }
        public int SecondaryId { get; set; }
    }
}
