namespace HospedagemHotel.Models;

public class Reserva
{
    public List<Pessoa> Hospedes { get; private set; } = [];
    public Suite? Suite { get; private set; }
    public int DiasReservados { get; set; }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (Suite is null)
        {
            throw new InvalidOperationException("Suite não cadastrada. Cadastre uma suíte antes de adicionar hóspedes.");
        }

        ArgumentNullException.ThrowIfNull(hospedes);

        if (Suite.Capacidade < hospedes.Count)
        {
            throw new InvalidOperationException($"A quantidade de hóspedes ({hospedes.Count}) excede a capacidade da suíte ({Suite.Capacidade}).");
        }

        Hospedes = hospedes;
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite ?? throw new ArgumentNullException(nameof(suite));
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes?.Count ?? 0;
    }

    public decimal CalcularValorDiaria()
    {
        if (Suite is null)
            throw new InvalidOperationException("Suite não cadastrada. Não é possível calcular o valor.");

        decimal total = DiasReservados * Suite.ValorDiaria;

        return DiasReservados >= 10 ? total -= total * 0.10m : total;
    }
}