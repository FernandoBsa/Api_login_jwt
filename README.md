# Aplicacao de Login com JWT

Esta é uma aplicação de exemplo que demonstra como implementar um sistema de autenticação usando JWT (JSON Web Tokens) com Entity Framework Core, Migrations, Injeção de Dependência (DI) e uma arquitetura organizada.

## Arquitetura do Projeto

A aplicação está organizada em várias camadas, seguindo uma estrutura limpa e modular:

```
Apl_login_jwt/
├── Data/
│   ├── Context/
│   ├── Migrations/
│   ├── Repository/
│   └── Data.csproj
├── Domain/
│   ├── DTO/
│   ├── Entity/
│   ├── Interfaces/
│   └── Domain.csproj
├── Services/
│   ├── Authentication/
│   ├── AutoMapper/
│   ├── Interface/
│   ├── Request/
│   ├── Response/
│   ├── Results/
│   ├── Service/
│   └── Services.csproj
├── WebApi/
│   ├── Controllers/
│   ├── Extensions/
│   ├── Properties/
│   ├── Program.cs
│   └── WebApi.csproj
├── WebApi.http
├── Apl_login_jwt.sln
├── global.json
└── .gitignore
```

### Descrição das Camadas

1. **Data**:

   - Contém o contexto do Entity Framework (`Context/`) e as migrações (`Migrations/`).
   - Inclui repositórios para acesso a dados (`Repository/`).

2. **Domain**:

   - Define as entidades do domínio (`Entity/`), DTOs (`DTO/`) e interfaces (`Interfaces/`).

3. **Services**:

   - Implementa a lógica de negócios, incluindo autenticação (`Authentication/`), mapeamento com AutoMapper (`AutoMapper/`), e serviços (`Service/`).

4. **WebApi**:

   - Contém os controladores da API (`Controllers/`), extensões (`Extensions/`), e o ponto de entrada da aplicação (`Program.cs`).

## Tecnologias Utilizadas

- **Entity Framework Core**: Para acesso a dados e gerenciamento de migrações.
- **JWT (JSON Web Tokens)**: Para autenticação e geração de tokens seguros.
- **Injeção de Dependência (DI)**: Para gerenciar dependências e promover a testabilidade.
- **AutoMapper**: Para mapeamento de objetos entre DTOs e entidades.
- **ASP.NET Core**: Para construção da API Web.

## Como Executar o Projeto

Clone o repositório:

```bash
git clone https://github.com/seu-usuario/Apl_login_jwt.git
```

Navegue até o diretório do projeto:

```bash
cd Apl_login_jwt
```

Restaure as dependências:

```bash
dotnet restore
```

Execute as migrações:

```bash
dotnet ef database update
```

Inicie a aplicação:

```bash
dotnet run --project WebApi/WebApi.csproj
```

Acesse a API em `http://localhost:5000` (ou a porta configurada).

## Licença

Este projeto está licenciado sob a MIT License.

