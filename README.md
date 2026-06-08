# Controle de Estoque com Polimorfismo em C# e Blazor

## Índice

1. [Visão geral](#visão-geral)
2. [Estrutura do trabalho](#estrutura-do-trabalho)
   1. [Projetos principais](#projetos-principais)
   2. [Arquivos e pastas importantes](#arquivos-e-pastas-importantes)
3. [O que existe no programa](#o-que-existe-no-programa)
   1. [Domínio](#domínio)
   2. [Persistência em memória](#persistência-em-memória)
   3. [Interface web](#interface-web)
4. [Regras de negócio implementadas](#regras-de-negócio-implementadas)
5. [Como executar](#como-executar)
   1. [Requisitos](#requisitos)
   2. [Passos](#passos)
   3. [Acesso](#acesso)
6. [Autor e informações](#autor-e-informações)
7. [Notas adicionais](#notas-adicionais)

## Visão geral

Este repositório contém um sistema de controle de estoque desenvolvido para demonstrar conceitos de orientação a objetos e polimorfismo em C#. A solução possui dois projetos principais:

- `src/TrabalhoPOOPolimorfismo.Domain`: biblioteca de domínio com entidades, regras de negócio e persistência em memória.
- `src/TrabalhoPOOPolimorfismo.Web`: aplicação web Blazor com interface de usuário moderna, menus laterais e relatórios.

A aplicação gerencia quatro tipos de produto:

- Produto perecível
- Produto eletrônico
- Produto de limpeza
- Produto controlado

Cada tipo possui características e cálculos específicos para risco, instrução de armazenamento e valor ajustado.

## Estrutura do trabalho

### Projetos principais

- `src/TrabalhoPOOPolimorfismo.Domain`
- `src/TrabalhoPOOPolimorfismo.Web`

### Arquivos e pastas importantes

- `src/TrabalhoPOOPolimorfismo.Domain/Domain/Entities`
  - `Produto.cs`
  - `ProdutoPerecivel.cs`
  - `ProdutoEletronico.cs`
  - `ProdutoLimpeza.cs`
  - `ProdutoControlado.cs`
- `src/TrabalhoPOOPolimorfismo.Domain/Services/EstoqueService.cs`
- `src/TrabalhoPOOPolimorfismo.Domain/Infra/IRepositorioProdutos.cs`
- `src/TrabalhoPOOPolimorfismo.Domain/Infra/RepositorioProdutoInMemory.cs`

- `src/TrabalhoPOOPolimorfismo.Web/Program.cs`
- `src/TrabalhoPOOPolimorfismo.Web/TrabalhoPOOPolimorfismo.Web.csproj`
- `src/TrabalhoPOOPolimorfismo.Web/Components/App.razor`
- `src/TrabalhoPOOPolimorfismo.Web/Components/Routes.razor`
- `src/TrabalhoPOOPolimorfismo.Web/Components/Layout/MainLayout.razor`
- `src/TrabalhoPOOPolimorfismo.Web/Components/Layout/NavMenu.razor`
- `src/TrabalhoPOOPolimorfismo.Web/Components/Pages/Home.razor`
- `src/TrabalhoPOOPolimorfismo.Web/Components/Pages/Products.razor`
- `src/TrabalhoPOOPolimorfismo.Web/Components/Pages/Relatorios.razor`
- `src/TrabalhoPOOPolimorfismo.Web/Services/EstoqueState.cs`
- `src/TrabalhoPOOPolimorfismo.Web/Services/ProdutoTipo.cs`
- `src/TrabalhoPOOPolimorfismo.Web/wwwroot/app.css`
- `src/TrabalhoPOOPolimorfismo.Web/Properties/launchSettings.json`

## O que existe no programa

### Domínio

A camada de domínio possui uma classe abstrata `Produto` que define as propriedades e comportamentos comuns de todos os produtos.

Propriedades comuns:

- `Nome`
- `Codigo`
- `Quantidade`
- `ValorUnitario`

Métodos abstratos implementados por cada tipo concreto:

- `CalcularRiscoEstoque()`
- `ObterInstrucaoArmazenamento()`
- `CalcularValorTotalAjustado()`

Tipos concretos de produto:

- `ProdutoPerecivel`
- `ProdutoEletronico`
- `ProdutoLimpeza`
- `ProdutoControlado`

Cada classe concreta possui pelo menos uma propriedade específica e regras únicas de cálculo.

### Persistência em memória

A persistência é feita em memória por meio de uma implementação de repositório:

- `RepositorioProdutoInMemory` armazena os produtos em uma `List<Produto>`.
- `EstoqueService` encapsula o repositório e fornece métodos de adição e leitura.

O estado é mantido apenas enquanto a aplicação está em execução.

### Interface web

A aplicação Blazor apresenta:

- Dashboard inicial com métricas e indicadores.
- Página de cadastro de produtos com campos dinâmicos conforme o tipo selecionado.
- Listagem de produtos com informações de risco, instrução de armazenamento e valores bruto/ajustado.
- Página de relatórios com resumo por tipo e tabela detalhada.
- Menu lateral colorido e navegação amigável.

## Regras de negócio implementadas

- Produtos devem ser criados com dados válidos.
- `Quantidade` deve ser maior que zero.
- `ValorUnitario` deve ser maior ou igual a zero.
- `ProdutoPerecivel` calcula risco e ajuste com base na validade.
- `ProdutoEletronico` aplica depreciação em função da garantia.
- `ProdutoLimpeza` altera risco e valor conforme a composição química.
- `ProdutoControlado` utiliza autorização para risco e ajuste de preço.
- O domínio não depende de `if`/`else` para decisão de tipo centralizada.
- A coleção polimórfica de produtos preserva o conceito de herança e polimorfismo.

## Como executar

### Requisitos

- .NET 9 SDK instalado
- Navegador moderno

### Passos

1. No terminal, abra a pasta do projeto web:

```powershell
cd src\TrabalhoPOOPolimorfismo.Web
```

2. Execute o servidor Blazor:

```powershell
dotnet watch run
```

### Acesso

Abra no navegador:

```text
http://localhost:5002
```

### Observações

- A aplicação usa persistência em memória, então os produtos cadastrados são perdidos ao reiniciar.
- O template Blazor utilizado foi o `blazor` do .NET SDK.

## Autor e informações

- Nome: Nilseo Cassol
- Projeto: Controle de estoque com polimorfismo em C# e Blazor
- Objetivo: demonstrar abstração, herança e polimorfismo em um sistema de estoque.

## Notas adicionais

- A interface foi construída com foco em usabilidade, cores e organização.
- A separação entre domínio e apresentação segue boas práticas.
- O projeto está pronto para apresentação, teste e uso local.
