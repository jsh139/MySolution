using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using NServiceBus;
using System;

namespace nservicebusapp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.UseNServiceBus(ctx =>
            {
                var connectionString = $"server=localhost;user=root;database=bullhorn;port=3306;password=password1;SSL Mode=None";

                var endpointConfiguration = new EndpointConfiguration("Assurance.BullhornApi");
                var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
                persistence.SqlDialect<SqlDialect.MySql>();

                var connection = new MySqlConnection(connectionString);

                try
                {
                    connection.Open();

                    string sql = "SELECT * FROM Client";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                        Console.WriteLine("Client Key : " + rdr[1]);
                    
                    rdr.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                } 

                persistence.ConnectionBuilder( () =>
                    {
                        return connection;
                    });
                var subscriptions = persistence.SubscriptionSettings();
                subscriptions.CacheFor(TimeSpan.FromMinutes(1));

                var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
                transport.ConnectionString(connection.ConnectionString);

                return endpointConfiguration;
            });

            return builder.ConfigureServices((ctx, services) => {});
        }
    }
}
