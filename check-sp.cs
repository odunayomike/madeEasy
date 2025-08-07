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
                string checkQuery = "SELECT OBJECT_ID('getSubSP')";
                using (SqlCommand cmd = new SqlCommand(checkQuery, connection))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        Console.WriteLine("❌ getSubSP stored procedure does not exist");
                        
                        // Create the stored procedure
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
                        
                        // Get the stored procedure definition
                        string getSPDefinition = @"
SELECT OBJECT_DEFINITION(OBJECT_ID('getSubSP'))";
                        using (SqlCommand defCmd = new SqlCommand(getSPDefinition, connection))
                        {
                            var definition = defCmd.ExecuteScalar()?.ToString();
                            Console.WriteLine($"Current definition:\n{definition}");
                        }
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