# ASPNET-Core_API-RESTFUL
Curso Alura - Projeto em ASPNET Core 5.0 utilizando API com arquitetura RESTUFUL

### Artifícios em Destaque
> * Desenvolvido em ASPNET Core com DotNet 5.0
> * API com arquitetura RESTFUL
> * Comunicação com o banco de dados local através do EntityFrameworkCore
> * Código organizado em funções (Padrão MVC) e de fácil entendimento
> * Auxílio do POSTMAN para requisições HTTP
> * Utilização do AutoMapper para facilitar o mapeamento dos dados;
> * Utilização de DTO (Data Transfer Objects)
> * Alta delegação de responsabilidades;
> * Entidades Filme, Endereço, Gerente e Cinema;

### Alterações Feitas
### (v01.01)
> * O EF Core é um framework para gerar entidades e relacionamentos;
> * O conceito de relacionamentos;

### (v01.02)
> * Relacionamento 1:1;
> * ModelBuilder para explicitar como o relacionamento será estabelecido.
> * Lazy Properties (Carregar informações de uma entidade que é propriedade de outra);

### (v01.03)
> * Relacionamento 1:n;
> * Problemas de loops de informações (JsonIgnore e AutoMapper);
> * Modos de deleção (Restrito ou em Cascata);
> * Tornar um atributo de chave estrangeira opcional;

### (v01.04)
> * Relacionamento n para n;
> * Gerar um relacionamento de n para n com o Entity;
> * Criação de um modelo para representar o relacionamento;
> * Utilização do AutoMapper para calcular informações a partir de entidades diferentes em tempo de execução;

### (v01.05)
> * Envio e recuperação de parâmetros pela URL;    
> * Consultas através do encadeamento de métodos;
> * Consultas em LINQ.

### (v01.06)
> * Delegação de responsabilidades. Controlador x Service;
> * Refatoração;
> * Criação de Services para cada controller;
> * Retorno de métodos objetivos;

### (v01.07)
> * Identity (CRUD de usuários);
> * Integração do Identity com o Entity;
> * Configuração do Identity;

### (v01.08)
> * SignInManager para login e logout do usuário;
> * Criação e personalização de Tokens;    
> * Trafegar informações no FluentResults;

### (v01.09)
> * Bloqueio do login sem contas confirmadas através do Identity;
> * Código de ativação ao cadastrar a conta;
> * Fluxo para confirmar a conta de um usuário;
> * Tráfego de informações pelo Fluent.Results;

### (v01.10)
> * Envio de e-mails para os usuários através do .NET;
> * Abrir conexão com o servidor de e-mails através do MailKit;
> * Geração de uma mensagem de e-mail através do MimeKit;
> * Carregar informações de configuração através da interface IConfiguration;
> * Link de ativação da conta enviada por e-mail;