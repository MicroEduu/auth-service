# Guia de Configuração e Execução do AuthService

Este documento apresenta um guia completo para configurar e executar o microserviço de autenticação (AuthService) em sua máquina local de forma rápida e eficiente.

Este microserviço é responsável pela autenticação de usuários e geração de tokens de acesso para o sistema. Todas as rotas, exceto a de obtenção de token, e a criação do usuário requerem autenticação.

## Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas em seu sistema:

| Ferramenta   | Versão Mínima | Link de Download                                 |
|--------------|---------------|--------------------------------------------------|
| **.NET SDK** | 8.0+          | [Download .NET](https://dotnet.microsoft.com/download) |
| **Git**      | Latest        | [Download Git](https://git-scm.com/downloads)    |

> **Dica:** Verifique as versões instaladas executando `dotnet --version` e `git --version`

## Início Rápido

### 1️⃣ Clonar o Repositório

```bash
git clone https://github.com/MicroEduu/auth-service
cd AuthService
```

### 2️⃣ Configurar a Solução

Se necessário, crie e configure o arquivo de solução:

```bash
# Criar arquivo de solução (se não existir)
dotnet new sln

# Adicionar projeto à solução
dotnet sln AuthService.sln add AuthService.csproj
```

### 3️⃣ Instalar Ferramentas Necessárias

Instale a ferramenta global do Entity Framework:

```bash
# Instalação inicial
dotnet tool install --global dotnet-ef

# Ou atualizar se já estiver instalada
dotnet tool update --global dotnet-ef
```

### 4️⃣ Configurar Banco de Dados

Execute as migrações para preparar o banco SQLite:

```bash
dotnet ef database update
```

### 5️⃣ Executar a Aplicação

```bash
dotnet run
```

🎉 **AuthService iniciado com sucesso!**

A aplicação estará disponível em:
- 🌐 **HTTP:** http://localhost:5089/swagger/index.html

# 📌 Rotas da API

## 🔓 Rotas Públicas (sem token)

| Método | Endpoint           | Descrição                                 |
|--------|--------------------|-------------------------------------------|
| POST   | /api/User/create   | Cria um novo usuário (cadastro).          |
| POST   | /api/Auth/login    | Obtém um token de autenticação do usuário.|

### Exemplo de requisição para criar usuário:

```json
POST /api/User/create
{
  "email": "usuario@exemplo.com",
  "password": "senha123",
  "firstName": "João",
  "lastName": "Silva",
  "role": 1
}
```

### Exemplo de resposta do login:

```json
{
  "token": "kzD8@9sVmT4l!dR3FzG6pQ1uLbXeY2Jh"
}
```

---

## 🔒 Rotas Protegidas (com token)

| Método | Endpoint                  | Descrição                                         |
|--------|---------------------------|---------------------------------------------------|
| PUT    | /api/User/{id}            | Atualiza dados do usuário.                        |
| GET    | /api/User                 | Lista todos os usuários.                          |
| GET    | /api/User/{id}            | Busca usuário por ID.                             |
| DELETE | /api/User/Delete/{id}     | Remove um usuário.                                |
| PATCH  | /api/User/Deactivate/{id} | Inativa um usuário.                               |
| GET    | /api/Auth/user-info       | Retorna informações do usuário com base no token. |

> Para acessar rotas protegidas, inclua o token no header `Authorization`:
>
> `Authorization: Bearer <token_aqui>`

---

## 🛠️ Observações

- O token acima é um exemplo fixo para fins de teste.
- Para produção, seria utilizado um mecanismo seguro de geração e validação de tokens.


