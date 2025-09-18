# ProjetoLokus

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.2.16.

> API desenvolvida em **C# .NET** com **Entity Framework** e **SQL Server**, responsável pela comunicação e regras de negócio do Projeto Lokus.

## Funcionalidades:
 - Cadastro e autenticação de usuários
 - Gerenciamento de esstabelecimentos, espaços
 - Em desenvolvimento: integração de imagens, mensagens, controle de feedback
 - 
## Tecnologias

 - C# .NET
 - ASP .NET Core
 - JWT + Bcrypt
 - Sql Server
 - Swagger (para a documentação da API)

### Outros
 - Git e Github

## Instalação

### 1. Clone o repositório
git clone https://github.com/SEU-USUARIO/ProjetoLokus-Backend.git

### 2. Entre na pasta do backend
cd ProjetoLokus-Backend

### 3. Configure a string de conexão no arquivo **appsettings.json**
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LokusDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
> Ajuste conforme o seu ambiente (usuário/senha/porta do SQL Server).

### 4. Crie ou atualize o banco de dados 
add-migration INSIRADESCRICAO
update-database 

### 5. Rodar aplicação
dotnet run

### 6. A API está disponível em
http://localhost:7101 ou http://localhost:5101

### 7. Acessar a documentação com Swagger (se configurado):
http://localhost:7101/swagger

## Estrutura do projeto
ProjetoLokus-Backend/
 ├── Controllers/        # Endpoints da API
 ├── Models/             # Modelos das entidades
 ├── Data/               # DbContext e Migrations
 ├── Services/           # Regras de negócio
 ├── Program.cs          # Configuração principal
 ├── appsettings.json    # Configurações de ambiente

# Licença Acadêmica

Este projeto foi desenvolvido para o trabalho final do curso de C#, do programa Entra21 em Blumenau(Santa Catarina, Brasil), do ano 2025.

- Não é permitida a utilização deste projeto para fins **comerciais ou de distribuição**.  
- Qualquer reprodução ou modificação deve manter a referência aos autores originais.  
