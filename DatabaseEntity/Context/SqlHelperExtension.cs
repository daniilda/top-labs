namespace DatabaseEntity.Context
{
    public static class SqlHelperExtension
    {
        public static string GetPostgresConnectionString()
        {
            return "UserID=root;Password=root;Host=localhost;Port=5432;" +
                   "Database=database;Pooling=true;MinPoolSize=0;" +
                   "MaxPoolSize=100;ConnectionLifetime=0";
        }
    }
}