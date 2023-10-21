namespace TCT.Models
{
    public class TermToolXref
    {
        public int Id { get; set; }
        public int TerminalId { get; set; }
        public int ToolId { get; set; }

        public Terminal Terminal { get; set; }
        public Tool Tool { get; set; }

    }
}
