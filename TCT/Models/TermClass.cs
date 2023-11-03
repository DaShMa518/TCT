namespace TCT.Models
{
    public class TermClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int TermId { get; set; }

        public ICollection<Terminal> Terminals { get; set; }
    }
}
