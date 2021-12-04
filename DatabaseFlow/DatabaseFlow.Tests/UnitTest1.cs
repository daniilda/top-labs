using System;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Xunit;

namespace DatabaseFlow.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task InsertTest()
        {
            var createQuery = @"CREATE TABLE test_table(Id SERIAL PRIMARY KEY, SomeDesc varchar(500))";
            var insertQuery = @"INSERT INTO test_table (SomeDesc) VALUES (@Values)";
            var selectQuery = @"SELECT SomeDesc FROM test_table";
            var dropQuery = @"DROP TABLE test_table";
            var db = DatabaseCreator.Create();
            await db.Connection.OpenAsync();
            var transaction = await db.Connection.BeginTransactionAsync();
            try
            {
                await db.Connection.ExecuteAsync(createQuery, transaction: transaction);
            }
            finally
            {
                var test = DatabaseCreator.GetTestData();
                await db.Connection.ExecuteAsync(insertQuery, test.Select(x => new
                {
                    Values = x
                }), transaction: transaction);
                var result = await db.Connection.QueryAsync<string>(selectQuery,transaction: transaction);
                await db.Connection.ExecuteAsync(dropQuery, transaction: transaction);
                await transaction.CommitAsync();
                Assert.True(result.Count() == test.Count);
            }
        }
    }
} 