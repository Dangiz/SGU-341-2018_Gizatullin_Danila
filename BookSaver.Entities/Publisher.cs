

namespace BookSaver.Entities
{
    public class Publisher
    {
        public Publisher()
        {
        }

        public Publisher(int id, string name, string city, string street, int house_Number)
        {
            Id = id;
            Name = name;
            City = city;
            Street = street;
            House_Number = house_Number;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int House_Number { get; set; }
    }
}
