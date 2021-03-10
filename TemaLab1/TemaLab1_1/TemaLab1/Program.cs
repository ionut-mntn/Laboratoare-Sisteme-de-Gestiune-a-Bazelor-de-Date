using System;
using System.Data;
using System.Data.SqlClient;

namespace TemaLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-2SFQL7E\\SQLEXPRESS;Initial Catalog=lab1;Integrated Security=true";

            string parentTablequeryString = "" +
                "select * from Sportiv";
            // subclub - sportiv, antrenament - sportiv !!

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();              // deschidem conexiunea!!
                Console.WriteLine("proba cox");
                SqlCommand command = new SqlCommand(parentTablequeryString, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader(); // atentie!! abia aici execut instructiunile din string-ul meu!!
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                    }
                    reader.Close();         // inchidem reader-ul!!
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
