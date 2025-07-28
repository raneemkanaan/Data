namespace App.Models
{
    public class Line
    {
        public int Id { get; set; }
        public bool IsTwoWay { get; set; }

        public int FirstNodeId { get; set; }
        public Node FirstNode { get; set; }

        public int SecondeNodeId { get; set; }
        public Node SecondeNode { get; set; }
    }
}
