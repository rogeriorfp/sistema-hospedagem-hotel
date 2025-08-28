# Diagrama de classes (Mermaid)

Arquivo com o diagrama de classes em formato Mermaid para fácil visualização em ferramentas que suportam Mermaid (ex.: GitHub, VS Code Mermaid Preview, etc.).

```mermaid
classDiagram
    class Pessoa {
      -string Nome
      -string Sobrenome
    }

    class Suite {
      -string TipoSuite
      -int Capacidade
      -decimal ValorDiaria
    }

    class Reserva {
      -List~Pessoa~ Hospedes
      -Suite Suite
      +int DiasReservados
      +void CadastrarHospedes(List~Pessoa~ hospedes)
      +void CadastrarSuite(Suite suite)
      +int ObterQuantidadeHospedes()
      +decimal CalcularValorDiaria()
    }

    Reserva o-- Pessoa : possui
    Reserva o-- Suite : usa
```

Notas:
- `Reserva` agrega `Pessoa` e usa `Suite`.
- Os métodos públicos apresentados refletem a API principal implementada em `HospedagemHotel/Models/Reserva.cs`.
