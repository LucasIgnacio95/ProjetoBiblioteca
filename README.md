# Sistema de Biblioteca 📚

Este é um projeto de um sistema de gerenciamento de biblioteca, desenvolvido em ASP.NET Core MVC. A aplicação permite o cadastro de livros, usuários e o controle de empréstimos, com um sistema de autenticação e diferenciação de níveis de acesso entre usuários Padrão e Administradores.

## ✨ Funcionalidades

* **Autenticação de Usuários:** Sistema de login seguro com senha criptografada.
* **Controle de Acesso:** Diferenciação entre usuários **Administradores** e **Padrão**.
    * Administradores têm acesso ao cadastro e gerenciamento de outros usuários.
* **Gerenciamento de Livros (CRUD):**
    * Cadastro, edição, listagem e exclusão de livros.
    * Sistema de filtro e busca na listagem.
* **Gerenciamento de Empréstimos (CRUD):**
    * Cadastro, edição e listagem de empréstimos.
    * Associação de um livro a um usuário em uma data específica.
    * Sistema de filtro na listagem de empréstimos.



## 🛠️ Tecnologias Utilizadas

* **Back-end:** C# com ASP.NET Core 8.0 MVC
* **Banco de Dados:** Microsoft SQL Server
* **ORM:** Entity Framework Core 8 com abordagem *Code First* (usando Migrations)
* **Front-end:** HTML, CSS, JavaScript e Bootstrap
* **Autenticação:** Gerenciamento de sessão (`HttpContext.Session`)

## 🚀 Como Executar o Projeto

Siga os passos abaixo para configurar e executar o projeto em seu ambiente de desenvolvimento.

### Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (Express, Developer ou outra edição)
* Um editor de código como [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/) ou [Visual Studio Code](https://code.visualstudio.com/).

### 1. Clonar o Repositório

```bash
git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)
cd seu-repositorio
```

### 2. Configurar a String de Conexão

Abra o arquivo `appsettings.json` na raiz do projeto. Você precisará ajustar a `DefaultConnection` para apontar para a sua instância do SQL Server.

O padrão está configurado para uma instância local chamada `LUCAS`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=LUCAS;Database=BibliotecaDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
}
```
**Altere `Server=LUCAS`** para o nome do seu servidor. Se você estiver usando o SQL Server Express padrão, o nome geralmente é `localhost\\SQLEXPRESS` ou `.\\SQLEXPRESS`.

### 3. Aplicar as Migrations (Criar o Banco de Dados)

Com a string de conexão configurada, o Entity Framework Core criará o banco de dados e todas as tabelas para você.

Abra um terminal na pasta do projeto e execute o seguinte comando:

```bash
dotnet ef database update
```
Isso irá criar o banco de dados `BibliotecaDB` com as tabelas `Livros`, `Usuarios` e `Emprestimos`.

### 4. Executar a Aplicação

Agora, basta executar o projeto:

```bash
dotnet run
```
A aplicação estará disponível em `http://localhost:5254` (ou outra porta definida no arquivo `launchSettings.json`).

### 🔑 Primeiro Acesso

A aplicação cria automaticamente um usuário **Administrador** no primeiro login, caso ele não exista:

* **Login:** `admin`
* **Senha:** `123`

Use essas credenciais para acessar o sistema pela primeira vez e começar a cadastrar novos usuários e livros.
