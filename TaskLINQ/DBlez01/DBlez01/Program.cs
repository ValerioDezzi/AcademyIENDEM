using DBlez01.Models;
using Microsoft.Data.SqlClient;

namespace DBlez01
   
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Citta> elenco = new List<Citta>();
            string credenziali = "Server=.\\SQLEXPRESS01;Database=citta;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false";
            using (SqlConnection connessione = new SqlConnection(credenziali))
            {
                string query = "SELECT cittaID, nome, prov FROM Citta";
                SqlCommand comando = new SqlCommand(query, connessione);

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    //Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");

                    Citta citta = new Citta()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Nome = reader[1].ToString(),
                        Provincia = reader[2].ToString(),
                    };

                    elenco.Add(citta);
                }

                connessione.Close();
            }

            foreach (Citta cit in elenco)
            {
                Console.WriteLine($"{cit.Nome} {cit.Provincia} {cit.Id}");
            }
        }
    }
}
