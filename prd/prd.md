# PRD — Sistema de Controle de Estoque com Polimorfismo

## Visão Geral
O sistema deve controlar produtos em estoque utilizando polimorfismo em C#. A solução será composta por:
- Um projeto de biblioteca de classes para o domínio.
- Um projeto console para execução e teste.

O objetivo é representar diferentes tipos de produtos de forma abstrata e reaproveitar comportamento comum, mantendo regras específicas em cada classe derivada.

## Problema
Controlar diferentes produtos em estoque, considerando:
- produto perecível
- produto eletrônico
- produto de limpeza
- produto controlado

Todos os produtos têm:
- nome
- código
- quantidade
- valor unitário

Cada tipo de produto deve calcular:
- risco de estoque
- instrução de armazenamento
- valor total ajustado

## Público-alvo
Estudantes e professores que avaliam conceitos de programação orientada a objetos e polimorfismo em C#.

## Principais Requisitos
1. Projeto em C# com dois projetos:
   - biblioteca de classes para o domínio
   - projeto console para execução e relatório
2. Classe base abstrata `Produto`.
3. Pelo menos quatro classes concretas derivadas:
   - `ProdutoPerecivel`
   - `ProdutoEletronico`
   - `ProdutoLimpeza`
   - `ProdutoControlado`
4. Propriedades comuns na classe abstrata:
   - `Nome`
   - `Codigo`
   - `Quantidade`
   - `ValorUnitario`
5. Validações no construtor da classe abstrata para garantir dados válidos.
6. Cada classe concreta deve ter ao menos uma propriedade específica:
   - `DataValidade` em `ProdutoPerecivel`
   - `GarantiaMeses` em `ProdutoEletronico`
   - `ComposicaoQuimica` em `ProdutoLimpeza`
   - `RequerAutorizacao` em `ProdutoControlado`
7. Um método abstrato obrigatório na abstração principal para comportamento específico.
8. Um método concreto na classe abstrata reutilizado por todas as classes derivadas.
9. Classe de serviço para armazenar produtos em coleção polimórfica.
10. Uso de `List<Produto>`.
11. Execução em `Program.cs` criando objetos concretos, adicionando-os à coleção e submetendo-os a métodos polimórficos.
12. Sem uso de `if`, `else if` ou `switch` para decidir comportamento por tipo de objeto.
13. Organização clara de pastas e classes.
14. Comentários ou documentação explicando abstração e hierarquia.

## Funcionalidades
### Comum a todos os produtos
- armazenar nome, código, quantidade e valor unitário
- calcular valor total bruto
- gerar relatório com valor ajustado, risco e instrução de armazenamento

### Produto Perecível
- propriedade específica: `DataValidade`
- cálculo de risco baseado em proximidade da validade
- instrução de armazenamento refrigerado ou ambiente controlado
- valor ajustado com desconto por risco de perecibilidade

### Produto Eletrônico
- propriedade específica: `GarantiaMeses`
- cálculo de risco por obsolescência ou fragilidade
- instrução de armazenamento em local seco e protegido
- valor ajustado considerando seguro ou depreciação

### Produto de Limpeza
- propriedade específica: `ComposicaoQuimica`
- cálculo de risco baseado em composição e perigo químico
- instrução de armazenamento em local ventilado e afastado de alimentos
- valor ajustado com custo de manuseio/segurança

### Produto Controlado
- propriedade específica: `RequerAutorizacao`
- cálculo de risco por exigência legal e controle
- instrução de armazenamento seguro e restrito
- valor ajustado considerando taxas ou exigências regulatórias

## Critérios de Aceitação
- [ ] Existência de classe base `Produto` abstrata.
- [ ] Quatro ou mais classes concretas derivadas.
- [ ] Propriedades comuns validadas no construtor.
- [ ] Propriedade específica em cada classe concreta.
- [ ] Método abstrato implementado em cada classe derivada.
- [ ] Método concreto reutilizado por todas as classes.
- [ ] Lista polimórfica de produtos em `List<Produto>`.
- [ ] Sem `if`, `else if` ou `switch` para comportamento de tipo.
- [ ] Relatório no `Program.cs` com valor ajustado, risco e instrução de armazenamento.
- [ ] Estrutura de projetos e classes organizada.

## Regras de Negócio
- Produtos sempre devem ter nome e código não vazios.
- Quantidade deve ser maior que zero.
- Valor unitário deve ser maior ou igual a zero.
- Cada tipo de produto implementa seu próprio cálculo de risco e instrução.
- O relatório exibe os valores ajustados e comportamentos polimórficos sem ramificações de tipo.

## Estrutura de Implementação
### Domínio
- `Produto` (classe abstrata)
- `ProdutoPerecivel` : `Produto`
- `ProdutoEletronico` : `Produto`
- `ProdutoLimpeza` : `Produto`
- `ProdutoControlado` : `Produto`
- `EstoqueService` (ou similar) para gerenciar `List<Produto>`

### Execução
- `Program.cs` cria instâncias concretas
- adiciona as instâncias à lista polimórfica
- itera sobre a lista chamando métodos comuns e polimórficos
- exibe relatório formatado no console

## Documentação e Apresentação
- Incluir comentários explicando a abstração `Produto` e a hierarquia de classes.
- Demonstrar o uso de polimorfismo no relatório de estoque.
- Opcional: gravar vídeo explicando a solução para bônus.
