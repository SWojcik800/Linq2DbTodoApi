using LinqToDB;
using LinqToDB.Configuration;

namespace MinimalApiWithLinq2Db.Database
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class TodoDbConnectionSettings : ILinqToDBSettings
    {
        private string _connectionString;
        public TodoDbConnectionSettings(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<IDataProviderSettings> DataProviders
            => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "Default",
                        ProviderName = ProviderName.SqlServer,
                        ConnectionString = _connectionString
                    };
            }
        }
    }
}
