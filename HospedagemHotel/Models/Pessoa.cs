namespace HospedagemHotel.Models;

public class Pessoa
{
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string NomeCompleto => $"{Nome} {Sobrenome}";
    public override string ToString() => NomeCompleto;
}