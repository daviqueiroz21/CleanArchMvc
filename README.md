
# CleanArchMvc - Projeto de Catálogo de Produtos 🛒

## Escopo Geral 🌐

### Objetivo 🎯

O projeto CleanArchMvc tem como objetivo criar uma aplicação web utilizando ASP.NET Core MVC para o gerenciamento de produtos e categorias, proporcionando a criação de um catálogo de produtos para vendas.

### Ferramentas Utilizadas 🛠️

-   Visual Studio Community (ou VS Code)
-   ASP.NET Core MVC
-   Entity Framework Core
-   SQL Server

## Estrutura do Projeto 🏗️

O projeto CleanArchMvc segue a abordagem da Clean Architecture, com os seguintes componentes distribuídos por camadas:

1.  **CleanArchMvc.Domain:**
    
    -   `Entities`: Contém as classes que representam o modelo de domínio (Product e Category).
    -   `Interfaces`: Contém as interfaces (ICategoryRepository, IProductRepository).
    -   `Validation`: Contém a classe `DomainExceptionValidation` para validar o modelo de domínio.
2.  **CleanArchMvc.Application:**
    
    -   `Services`: Contém os serviços (ProductService, CategoryService).
    -   `Interfaces`: Contém as interfaces (IProductService, ICategoryService).
    -   `DTOs`: Contém os Data Transfer Objects (ProductDTO, CategoryDTO).
    -   `Mappings`: Contém mapeamentos entre domínio e visão (DomainViewModel, ViewModelDomain).
    -   `CQRS`: Implementação do padrão Command-Query Responsibility Segregation.
    -   `Exceptions`: Tratamento de exceções específicas.
3.  **CleanArchMvc.Infra.Data:**
    
    -   `Repositories`: Implementação concreta dos repositórios (ProductRepository, CategoryRepository).
    -   `Context`: Implementação do DbContext (ApplicationDbContext).
    -   `Migrations`: Migrations para versionamento do banco de dados.
    -   `Identity`: Configuração para autenticação e autorização com Identity.
4.  **CleanArchMvc.Infra.IoC:**
    
    -   `DependencyInjection`: Configuração da injeção de dependência e registro de serviços.
    -   `Lifetime`: Utilização dos padrões de tempo de vida (Transient, Scoped, Singleton).
5.  **CleanArchMvc.WebUI:**
    
    -   `Controllers`: Controladores da aplicação (AccountController, CategoriesController, ProductsController).
    -   `Views`: Arquivos de visualização da aplicação.
    -   `Filters`: Filtros utilizados na aplicação.
    -   `MapConfig`: Configurações de mapeamento entre domínio e visão.
    -   `ViewModels`: Modelos de visão utilizados pela camada de apresentação.

## Regras de Negócio do Produto 📝

1.  Exibir produtos.
2.  Criar um novo produto.
3.  Alterar propriedades de um produto existente (o Id do produto não pode ser alterado).
4.  Excluir um produto existente pelo seu Id.
5.  Relacionamento entre produto e categoria (propriedade de navegação).
6.  Restrições para criação de produtos:
    -   Construtor parametrizado para evitar estado inconsistente.
    -   Atributos Id, Stock e Price não podem ser negativos.
    -   Atributos Name e Description não podem ser nulos ou vazios.
    -   Atributo Image pode ser nulo.
    -   Atributo Name não pode ter menos que 3 caracteres.
    -   Atributo Description não pode ter menos que 5 caracteres.
    -   Atributo Image não pode ter mais que 250 caracteres.
    -   Imagem será armazenada como uma string com arquivo separado em uma pasta do projeto.

## Regras de Negócio da Categoria 📝

1.  Exibir categorias.
2.  Criar uma nova categoria.
3.  Alterar propriedades de uma categoria existente (o Id da categoria não pode ser alterado).
4.  Excluir uma categoria existente pelo seu Id.
5.  Relacionamento entre categoria e produto (propriedade de navegação).
6.  Restrições para criação de categorias:
    -   Construtor parametrizado para evitar estado inconsistente.
    -   Atributo CategoryId não pode ter valor negativo.
    -   Atributo Name não pode ser nulo ou vazio.
    -   Atributo Name não pode ter menos que 3 caracteres.

## Persistência dos Dados 💾

-   Banco de dados relacional: SQL Server.
-   ORM: Entity Framework Core.
-   Abordagem Code-First.
-   Provedor do banco de dados: Microsoft.EntityFrameworkCore.SqlServer.
-   Ferramenta para aplicar Migrations: Microsoft.EntityFrameworkCore.Tools.
-   Desacoplamento da camada de acesso a dados do ORM usando o padrão Repository.

## Nomenclatura 📏

-   CamelCase: `valorDoDesconto`, `nomeCompleto`.
-   PascalCase: `CalculaImpostoDeRenda`, `ValorDoDesconto`.
-   Classes: PascalCase.
-   Interfaces: `I` + PascalCase.
-   Métodos, Propriedades: PascalCase.
-   Variáveis, Parâmetros: camelCase.
-   Constantes: Maiúsculo + sublinhado.

## Estrutura do Projeto CleanArchMvc 🏠

-   CleanArchMvc.Domain: Sem dependências.
-   CleanArchMvc.Application: Dependência com CleanArchMvc.Domain.
-   CleanArchMvc.Infra.Data: Dependência com CleanArchMvc.Domain.
-   CleanArchMvc.Infra.IoC: Dependência com CleanArchMvc.Domain, CleanArchMvc.Application, CleanArchMvc.Infra.Data.
-   CleanArchMvc.WebUI: Dependência com CleanArchMvc.Infra.IoC.

## Testes de Unidade 🧪

-   Idioma: Inglês.
-   Nome do teste: `<Método ou Classe>_<Cenário de Teste>_<Resultado Esperado>`.

Exemplo:


```C#
[Fact(DisplayName="Create Category Object With Valid State")]
public void CreateProduct_WithValidParameters_ResultObjectValidState()
{
    Action action = () => new Category(1, "Category Name");
    action.Should()
        .NotThrow<DomainExceptionValidation>();
} 

```

## Configuração de Entidades do Modelo ⚙️

A configuração das entidades do modelo é realizada utilizando a Fluent API do Entity Framework Core para evitar problemas de mapeamento automático, garantindo maior controle sobre o esquema do banco de dados.

## Registro de Serviços no Contêiner IoC 🔄

-   Lifetimes: Transient, Scoped, Singleton.
-   Registro de serviços para injeção de dependência.

## EF Core Migrations ⚙️

-   Atualização incremental do esquema do banco de dados.
-   Manutenção da sincronia com o modelo de dados do aplicativo.
-   Geração de migrações para versionamento do banco de dados.
-   Comparação do modelo atual com um instantâneo do modelo antigo.

## Restrição de Acesso e Exposição de Informações 🔐

-   Utilização de Data Transfer Objects (DTOs) para restringir acesso e exposição de informações específicas.
-   Evolução independente do modelo de entidades e dos DTOs.

## Serviços da Camada Application 🚀

-   Comunicação com a camada de domínio representada pelo projeto Domain

# CQS - Command Query Separation 🚀

O princípio CQS (Command Query Separation) estabelece que cada método deve ser ou um comando que executa uma ação ou uma consulta que retorna dados ao chamador, mas não ambos. O CQS define dois tipos de mensagens dependendo de seu valor de retorno:

1.  A não existência de um valor de retorno (void) especifica que temos um Comando.
2.  A existência de um valor de retorno especifica que temos uma Consulta.

Em resumo, um comando é um método que altera o estado, enquanto uma consulta é um método que retorna um estado.

# CQRS - Command Query Responsibility Separation 🚀

O CQRS (Command Query Responsibility Separation) leva o conceito do CQS adiante, determinando a separação dos comandos e das consultas em objetos diferentes. A ideia principal do CQRS é permitir que um aplicativo funcione com diferentes modelos: um modelo para comandos e outro para consultas.

Principais pontos do CQRS:

-   Separação de comandos e consultas em modelos distintos.
-   Flexibilidade com diferentes modelos para diferentes operações.
-   Modelos específicos para comando e consulta.
-   Não dependência de apenas um DTO para todas as operações CRUD.
-   Implementação do padrão Mediator para otimizar e favorecer o desacoplamento.

## Implementação do Padrão CQRS no Projeto (Entidade: Product) 🚀

1.  **Modelos para Comandos:**
    
    -   ProductCommand
    -   ProductCreateCommand
    -   ProductUpdateCommand
    -   ProductRemoveCommand
2.  **Modelos para Consultas:**
    
    -   GetProductByIdQuery
    -   GetProductsQuery

Essas classes representam os comandos e consultas e devem implementar a interface `IRequest` da MediatR, que representa um request com um response. A interface `IRequest` aceita o tipo que o respectivo handler deverá retornar para o componente chamador. Um Request contém propriedades que são usadas para fazer o input dos dados para os Handlers.

3.  **Handlers para Processar Comandos e Consultas:**
    -   GetProductByIdQueryHandler
    -   GetProductsQueryHandler
    -   ProductCreateCommandHandler
    -   ProductUpdateCommandHandler
    -   ProductRemoveCommandHandler

Essas classes devem implementar a interface `IRequestHandler<Request, Response>`, que trata o respectivo comando. No método `Handle`, definimos o comando a ser processado e o retorno esperado.

4.  **Serviço ProductService:**
    
    -   Injetar a instância do Mediatr (`IMediator`). O padrão Mediator receberá um request e invocará o handler associado a ele.
5.  **Mapeamento de DTOs:**
    
    -   Definir um novo mapeamento de DTOs para os DTOs dos comandos e consultas criados.

Ao seguir esses passos, implementamos o padrão CQRS no projeto, proporcionando uma separação clara entre comandos e consultas, aumentando a flexibilidade e facilitando o tratamento de diferentes operações. O uso do padrão Mediator contribui para o desacoplamento e a organização do código. 🚀


#   Fluxo sem CQRS 
[![](https://mermaid.ink/img/pako:eNpVjsFugzAMhl8l8pmikEAROVQqsHOltqeRHiLI1mgkQWmYxoB3X4o0TbvZ_j7_9gyt7SQweHdiuKNrzQ1Cx6ayxjvb99Ld0G53WOrraUFlc5HuU7Xy9pTKDbwYr_y0oKo5y8E-lLdu2nD1D5d_G1vUESLQ0mmhunB7flIO_i615MBC2Qn3wYGbNXhi9PYymRaYd6OMYBw64WWtRHhZA3sT_SNMB2FerdW_UmiBzfAFjCY4ThOc5JgUhJJsTyOYgBVpjCnNi5zkaUKydL9G8L0F4DhbfwBba1Za?type=png)](https://mermaid-js.github.io/mermaid-live-editor/edit#pako:eNpVjsFugzAMhl8l8pmikEAROVQqsHOltqeRHiLI1mgkQWmYxoB3X4o0TbvZ_j7_9gyt7SQweHdiuKNrzQ1Cx6ayxjvb99Ld0G53WOrraUFlc5HuU7Xy9pTKDbwYr_y0oKo5y8E-lLdu2nD1D5d_G1vUESLQ0mmhunB7flIO_i615MBC2Qn3wYGbNXhi9PYymRaYd6OMYBw64WWtRHhZA3sT_SNMB2FerdW_UmiBzfAFjCY4ThOc5JgUhJJsTyOYgBVpjCnNi5zkaUKydL9G8L0F4DhbfwBba1Za)

# Fluxo com CQRS

[![](https://mermaid.ink/img/pako:eNptj09rhDAQxb9KmLMr_l0xh8KqC72UQndP1T0EM-2G1URiLLXqd282UGiht5n5vXnzZoFWcQQK75oNV3KuGknIoS6VNFp1HeoL2e0e1ur8vJKiPqH-EC1e7qLCgSfkghmlV1LWj0xyuzE6XDp8lEaYeSVV_YKDGoVVzg5Xf3Dxn-HBRfl1HjzoUfdMcJt3udMGzBV7bIDakjN9a6CRm9WxyajTLFugRk_owTRwZrASzL7ZA31j3WinA5OvSvU_ItsCXeATaBwGfhIGYRZEeRRH6T72YAaaJ34Qx1meRVkSRmmy3zz4cgaBn27f27ZnbA?type=png)](https://mermaid-js.github.io/mermaid-live-editor/edit#pako:eNptj09rhDAQxb9KmLMr_l0xh8KqC72UQndP1T0EM-2G1URiLLXqd282UGiht5n5vXnzZoFWcQQK75oNV3KuGknIoS6VNFp1HeoL2e0e1ur8vJKiPqH-EC1e7qLCgSfkghmlV1LWj0xyuzE6XDp8lEaYeSVV_YKDGoVVzg5Xf3Dxn-HBRfl1HjzoUfdMcJt3udMGzBV7bIDakjN9a6CRm9WxyajTLFugRk_owTRwZrASzL7ZA31j3WinA5OvSvU_ItsCXeATaBwGfhIGYRZEeRRH6T72YAaaJ34Qx1meRVkSRmmy3zz4cgaBn27f27ZnbA)

OBS :  

- usar o pacote MediatR
```c#
var assembly = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
             services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);
            });
```



## Considerações sobre a implementação

A implementação do CQRS foi feita usando uma abordagem bem mais simples

Foi feita apenas para uma parte do domínio: Product

Não usamos mensagens para processar comandos e publicar os eventos de atualização

Não foi usado outro padrão como o Event Sourcing

Usamos apenas o padrão Mediator, mas podemos implementar sem usar este padrão

Os comandos implementados estão retornando um valor: Product

Porque a implementação do CQRS foi feita na camada Application

-   No nosso contexto, comandos e consultas estão atuando como métodos do serviço e são clientes do projeto Domain que retornam uma visão otimizada do domínio

Poderíamos implementar o CQRS na camada Domain

-   Modelo de domínio mais complexos
-   Realizar a validação a nível de comando e consulta
