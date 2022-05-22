using Commerce.Models;
using System.Data.SqlClient;

namespace Commerce.Repository
{
    public class DBManager
    {
        private static string connectionString = @"Server = ACADEMYNETPD04\SQLEXPRESS; Database = ECOMMERCE; Trusted_Connection = True;";

        public List<OrdiniViewModel> GetAllOrdini()
        {
            List<OrdiniViewModel> ordiniList = new List<OrdiniViewModel>();
            string sql = @"Select * from Ordine";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var ordini = new OrdiniViewModel
                {
                    IdOrdine = Convert.ToInt32(reader["IdOrdine"]),
                    CodC8 = reader["CodC8"].ToString(),
                    CodCliente = reader["CodCliente"].ToString(),
                    Valuta = reader["Valuta"].ToString(),
                    Importo = Decimal.Parse(reader["Importo"].ToString()),
                    Data = Convert.ToDateTime(reader["Data"])

                };
            }
            return ordiniList;
        }

       public int VisualizzaOrdini(OrdiniViewModel ordini)
        {
            string sql = @"Select * from Ordine WHERE IdOrdine =@IdOrdine ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", ordini.Importo);
            command.Parameters.AddWithValue("@Cognome", ordini.Data);
            command.Parameters.AddWithValue("@Citta", ordini.Valuta);
            command.Parameters.AddWithValue("@Salario", ordini.CodC8);
            command.Parameters.AddWithValue("@ID", ordini.CodCliente);

            return command.ExecuteNonQuery();
        }

        public List<ProdottiViewModel> GetAllProdotti()
        {
            List<ProdottiViewModel> prodottiList = new List<ProdottiViewModel>();
            string sql = @"Select * from Impiegato";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var prodotto = new ProdottiViewModel
                {
                    IDC8 = Convert.ToInt32(reader["IDC8"]),
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    Url = reader["Url"].ToString(),
                    Disponibilita = Convert.ToInt32(reader["Disponibilita"])
                };
                
            }
            return prodottiList;
        }

        public List<ClientiViewModel> GetAllClienti()
        {
            List<ClientiViewModel> clientiList = new List<ClientiViewModel>();
            string sql = @"Select * from Clienti";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cliente = new ClientiViewModel
                {
                    IdCliente = Convert.ToInt32(reader["IdCliente"]),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    DataNascita = Convert.ToDateTime(reader["DataNascita"]),
                    CF = (reader["CF"].ToString),
                    Paese = (reader["Paese"].ToString),
                    Email = (reader["Email"].ToString)
                };

            }
            return clientiList;
        }

        public int EditCliente(ClientiViewModel cliente)
        {
            string sql = @"UPDATE Clienti
                       SET [IdCliente] = @IdCliente
                          ,[Nome] = @Nome
                          ,[Cognome] = @Cognome
                          ,[DataNascita] = @DataNascita,
                          ,[CF] = @CF
                          ,[Paese] = @Paese
                          ,[Email] = @Email
                     WHERE IdCliente =@IdCliente";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
            command.Parameters.AddWithValue("@DataNascita", cliente.DataNascita);
            command.Parameters.AddWithValue("@CF", cliente.CF);
            command.Parameters.AddWithValue("@Paese", cliente.Paese);
            command.Parameters.AddWithValue("@Email", cliente.Email);

            return command.ExecuteNonQuery();
        }

    }
}
