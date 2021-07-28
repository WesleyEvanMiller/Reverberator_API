using System;
using Microsoft.Data.SqlClient;

namespace Reverberator_API.Databases
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class Search_URL
	{
		public Search_URL()
		{

		}

		public void InsertURL()
		{

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.IntegratedSecurity = false;
            builder.DataSource = "127.0.0.1";
            builder.InitialCatalog = "Reverberator";
            builder.TrustServerCertificate = true;
            builder.UserID = "conno";
            builder.Password = "Frontflip2";
            var connection = new SqlConnection(builder.ConnectionString);
            
            connection.Open();
            
            var command = connection.CreateCommand();
            command.CommandText =
            @"
            INSERT INTO Search_URLs (Email, URL)
            VALUES ('Connor', 'weee');
            ";

            var reader = command.ExecuteReader();
                
            while (reader.Read())
            {
                var name = reader.GetString(0);

                Console.WriteLine($"Hello, {name}!");
            }
            connection.Close();
        }
	}
}