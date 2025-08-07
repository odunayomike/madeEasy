using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Fixing all problematic stored procedures...");
        Console.WriteLine("==========================================");
        
        string connectionString = "Data Source=SQL1004.site4now.net;Initial Catalog=db_abcb24_meg;User Id=db_abcb24_meg_admin;Password=MadeEasy101#;Connection Timeout=30;";
        
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("✅ Connected to database");
                
                // List of problematic stored procedures to fix
                var problematicSPs = new List<string>
                {
                    "getNotificationTitleSP",
                    "countUnreadNotificationSP", 
                    "readNotificationSP",
                    "insertFeedbackSP",
                    "getWorkHourSubMessageSP",
                    "getSupportResponseSP",
                    "unreadMessageSP",
                    "insertSupportSP",
                    "getClientIDSP",
                    "getNewsSP",
                    "getSubMaintenanceSP"
                };
                
                foreach (string spName in problematicSPs)
                {
                    Console.WriteLine($"\nProcessing {spName}...");
                    
                    try
                    {
                        // Get current definition
                        string getDefQuery = $"SELECT OBJECT_DEFINITION(OBJECT_ID('{spName}'))";
                        string definition = "";
                        
                        using (SqlCommand cmd = new SqlCommand(getDefQuery, connection))
                        {
                            definition = cmd.ExecuteScalar()?.ToString() ?? "";
                        }
                        
                        if (!string.IsNullOrEmpty(definition) && definition.Contains("Softlightpro.dbo."))
                        {
                            // Fix the definition by replacing database references
                            string fixedDefinition = definition.Replace("Softlightpro.dbo.", "dbo.");
                            
                            // Drop the old stored procedure
                            using (SqlCommand dropCmd = new SqlCommand($"DROP PROCEDURE {spName}", connection))
                            {
                                dropCmd.ExecuteNonQuery();
                            }
                            
                            // Create the fixed stored procedure
                            using (SqlCommand createCmd = new SqlCommand(fixedDefinition, connection))
                            {
                                createCmd.ExecuteNonQuery();
                                Console.WriteLine($"✅ Fixed {spName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ℹ️ {spName} appears to be already correct or doesn't exist");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error fixing {spName}: {ex.Message}");
                    }
                }
                
                Console.WriteLine("\n✅ All stored procedures have been processed!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}