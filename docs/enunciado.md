# Atividade Avaliativa com Bônus — Polimorfismo em C 

Esta atividade tem como objetivo consolidar o estudo de polimorfismo em C#, exigindo que cada aluno analise um problema, abstraia corretamente os elementos do domínio, identifique propriedades e comportamentos comuns, crie uma estrutura hierárquica coerente e aplique polimorfismo na execução do sistema. Cada aluno deverá implementar o problema individual recebido, criando uma solução em C# com separação mínima entre domínio e execução. A implementação deverá conter uma estrutura orientada a objetos consistente, com classe base abstrata, classes concretas especializadas, propriedades comuns, propriedades específicas, métodos abstratos e/ou virtuais, sobrescrita de métodos com override , lista polimórfica e teste da execução no Program.cs . A entrega deve ser realizada até o final da aula por meio de um repositório no GitHub. Após finalizar a implementação, o aluno deverá chamar o professor para apresentar o funcionamento do projeto. A entrega funcional, organizada e coerente com os princípios de polimorfismo poderá gerar até 0,5 ponto de bônus. O aluno que desejar concorrer a mais 0,5 ponto de bônus deverá gravar, até sexta-feira, um vídeo em formato de apresentação ou seminário. Esse vídeo deverá demonstrar os princípios relacionados ao polimorfismo no problema implementado, explicando a abstração criada, a hierarquia de classes, os métodos comuns, os comportamentos sobrescritos, o uso da lista polimórfica e a execução do sistema. 

## Requisitos obrigatórios para todos os problemas 

A solução deve conter, no mínimo: 
Uma solução C# com dois projetos: um projeto de biblioteca de classes para o domínio; um projeto console para execução e teste. 
Uma classe base abstrata representando a abstração principal do domínio. 
Pelo menos quatro classes concretas derivadas da classe base. 
Propriedades comuns na classe abstrata, com validações no construtor. 
Pelo menos uma propriedade específica em cada classe concreta. 
Pelo menos um método abstrato que obrigue cada classe concreta a implementar seu próprio comportamento. 
Pelo menos um método concreto na classe abstrata, reutilizado pelas classes derivadas. 
Uma classe de serviço responsável por armazenar os objetos em uma coleção polimórfica. 
Uso de List<T> com o tipo da classe abstrata. 
Execução no Program.cs criando objetos concretos diferentes, adicionando-os à coleção e chamando os métodos polimórficos. 
Ausência de if , else if ou concreto do objeto. switch para decidir comportamento com base no tipo 
Organização clara de pastas, classes e responsabilidades. 
Comentários ou documentação breve explicando a abstração escolhida e a lógica da hierarquia.

## Problema

Você deverá implementar um sistema para controlar diferentes produtos em estoque. O sistema deve considerar produto perecível, produto eletrônico, produto de limpeza e produto controlado. Todos os produtos possuem nome, código, quantidade e valor unitário, mas cada tipo possui regras próprias para calcular risco de estoque, gerar instrução de armazenamento e calcular valor total ajustado. 11A solução deve conter uma classe abstrata para produto e classes concretas para cada tipo. Cada classe concreta deve possuir pelo menos uma propriedade específica, como data de validade, garantia, composição química ou exigência de autorização. No Program.cs , crie uma lista polimórfica de produtos e gere um relatório de estoque. O relatório deve exibir valor ajustado, risco e instrução de armazenamento para cada produto.