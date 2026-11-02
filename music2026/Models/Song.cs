namespace music2026.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Artist { get; set; }

        public int PublishYear { get; set; }

        public string? Genre { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Artist: {Artist}, PublishYear: {PublishYear}, Genre: {Genre}";
        }

    }
}
