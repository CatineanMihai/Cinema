namespace Cinema.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        
    }
}