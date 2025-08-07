using Microsoft.Data.SqlClient;
using System;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=SQL1004.site4now.net;Initial Catalog=db_abcb24_meg;User Id=db_abcb24_meg_admin;Password=MadeEasy101#;Connection Timeout=30;";
        
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Checking for getSubSP stored procedure...");
                
                // Check if stored procedure exists
                string checkQuery = "SELECT COUNT(*) FROM sys.objects WHERE type = 'P' AND name = 'getSubSP'";
                using (SqlCommand cmd = new SqlCommand(checkQuery, connection))
                {
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        Console.WriteLine("❌ getSubSP stored procedure does not exist");
                        Console.WriteLine("Creating getSubSP stored procedure...");
                        
                        string createSP = @"
CREATE PROCEDURE getSubSP
    @clientID INT
AS
BEGIN
    SELECT * FROM Subscription WHERE ClientID = @clientID
END";
                        
                        using (SqlCommand createCmd = new SqlCommand(createSP, connection))
                        {
                            createCmd.ExecuteNonQuery();
                            Console.WriteLine("✅ getSubSP stored procedure created successfully");
                        }
                    }
                    else
                    {
                        Console.WriteLine("✅ getSubSP stored procedure exists");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}