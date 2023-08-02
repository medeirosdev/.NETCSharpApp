using CsvHelper.Configuration.Attributes;

namespace WebApplication1.Models
{
    public class Produto
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("tipocodigo")]
        public int TipoCodigo { get; set; }
        [Name("descricao")]
        public string Descricao { get; set; }
        [Name("estoque")]
        public decimal Estoque { get; set; }
        [Name("precovenda")]
        public decimal PrecoVenda { get; set; }
        [Name("precocusto")]
        public decimal PrecoCusto { get; set; }
        [Name("datahoracadastro")]
        public DateTime DataHoraCadastro { get; set; }
    }


}