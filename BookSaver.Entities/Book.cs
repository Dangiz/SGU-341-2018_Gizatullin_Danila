namespace BookSaver.Entities
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int id, string name, int year)
        {
            Id = id;
            Name = name;
            Year = year;
        }

        public int Id { get; }

        public string Name { get; set; }

        public int Year { get; set; }

    }
}
