

namespace App.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsDeleted { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public ICollection<Node> Nodes { get; set; }
    }
}
