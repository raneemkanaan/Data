namespace App.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Floor> Floors { get; set; }
    }
}
