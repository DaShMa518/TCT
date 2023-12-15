namespace TCT.Models
{
    public class Crimp
    {
        public int Id { get; set; }
        public int TerminalId { get; set; }
        public int ToolId { get; set; }
        public int WireAWG { get; set; }
        public float CrimpHeight { get; set; }
        public int PullForce { get; set; }

        public Terminal Terminal { get; set; }
        public Tool Tool { get; set; }
<<<<<<< HEAD
=======


>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
    }
}
