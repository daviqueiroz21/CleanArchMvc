
# CleanArchMvc - Projeto de Catálogo de Produtos

## Escopo Geral

### Objetivo

O projeto CleanArchMvc tem como objetivo criar uma aplicação web utilizando ASP.NET Core MVC para o gerenciamento de produtos e categorias, proporcionando a criação de um catálogo de produtos para vendas.

### Ferramentas Utilizadas

-   Visual Studio Community (ou VS Code)
-   ASP.NET Core MVC
-   Entity Framework Core
-   SQL Server

## Estrutura do Projeto

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

## Regras de Negócio do Produto

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

## Regras de Negócio da Categoria

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

## Persistência dos Dados

-   Banco de dados relacional: SQL Server.
-   ORM: Entity Framework Core.
-   Abordagem Code-First.
-   Provedor do banco de dados: Microsoft.EntityFrameworkCore.SqlServer.
-   Ferramenta para aplicar Migrations: Microsoft.EntityFrameworkCore.Tools.
-   Desacoplamento da camada de acesso a dados do ORM usando o padrão Repository.

## Nomenclatura

-   CamelCase: `valorDoDesconto`, `nomeCompleto`.
-   PascalCase: `CalculaImpostoDeRenda`, `ValorDoDesconto`.
-   Classes: PascalCase.
-   Interfaces: `I` + PascalCase.
-   Métodos, Propriedades: PascalCase.
-   Variáveis, Parâmetros: camelCase.
-   Constantes: Maiúsculo + sublinhado.

## Estrutura do Projeto CleanArchMvc

-   CleanArchMvc.Domain: Sem dependências.
-   CleanArchMvc.Application: Dependência com CleanArchMvc.Domain.
-   CleanArchMvc.Infra.Data: Dependência com CleanArchMvc.Domain.
-   CleanArchMvc.Infra.IoC: Dependência com CleanArchMvc.Domain, CleanArchMvc.Application, CleanArchMvc.Infra.Data.
-   CleanArchMvc.WebUI: Dependência com CleanArchMvc.Infra.IoC.

## Testes de Unidade

-   Idioma: Inglês.
-   Nome do teste: `<Método ou Classe>_<Cenário de Teste>_<Resultado Esperado>`.

Exemplo:

csharpCopy code

`[Fact(DisplayName="Create Category Object With Valid State")]
public void CreateProduct_WithValidParameters_ResultObjectValidState()
{
    Action action = () => new Category(1, "Category Name");
    action.Should()
        .NotThrow<DomainExceptionValidation>();
}` 

## Configuração de Entidades do Modelo

A configuração das entidades do modelo é realizada utilizando a Fluent API do Entity Framework Core para evitar problemas de mapeamento automático, garantindo maior controle sobre o esquema do banco de dados.

## Registro de Serviços no Contêiner IoC

-   Lifetimes: Transient, Scoped, Singleton.
-   Registro de serviços para injeção de dependência.

## EF Core Migrations

-   Atualização incremental do esquema do banco de dados.
-   Manutenção da sincronia com o modelo de dados do aplicativo.
-   Geração de migrações para versionamento do banco de dados.
-   Comparação do modelo atual com um instantâneo do modelo antigo.

## Restrição de Acesso e Exposição de Informações

-   Utilização de Data Transfer Objects (DTOs) para restringir acesso e exposição de informações específicas.
-   Evolução independente do modelo de entidades e dos DTOs.

## Serviços da Camada Application

-   Comunicação com a camada de domínio representada pelo projeto Domain# CleanArchMvc - Projeto de Catálogo de Produtos

## Escopo Geral

### Objetivo

O projeto CleanArchMvc tem como objetivo criar uma aplicação web utilizando ASP.NET Core MVC para o gerenciamento de produtos e categorias, proporcionando a criação de um catálogo de produtos para vendas.

### Ferramentas Utilizadas

-   Visual Studio Community (ou VS Code)
-   ASP.NET Core MVC
-   Entity Framework Core
-   SQL Server

## Estrutura do Projeto

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

## Regras de Negócio do Produto

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

## Regras de Negócio da Categoria

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

## Persistência dos Dados

-   Banco de dados relacional: SQL Server.
-   ORM: Entity Framework Core.
-   Abordagem Code-First.
-   Provedor do banco de dados: Microsoft.EntityFrameworkCore.SqlServer.
-   Ferramenta para aplicar Migrations: Microsoft.EntityFrameworkCore.Tools.
-   Desacoplamento da camada de acesso a dados do ORM usando o padrão Repository.

## Nomenclatura

-   CamelCase: `valorDoDesconto`, `nomeCompleto`.
-   PascalCase: `CalculaImpostoDeRenda`, `ValorDoDesconto`.
-   Classes: PascalCase.
-   Interfaces: `I` + PascalCase.
-   Métodos, Propriedades: PascalCase.
-   Variáveis, Parâmetros: camelCase.
-   Constantes: Maiúsculo + sublinhado.

## Estrutura do Projeto CleanArchMvc

-   CleanArchMvc.Domain: Sem dependências.
-   CleanArchMvc.Application: Dependência com CleanArchMvc.Domain.
-   CleanArchMvc.Infra.Data: Dependência com CleanArchMvc.Domain.
-   CleanArchMvc.Infra.IoC: Dependência com CleanArchMvc.Domain, CleanArchMvc.Application, CleanArchMvc.Infra.Data.
-   CleanArchMvc.WebUI: Dependência com CleanArchMvc.Infra.IoC.

## Testes de Unidade

-   Idioma: Inglês.
-   Nome do teste: `<Método ou Classe>_<Cenário de Teste>_<Resultado Esperado>`.

Exemplo:

csharpCopy code

`[Fact(DisplayName="Create Category Object With Valid State")]
public void CreateProduct_WithValidParameters_ResultObjectValidState()
{
    Action action = () => new Category(1, "Category Name");
    action.Should()
        .NotThrow<DomainExceptionValidation>();
}` 

## Configuração de Entidades do Modelo

A configuração das entidades do modelo é realizada utilizando a Fluent API do Entity Framework Core para evitar problemas de mapeamento automático, garantindo maior controle sobre o esquema do banco de dados.

## Registro de Serviços no Contêiner IoC

-   Lifetimes: Transient, Scoped, Singleton.
-   Registro de serviços para injeção de dependência.

## EF Core Migrations

-   Atualização incremental do esquema do banco de dados.
-   Manutenção da sincronia com o modelo de dados do aplicativo.
-   Geração de migrações para versionamento do banco de dados.
-   Comparação do modelo atual com um instantâneo do modelo antigo.

## Restrição de Acesso e Exposição de Informações

-   Utilização de Data Transfer Objects (DTOs) para restringir acesso e exposição de informações específicas.
-   Evolução independente do modelo de entidades e dos DTOs.

## Serviços da Camada Application

-   Comunicação com a camada de domínio representada pelo projeto Domain
