namespace Inspections_Test.Models
{
    using System.Collections.Generic;

    public class LTCHAReg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}