namespace CONCESSIONARIA.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVenda { get; set; }

        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}

