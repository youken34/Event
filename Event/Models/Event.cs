namespace Event;
public class Event
    {
        private int EventId { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private string Category { get; set; }
        private string Location { get; set; }
        private DateTime DateEvent { get; set; }

        public Event(string Title, string Description, string Category, string Location, DateTime DateEvent){
            this.Title = Title;
            this.Description = Description;
            this.Category = Category;
            this.Location = Location;
            this.DateEvent = DateEvent;
            Console.WriteLine($"New event created: {Title} - {Description}");

    }
}
