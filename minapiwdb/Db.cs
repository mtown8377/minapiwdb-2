using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace sqltest
{
    class Program
    {
        public async Task<string> Lookup()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "try5.database.windows.net",
                UserID = "monkeyadmin",
                Password = "JV773#VJ#$Jvjv4j3",
                InitialCatalog = "try5"
            };

            var connectionString = builder.ConnectionString;

            try
            {
                await using var connection = new SqlConnection(connectionString);

                await connection.OpenAsync();

                var sql = "SELECT animal FROM dbo.Animals WHERE animal <> 'puppy'";
                await using var command = new SqlCommand(sql, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    return reader.GetString(0);
                }
            }
            catch (SqlException e) when (e.Number == 25)
            {

            }


            return "hello butthead";
        }
    }
}