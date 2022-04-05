PT-BR

# **Criação de um projeto Kanban**

Este é um projeto em desenvolvimento para estudo e treinamento em uma formação inicial de programação em C# .NET, onde a entrega do mesmo é dividida em 3, que seguem abaixo:

## v0.1 - Primeira entrega: Implementação de todas as entidades do projeto (Usuários, Cartões e Sprints)

Nesta primeira entrega, foi feito a criação das entidades que serão utilizadas no projeto e suas ligações.
Criou-se os arquivos: 

- User.cs

Aqui foram criados todas as propriedades necessárias para a criação do usuário. São elas:

1. Id - Identificador de cada usuário;
2. Name - Nome de cada usuário.

- Sprint.cs

1. Id - Identificador de cada Sprint;
2. Name - Nome de cada string.

- Card.cs

1. Id - Identificador de cada cartão;
2. Title - Título de cada cartão;
3. Description - Descrição do cartão;
4. UserId - Chave estrangeira da classe User;
5. Estimate - Estimativa de tempo de conclusão do cartão;
6. SprintId - Chave estrangeira da classe Sprint;
7. Status - Estado que o cartão se encontra: Não iniciado, em andamento ou finalizado.

## Segunda entrega: Implementação do banco de dados, migrations e criação das tabelas.

Nesta etapa foi feito a criação do banco de dados utilizando o Postgresql e ElephantSql. Através do auxílio do Entity Framework foi possível a configuração das tabelas que foram criadas a partir das propriedades das entidades User, Sprint e Card. Utilizando migration montou-se e atualizou-se as tabelas para as configurações necessárias.

Assim nesta etapa, através de um algoritmo provisório, é possível observar a criação e exclusão de cada entidade no banco de dados, já conectado a nuvem através do ElephantSql.

## Terceira entrega: Implementação completa do projeto, onde engloba todos onde endpoints da API.

Em andamento
