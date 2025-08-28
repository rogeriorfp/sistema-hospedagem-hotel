# Sistema de Hospedagem (console)

Este repositório contém uma pequena aplicação console em .NET que modela um sistema de reservas de suítes em um hotel. O objetivo é demonstrar regras de negócio básicas: cadastro de hóspedes, cadastro de suíte, validação de capacidade e cálculo do valor da reserva com desconto quando aplicável.

## Origem do projeto

Este repositório contém uma solução para o desafio proposto na trilha de .NET (Fundamentos) da plataforma Digital Innovation One (DIO).
A proposta original do desafio pode ser consultada em:

https://github.com/digitalinnovationone/trilha-net-explorando-desafio/blob/main/README.md

Este README descreve a implementação própria deste repositório — não copia textualmente o enunciado original, apenas referencia a fonte e resume o propósito.

## Estrutura principal
- `HospedagemHotel/Program.cs` — pequeno runner com cenários de teste (sem menu).
- `HospedagemHotel/Models/Pessoa.cs` — classe `Pessoa` com `Nome` e `Sobrenome`.
- `HospedagemHotel/Models/Suite.cs` — classe `Suite` com `TipoSuite`, `Capacidade` e `ValorDiaria` (`decimal`).
- `HospedagemHotel/Models/Reserva.cs` — classe `Reserva` com as regras:
  - `CadastrarSuite(Suite suite)` — atribui a suíte.
  - `CadastrarHospedes(List<Pessoa> hospedes)` — valida a capacidade e atribui hóspedes; lança `InvalidOperationException` se exceder.
  - `ObterQuantidadeHospedes()` — retorna o número de hóspedes.
  - `CalcularValorDiaria()` — calcula `DiasReservados * Suite.ValorDiaria` e aplica 10% de desconto quando `DiasReservados >= 10`.

## Diagrama de classes

O diagrama de classes está disponível em [`docs/class-diagram.md`](./docs/class-diagram.md).


## Como executar

Abra um terminal (PowerShell) na raiz do repositório e execute o projeto:

```powershell
dotnet run --project .\HospedagemHotel\
```

O `Program.cs` já inclui três cenários de exemplo (5 dias sem desconto, 10 dias com desconto e tentativa de reserva que excede a capacidade). A saída esperada (exemplo) é:

```
Cenário 1 -> Hóspedes: 2
Cenário 1 -> Valor total: 150
Cenário 2 -> Hóspedes: 2
Cenário 2 -> Valor total: 270,00
Cenário 3 -> Exceção esperada: A quantidade de hóspedes (2) excede a capacidade da suíte (1).
```

> Observação: os valores usam `decimal`. O desconto de 10% é aplicado quando `DiasReservados >= 10`.

## Casos testados manualmente
- 2 hóspedes, ValorDiaria = 30, DiasReservados = 5 -> total = 150 (sem desconto).
- 2 hóspedes, ValorDiaria = 30, DiasReservados = 10 -> total = 270 (10% sobre 300).
- Suite.Capacidade = 1 e lista com 2 hóspedes -> deve lançar exceção de capacidade excedida.

## Boas práticas e notas de implementação
- Mensagens de exceção claras ajudam nos testes automatizados e validações.
- `Reserva` centraliza as regras de negócio: validações de `Suite` e de capacidade estão em métodos da própria classe.
- Valide entradas adicionais conforme necessário (ex.: `DiasReservados > 0`).

## Alterar TargetFramework
Se for necessário atualizar o `TargetFramework` abra `HospedagemHotel/HospedagemHotel.csproj` e ajuste `<TargetFramework>` (o projeto já está configurado para `net9.0`).
