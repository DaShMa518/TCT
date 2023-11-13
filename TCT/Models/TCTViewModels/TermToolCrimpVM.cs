namespace TCT.Models
{
    public class TermToolCrimpVM
    {
        public IEnumerable<Terminal> Terminals { get; set; }
        public IEnumerable<Tool> Tools { get; set; }
        public IEnumerable<Crimp> Crimps { get; set; }

    }
}
