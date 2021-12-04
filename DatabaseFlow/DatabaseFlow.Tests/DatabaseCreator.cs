using System.Collections.Generic;
using System.Threading;
using DatabaseFlow.Datalayer;

namespace DatabaseFlow.Tests
{
    public static class DatabaseCreator
    {
        public static DatabaseWrapper Create()
        {
            var connectionString = SqlHelperExtension.GetPostgresConnectionString();
            var dbFactory = new DatabaseFactory();
            return dbFactory.CreateDatabase(connectionString, new CancellationToken());
        }

        public static List<string> GetTestData()
        {
            return new List<string> { "kek", "bek", "cheburek" };
        }
    }
}