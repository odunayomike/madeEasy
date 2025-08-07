using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.WriteLine("Checking database users and login setup...");
        Console.WriteLine("=========================================");
        
        string connectionString = "Data Source=SQL1004.site4now.net;Initial Catalog=db_abcb24_meg;User Id=db_abcb24_meg_admin;Password=MadeEasy101#;Connection Timeout=30;";
        
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("✅ Connected to database");
                
                // Check what users exist in the Users table
                Console.WriteLine("\nChecking Users table...");
                try
                {
                    string getUsersQuery = "SELECT Username, Status FROM Users";
                    using (SqlCommand cmd = new SqlCommand(getUsersQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Users table contents:");
                            bool hasUsers = false;
                            while (reader.Read())
                            {
                                hasUsers = true;
                                Console.WriteLine($"  Username: {reader["Username"]}, Status: {reader["Status"]}");
                            }
                            
                            if (!hasUsers)
                            {
                                Console.WriteLine("❌ No users found in the Users table!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error checking Users table: {ex.Message}");
                }
                
                // Check UserLogin table
                Console.WriteLine("\nChecking UserLogin table...");
                try
                {
                    string checkUserLoginQuery = "SELECT Username, Status FROM UserLogin";
                    using (SqlCommand cmd = new SqlCommand(checkUserLoginQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("UserLogin table contents:");
                            bool hasUserLogins = false;
                            while (reader.Read())
                            {
                                hasUserLogins = true;
                                Console.WriteLine($"  Username: {reader["Username"]}, Status: {reader["Status"]}");
                            }
                            
                            if (!hasUserLogins)
                            {
                                Console.WriteLine("❌ No user logins found in the UserLogin table!");
                                Console.WriteLine("Creating default admin user...");
                                
                                // Create a default admin user
                                string insertUser = @"
INSERT INTO UserLogin (Username, Password, Status, Department, FirstName, LastName, CreatedDate)
VALUES ('admin', 'admin123', 'Active', 'Admin', 'System', 'Administrator', GETDATE())";
                                
                                using (SqlCommand insertCmd = new SqlCommand(insertUser, connection))
                                {
                                    insertCmd.ExecuteNonQuery();
                                    Console.WriteLine("✅ Created default admin user (Username: admin, Password: admin123)");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error with UserLogin table: {ex.Message}");
                    
                    // If UserLogin table doesn't exist, try to create it
                    if (ex.Message.Contains("Invalid object name"))
                    {
                        Console.WriteLine("Creating UserLogin table...");
                        
                        string createUserLoginTable = @"
CREATE TABLE UserLogin (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Active',
    Department NVARCHAR(50),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    CreatedDate DATETIME DEFAULT GETDATE(),
    LastLogin DATETIME NULL
)";
                        
                        using (SqlCommand createCmd = new SqlCommand(createUserLoginTable, connection))
                        {
                            createCmd.ExecuteNonQuery();
                            Console.WriteLine("✅ UserLogin table created");
                            
                            // Insert default admin user
                            string insertAdmin = @"
INSERT INTO UserLogin (Username, Password, Status, Department, FirstName, LastName)
VALUES ('admin', 'admin123', 'Active', 'Admin', 'System', 'Administrator')";
                            
                            using (SqlCommand insertCmd = new SqlCommand(insertAdmin, connection))
                            {
                                insertCmd.ExecuteNonQuery();
                                Console.WriteLine("✅ Default admin user created (Username: admin, Password: admin123)");
                            }
                        }
                    }
                }
                
                Console.WriteLine("\n✅ User check completed!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}