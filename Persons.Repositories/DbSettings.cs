namespace Persons.Repositories
{
    public class DbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string UserCollection { get; set; }

        public string PersonCollection { get; set; }
    }
}