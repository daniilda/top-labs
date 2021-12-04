using System.Threading;
using Npgsql;

namespace DatabaseFlow.Datalayer
{
    public class DatabaseFactory
    {
        public DatabaseWrapper CreateDatabase(string connectionString, CancellationToken cancellationToken)
            => new(new NpgsqlConnection(connectionString), cancellationToken);
    }
}