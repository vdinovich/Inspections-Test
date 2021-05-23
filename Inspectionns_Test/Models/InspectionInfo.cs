namespace Inspections_Test.Models
{
    using System.ComponentModel.DataAnnotations;

    public class InspectionInfo
    {
        public int Id { get; set; }
        public double InspectNumber { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime ReportDate { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime LastDate { get; set; }
        public bool NoFindings { get; set; }
        public int HomeId { get; set; }
        public Home Home { get; set; }
        public int TypeId { get; set; }
        public InspectType InspectType { get; set; }
    }
}