﻿namespace Inspections_Test.Models
{
    using System.Collections.Generic;

    public class InspectType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<InspectionInfo> InspectionInfos { get; set; }
    }
}