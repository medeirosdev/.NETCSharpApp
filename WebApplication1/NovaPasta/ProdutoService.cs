using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO;
using WebApplication1.Models;
using MySql.Data.MySqlClient;

namespace WebApplication1.NovaPasta
{
    public class ProdutoService
    {
        public String ConnectionString = "server=127.0.0.1;user=root;database=testwebapi2;port=3306;password=gui167";

        public List<Produto> CsvToList(IFormFile file) {
            List<Produto> produtos;
            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";", // Configurando o delimitador para ponto e vírgula
                    HasHeaderRecord = true, // Indica que a primeira linha contém o cabeçalho

                };

                using (var csvReader = new CsvReader(streamReader, csvConfig))
                {

                    produtos = csvReader.GetRecords<Produto>().ToList();
                    return produtos;
                }
            }
        }


        public void SalvarListaBD(List<Produto> produtoList , MySqlConnection connection)
        {
            var produtosImportados = new List<Produto>();
            var produtosInvalidos = new List<Produto>();

            connection.Open();
                foreach (var produto in produtoList)
                {
                if (produto != null)

                {
                    string sql = @"INSERT INTO produto(id ,tipocodigo, descricao, estoque, precovenda, precocusto, datahoracadastro)
                                            VALUES(@id, @tipocodigo, @descricao, @estoque, @precovenda, @precocusto, @datahoracadastro)";
                
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", produto.Id);
                    cmd.Parameters.AddWithValue("@tipocodigo", produto.TipoCodigo);
                    cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@estoque", produto.Estoque);
                    cmd.Parameters.AddWithValue("@precovenda", produto.PrecoVenda);
                    cmd.Parameters.AddWithValue("@precocusto", produto.PrecoCusto);
                    cmd.Parameters.AddWithValue("@datahoracadastro", produto.DataHoraCadastro);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        produtosImportados.Add(produto);
                    }
                    catch (MySqlException ex)
                    {
                        produtosInvalidos.Add(produto);
                    }
                }
                else
                {
                    produtosInvalidos.Add(produto);
                }
            }
            connection.Close();

        }
        
        public List<Produto> getAllProducts()
        {
            List<Produto> produtos = new List<Produto>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM produto";

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produto produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                TipoCodigo = Convert.ToInt32(reader["tipocodigo"]),
                                Descricao = Convert.ToString(reader["descricao"]),
                                Estoque = Convert.ToDecimal(reader["estoque"]),
                                PrecoVenda = Convert.ToDecimal(reader["precovenda"]),
                                PrecoCusto = Convert.ToDecimal(reader["precocusto"]),
                                DataHoraCadastro = Convert.ToDateTime(reader["datahoracadastro"])
                            };

                            produtos.Add(produto);
                        }
                    }
                }
            }
            return produtos;
        }

        








    }
}
