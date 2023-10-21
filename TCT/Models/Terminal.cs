namespace TCT.Models
{
    public class Terminal
    {
        public int Id { get; set; }
        public string PartNo { get; set; }
        public float? MaxAWG { get; set; }
        public float? MidMaxAWG { get; set; }
        public float? MidMinAWG { get; set; }
        public float? MinAWG { get; set;}
        public float? MaxInsulDiam { get; set; }
        public float? StripLength { get; set; }
        public float? DimFront { get; set; }
        public float? DimRear { get; set; }

        public ICollection<TermToolXref> TermToolXrefs { get; set; }
    }
}
