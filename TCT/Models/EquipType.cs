namespace TCT.Models
{
    public class EquipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Tool> Tools { get; set; }
    }
}
