﻿namespace TCT.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string InternalId { get; set; }
        public string ModelNo { get; set; }
        public string? SerialNo { get; set; }
        public int? ManufacturerId { get; set; }
        public int? EquipTypeId { get; set; }
        public int CrimpId { get; set; }
<<<<<<< HEAD

        public Manufacturer Manufacturer { get; set; }
        public EquipType EquipType { get; set; }
        public ICollection<Crimp> Crimps { get; set; }
=======


        public ICollection<TermToolXref> TermToolXrefs { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public EquipType EquipType { get; set; }
        public ICollection<Crimp> Crimps { get; set; }



>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
    }
}
