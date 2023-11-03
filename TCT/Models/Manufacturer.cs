namespace TCT.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Terminal> Terminals { get; set; }
        public ICollection<Tool> Tools { get; set; }
    }
}
