namespace stuff
{
    public class Book
    {
        public readonly string Name;
        public readonly string Author;
        public readonly int ReleaseYear;

        public Book(string name, string author, int releaseYear)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }
    }
}