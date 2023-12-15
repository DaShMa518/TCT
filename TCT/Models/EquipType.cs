namespace TCT.Models
{
    public class EquipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Tool> Tools { get; set; }
<<<<<<< HEAD
=======

>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
    }
}
