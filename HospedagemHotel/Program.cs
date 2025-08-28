using HospedagemHotel.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string cenario = "Cenário 1";
string sumario =
            """
            {0} -> Hóspedes: {1}
            {0} -> Valor total: {2:F2}
            """;

// Cenário 1: 2 hóspedes, diária 30 e 5 dias (sem desconto)
List<Pessoa> hospedes1 = [
    new() { Nome = "João", Sobrenome = "Silva" },
    new() { Nome = "Maria", Sobrenome = "Oliveira" }
];

var suite = new Suite { TipoSuite = "Premium", Capacidade = 3, ValorDiaria = 30m };

var reserva1 = new Reserva { DiasReservados = 5 };
reserva1.CadastrarSuite(suite);
reserva1.CadastrarHospedes(hospedes1);

Console.WriteLine(sumario, cenario, reserva1.ObterQuantidadeHospedes(), reserva1.CalcularValorDiaria());

// Cenário 2: 2 hóspedes, diária 30 e 10 dias (com desconto)
cenario = "Cenário 2";
var reserva2 = new Reserva { DiasReservados = 10 };
reserva2.CadastrarSuite(suite);
reserva2.CadastrarHospedes(hospedes1);

Console.WriteLine(sumario, cenario, reserva2.ObterQuantidadeHospedes(), reserva2.CalcularValorDiaria());


// Cenário 3: Capacidade excedida (suite.Capacidade = 1 e lista com 2 hóspedes)
cenario = "Cenário 3";
var smallSuite = new Suite { TipoSuite = "Standard", Capacidade = 1, ValorDiaria = 30m };
var reserva3 = new Reserva { DiasReservados = 3 };
reserva3.CadastrarSuite(smallSuite);

try
{
    reserva3.CadastrarHospedes(hospedes1);
    Console.WriteLine("Cenário 3 -> Não lançou exceção (ERRO)\n");
}
catch (Exception ex)
{
    Console.WriteLine($"Cenário 3 -> Exceção esperada: {ex.Message}");
}