﻿namespace TCT.Models
{
    public class Terminal
    {
        public int Id { get; set; }
        public string PartNo { get; set; }
        public int ManufacturerId { get; set; }
        public int TermClassId { get; set; }

        public float? MaxAWG { get; set; }
        public float? MidMaxAWG { get; set; }
        public float? MidMinAWG { get; set; }
        public float? MinAWG { get; set;}
        public float? MaxInsulDiam { get; set; }
        public float? StripLength { get; set; }
        public float? DimFront { get; set; }
        public float? DimRear { get; set; }
        public int CrimpId { get; set; }


        public ICollection<TermToolXref> TermToolXrefs { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public TermClass TermClass { get; set; }
        public ICollection<Crimp> Crimps { get; set; }


    }
}
