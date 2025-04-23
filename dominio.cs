using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    public required string Nome { get; set; }

    [Required]
    public required string Cpf { get; set; }

    [Required]
    public required string Telefone { get; set; }
}

public class Veiculo
{
    public int Id { get; set; }

    [Required]
    public required string Marca { get; set; }

    [Required]
    public required string Modelo { get; set; }

    public int Ano { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }
}

public class Venda
{
    public int Id { get; set; }

    [Required]
    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    [Required]
    public int VeiculoId { get; set; }

    public virtual Veiculo Veiculo { get; set; } = null!;

    public DateTime DataVenda { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ValorFinal { get; set; }
}
