

namespace App.Models
{
    public class Node
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public string NodeType { get; set; }
        public bool IsDeleted { get; set; }

        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        public ICollection<Line> LinesFrom { get; set; }
        public ICollection<Line> LinesTo { get; set; }
    }
}
