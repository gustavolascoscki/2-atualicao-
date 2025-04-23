using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CONCESSIONARIA.Infraestrutura;

public interface IClienteRepositorio
{
    Task<IEnumerable<Cliente>> ListarTodosAsync();
    Task<Cliente> BuscarPorIdAsync(int id);
    Task AdicionarAsync(Cliente cliente);
    Task AtualizarAsync(Cliente cliente);
    Task RemoverAsync(int id);
}

public interface IVeiculoRepositorio
{
    Task<IEnumerable<Veiculo>> ListarTodosAsync();
    Task<Veiculo> BuscarPorIdAsync(int id);
    Task AdicionarAsync(Veiculo veiculo);
    Task AtualizarAsync(Veiculo veiculo);
    Task RemoverAsync(int id);
}

public interface IVendaRepositorio
{
    Task<IEnumerable<Venda>> ListarTodosAsync();
    Task<Venda> BuscarPorIdAsync(int id);
    Task AdicionarAsync(Venda venda);
}

public class ClienteRepositorio : IClienteRepositorio
{
    private readonly BancoDeDadosContexto _contexto;

    public ClienteRepositorio(BancoDeDadosContexto contexto) => _contexto = contexto;

    public async Task AdicionarAsync(Cliente cliente)
    {
        await _contexto.Clientes.AddAsync(cliente);
        await _contexto.SaveChangesAsync();
    }

    public async Task<Cliente> BuscarPorIdAsync(int id) => await _contexto.Clientes.FindAsync(id);

    public async Task<IEnumerable<Cliente>> ListarTodosAsync() => await _contexto.Clientes.ToListAsync();

    public async Task RemoverAsync(int id)
    {
        var cliente = await BuscarPorIdAsync(id);
        if (cliente != null)
        {
            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
        }
    }

    public async Task AtualizarAsync(Cliente cliente)
    {
        _contexto.Clientes.Update(cliente);
        await _contexto.SaveChangesAsync();
    }
}

public class VeiculoRepositorio : IVeiculoRepositorio
{
    private readonly BancoDeDadosContexto _contexto;

    public VeiculoRepositorio(BancoDeDadosContexto contexto) => _contexto = contexto;

    public async Task AdicionarAsync(Veiculo veiculo)
    {
        await _contexto.Veiculos.AddAsync(veiculo);
        await _contexto.SaveChangesAsync();
    }

    public async Task<Veiculo> BuscarPorIdAsync(int id) => await _contexto.Veiculos.FindAsync(id);

    public async Task<IEnumerable<Veiculo>> ListarTodosAsync() => await _contexto.Veiculos.ToListAsync();

    public async Task RemoverAsync(int id)
    {
        var veiculo = await BuscarPorIdAsync(id);
        if (veiculo != null)
        {
            _contexto.Veiculos.Remove(veiculo);
            await _contexto.SaveChangesAsync();
        }
    }

    public async Task AtualizarAsync(Veiculo veiculo)
    {
        _contexto.Veiculos.Update(veiculo);
        await _contexto.SaveChangesAsync();
    }
}

public class VendaRepositorio : IVendaRepositorio
{
    private readonly BancoDeDadosContexto _contexto;

    public VendaRepositorio(BancoDeDadosContexto contexto) => _contexto = contexto;

    public async Task AdicionarAsync(Venda venda)
    {
        await _contexto.Vendas.AddAsync(venda);
        await _contexto.SaveChangesAsync();
    }

    public async Task<Venda> BuscarPorIdAsync(int id) => await _contexto.Vendas.FindAsync(id);

    public async Task<IEnumerable<Venda>> ListarTodosAsync() =>
        await _contexto.Vendas
            .Include(v => v.Cliente)
            .Include(v => v.Veiculo)
            .ToListAsync();
}
