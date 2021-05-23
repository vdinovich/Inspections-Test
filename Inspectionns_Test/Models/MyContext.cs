namespace Inspections_Test.Models
{
    using System.Data.Entity;

    public class MyContext : DbContext
    {
        public MyContext() : base("name=connection") { }

        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<InspectionInfo> InspectionInfos { get; set; }
        public virtual DbSet<InspectType> InspectTypes { get; set; }
        public virtual DbSet<NonCompleance> NonCompleances { get; set; }
        public virtual DbSet<LTCHAReg> LTCHARegs { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Subsection> Subsections { get; set; }
        public virtual DbSet<OtherOption> OtherOptions { get; set; }
    }
}