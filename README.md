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