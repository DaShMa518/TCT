namespace TCT.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD
=======


>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
        public ICollection<Terminal> Terminals { get; set; }
        public ICollection<Tool> Tools { get; set; }
    }
}
