namespace Inspections_Test.Models
{
    public class OtherOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubsectionId { get; set; }
        public Subsection Subsection { get; set; }
    }
}