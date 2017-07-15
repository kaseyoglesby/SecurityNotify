namespace SecNotify.Models
{
    public class Location
    {
        public int ID { get; set; }
        private static int nextID = 0;

        public string Name { get; set; }
        public string Phone { get; set; }

        public Location()
        {
            ID = nextID;
            nextID++;
        }
    }
}
