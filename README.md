

eDiskCommerce Application
=====================
 API .NET Core
 
  Api deve simular um eCommerce de discos, permitindo a venda e calculando o valor de cashback de cada compra e itens.

- Consultar o catálogo de discos de forma paginada, filtrando por gênero e ordenando de forma crescente pelo nome do disco;
- Consultar o disco pelo seu identificador;
- Consultar todas as vendas efetuadas de forma paginada, filtrando pelo range de datas (inicial e final) da venda e ordenando de forma decrescente pela data da venda;
- Consultar uma venda pelo seu identificador;
- Registrar uma nova venda de discos calculando o valor total de cashback.
- Integrar com a API do SPotify para alimenar a coleção de Discos.


## Como rodar a aplicação:
- Possuir a ultima versão do  SDK (https://dot.net/core)

 # .NET CLI
  Apartir do diretório clonado da aplicação:
  dotnet run --project DiskCommerce.Service\DiskCommerce.Service.csProj

  Acessar o Swagger para visualizar os endPoint e testar as chamadas
  https://localhost:5001/swagger/index.html
  
  # informações importantes :
  
   - A aplicação esta utilizando EF Core in memory ( * Apenas para testes) , portanto os dados só serão mantidos durante o ciclo de vida da aplicação.
   - Os dados de clientes( Buyers) e de discos estão sendo criados no momento da inicialização
   - Os discos são buscados através da API do Spotify.
   - Divida Técnica: A Api esta retornando classes do dominio ao invés de serem mapeadas para ViewModels (Automapper) 

## Tecnologias Utilizadas:

- ASP.NET Core 2.1 (with .NET Core)
- ASP.NET MVC Core 
- ASP.NET WebApi Core
- Entity Framework Core 2.1
- Entity Framework Core 2.1 (InMemory)
- .NET Core Native DI
- FluentValidator
- MediatR
- Swagger UI

## Architecture / Patterns:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS ( utilizando um unico banco de daods)
- Unit of Work
- Repository
- Factory


