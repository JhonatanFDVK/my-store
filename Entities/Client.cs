namespace mystore.Entities
{
    internal class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BithDate { get; set; }

        public Client() { }

        public Client(string name, string email, DateTime bithDate)
        {
            Name = name;
            Email = email;
            BithDate = bithDate;
        }
    }
}
