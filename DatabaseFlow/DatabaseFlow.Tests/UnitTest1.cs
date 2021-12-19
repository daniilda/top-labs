using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Xunit;

namespace DatabaseFlow.Tests
{
    public class UnitTest1
    {
        const string CreateQuery = @"CREATE TABLE test_table(Id SERIAL PRIMARY KEY, SomeDesc varchar(500))";
        const string InsertQuery = @"INSERT INTO test_table (SomeDesc) VALUES (@Values)";
        const string SelectQuery = @"SELECT SomeDesc FROM test_table";
        const string UpdateQuery = @"UPDATE test_table SET SomeDesc = @NewValue WHERE SomeDesc = @OldValue";
        [Fact]
        public async Task InsertTest()
        {
            var db = DatabaseCreator.Create();
            await db.Connection.OpenAsync();
            var transaction = await db.Connection.BeginTransactionAsync();
            try
            {
                await db.Connection.ExecuteAsync(CreateQuery, transaction: transaction);
            }
            finally
            {
                var test = DatabaseCreator.GetTestData();
                await db.Connection.ExecuteAsync(InsertQuery, test.Select(x => new
                {
                    Values = x
                }), transaction);
                var result = await db.Connection.QueryAsync<string>(SelectQuery,transaction: transaction);
                await transaction.RollbackAsync();
                Assert.True(result.Count() == test.Count);
            }
        }

        [Fact]
        public async Task UpdateTest()
        {
            var db = DatabaseCreator.Create();
            await db.Connection.OpenAsync();
            var transaction = await db.Connection.BeginTransactionAsync();
            try
            {
                await db.Connection.ExecuteAsync(CreateQuery, transaction: transaction);
            }
            finally
            {
                var test = DatabaseCreator.GetTestData();
                await db.Connection.ExecuteAsync(InsertQuery, test.Select(x => new
                {
                    Values = x
                }), transaction);
                await db.Connection.ExecuteAsync(UpdateQuery, new
                {
                    OldValue = test.First(),
                    NewValue = DatabaseCreator.GetTestString()
                }, transaction);
                var result = await db.Connection.QueryAsync<string>(SelectQuery,transaction: transaction);
                await transaction.RollbackAsync();
                Assert.Contains(DatabaseCreator.GetTestString(), result);
            }
        }
    }
} 