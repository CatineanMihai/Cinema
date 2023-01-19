namespace Cinema.Models
{
    public class TypeMovie
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }

    }
}