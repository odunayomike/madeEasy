using System;
using Microsoft.Data.SqlClient;

namespace DatabaseConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Database Connection...");
            Console.WriteLine("================================");

            // Connection string from your App.config
            string connectionString = "Data Source=SQL1004.site4now.net;Initial Catalog=db_abcb24_meg;User Id=db_abcb24_meg_admin;Password=MadeEasy101#;Connection Timeout=30;";

            try
            {
                Console.WriteLine("Attempting to connect to: SQL1004.site4now.net");
                Console.WriteLine("Database: db_abcb24_meg");
                Console.WriteLine();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Opening connection...");
                    connection.Open();
                    
                    Console.WriteLine("✅ Connection successful!");
                    Console.WriteLine($"Server Version: {connection.ServerVersion}");
                    Console.WriteLine($"Database: {connection.Database}");
                    Console.WriteLine($"Connection State: {connection.State}");

                    // Test a simple query
                    Console.WriteLine("\nTesting simple query...");
                    using (SqlCommand command = new SqlCommand("SELECT GETDATE() as CurrentTime", connection))
                    {
                        var result = command.ExecuteScalar();
                        Console.WriteLine($"Server Time: {result}");
                    }

                    // Test if we can see some tables
                    Console.WriteLine("\nChecking available tables...");
                    using (SqlCommand command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Tables found:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"  - {reader["TABLE_NAME"]}");
                            }
                        }
                    }
                }

                Console.WriteLine("\n✅ All tests passed! Your cloud database connection is working properly.");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"❌ SQL Server Error: {sqlEx.Message}");
                Console.WriteLine($"Error Number: {sqlEx.Number}");
                Console.WriteLine($"Severity: {sqlEx.Class}");
                Console.WriteLine($"State: {sqlEx.State}");
                
                if (sqlEx.Number == 2)
                {
                    Console.WriteLine("\n💡 Tip: This usually means the server name is incorrect or the server is not accessible.");
                }
                else if (sqlEx.Number == 18456)
                {
                    Console.WriteLine("\n💡 Tip: This usually means the username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ General Error: {ex.Message}");
                Console.WriteLine($"Type: {ex.GetType().Name}");
            }

            Console.WriteLine("\nTest completed.");
        }
    }
}