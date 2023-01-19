namespace Cinema.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

      
        public ICollection<TypeMovie> Type { get; set; }
    }
}
