using System;
using Microsoft.Data.SqlClient;
using Reverberator_API.Models;

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

		public void InsertURL(Searches Connor)
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
            command.Parameters.AddWithValue("@Email", Connor.Email);
            command.Parameters.AddWithValue("@URL", Connor.URL);
            command.CommandText =
            @"
            INSERT INTO Search_URLs (Email, URL)
            VALUES ('@Email', '@URL');
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