using Microsoft.EntityFrameworkCore;
using CONCESSIONARIA.Models; // A referência agora está correta, pois as classes estão em Models

namespace CONCESSIONARIA.Infraestrutura
{
    public class BancoDeDadosContexto : DbContext
    {
        public BancoDeDadosContexto(DbContextOptions<BancoDeDadosContexto> options)
            : base(options)
        {
        }

        // Definindo as DbSets (as tabelas no banco de dados)
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Se necessário, adicione configurações personalizadas para o seu modelo aqui.
        }
    }
}
