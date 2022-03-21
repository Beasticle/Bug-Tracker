namespace Bug_Tracker.Models
{
    public class BugModel
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string label { get; set; }  
        public bool active { get; set; }
        public bool resolved { get; set; }

    }
}
