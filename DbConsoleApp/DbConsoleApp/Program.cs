using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tässä tulee olla oman serverisi osoite ja tietokannan nimi
            string connStr = "";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "SELECT * FROM Shippers";

            //Command-olio, mikä suorittaa annetun SQL-lauseen
            SqlCommand cmd = new SqlCommand(sql, conn);

            //DataReader-olio, mikä lukee kyselyn tulokset rivi kerrallaan
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("id".PadRight(10) + "companyName".PadRight(20) + "Phone".PadRight(15));

            while (reader.Read()) 
            {
                int id = reader.GetInt32(0);
                string companyName = reader.GetString(1);
                string Phone = reader.GetString(2);
                Console.WriteLine(id.ToString().PadRight(10) + companyName.PadRight(20) + Phone.PadRight(15));
            }

            /* Videolla oleva esimerkki jossa käytetään substringiä koska data saattaa olla pidempää kuin sille varattu tila ja sarakkeet eivät osuneet ihan kohdilleen.
            Videolla Speedy Express Services liian pitkä.

            while (reader.Read()) 
            {
                int id = reader.GetInt32(0);
                string companyName = reader.GetString(1);
                string Phone = reader.GetString(2);
                Console.WriteLine(id.ToString().PadRight(10).Substring(0, 10) + companyName.PadRight(20).Substring(0, 20) + Phone.PadRight(15).Substring(0, 15));
            } */


            Console.ReadLine();

            //resurssien vapautus, suljetaan tietokantayhteydet ja lukijat
            reader.Close();
            cmd.Dispose();
            conn.Dispose();
        }
    }
}
