namespace TeachTask.Models
{
    public class PrimaryModels
    {
        public List<Primary> PrimaryList { get; set; }
    }
    public class Primary
    {
        public int? PrimaryId { get; set; }
        public string Address { get; set; } = null!;
    }
}
