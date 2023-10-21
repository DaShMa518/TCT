namespace TCT.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string InternalId { get; set; }
        public string ModelNo { get; set; }
        public string? SerialNo { get; set; }

        public ICollection<TermToolXref> TermToolXrefs { get; set; }

    }
}
