# TaskList API

## Sobre a Aplicação

A TaskList API é uma aplicação de gerenciamento de tarefas construída com .NET 9. Ela inclui uma arquitetura baseada em DDD (Domain-Driven Design) e utiliza SQL Server como banco de dados. A aplicação é configurada para rodar em contêineres Docker.

Este documento fornece instruções para configurar, construir e rodar a aplicação, bem como aplicar as migrações de banco de dados manualmente.

---

## Requisitos

Certifique-se de que os seguintes componentes estejam instalados:

    1. [Docker Desktop](https://www.docker.com/products/docker-desktop) (ou Docker CLI)
    2. [SDK do .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0) (opcional, para executar comandos locais)
    3. SQL Server Management Studio (SSMS) ou outro cliente SQL para verificar o estado do banco de dados (opcional).
    4. Ferramenta `dotnet-ef` instalada globalmente:
    ```bash
    dotnet tool install --global dotnet-ef
    ```
    Certifique-se de que o diretório de ferramentas globais do .NET está no seu PATH:
    ```bash
    export PATH="$PATH:$HOME/.dotnet/tools"
    ```

---

## Estrutura do Projeto

A aplicação possui a seguinte estrutura:

```
TaskList
├── src
│   ├── TaskList.Api              # Projeto principal da API
│   ├── TaskList.Application      # Regras da aplicação
│   ├── TaskList.Infrastructure   # Contém migrações e acesso ao banco
│   └── TaskList.Domain           # Entidades e lógica de domínio
├── docker-compose.yml            # Configuração do Docker Compose
└── Dockerfile                    # Configuração da imagem da API
```

---

## Configuração de Banco de Dados no `docker-compose.yml`

O `docker-compose.yml` está configurado para rodar um contêiner SQL Server.

### Exemplo de Configuração:
```yaml
services:
  api:
    build:
      context: .
      dockerfile: src/TaskList.Api/Dockerfile
    ports:
      - "5000:8080"
    depends_on:
      - db
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ConnectionStrings__DefaultConnection=Server=db,1433;Database=TaskList;User=sa;Password=6o2yBy=^b7p<;Encrypt=False;TrustServerCertificate=True;

  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    ports:
      - "1433:1433"
    environment:
      ACCEPT_EULA: "Y"
      SA_PASSWORD: "6o2yBy=^b7p<"
```

---

## Executando a Aplicação com Docker Compose

1. **Suba os contêineres:**
   
   No diretório raiz do projeto, execute:
   ```bash
   docker-compose up --build
   ```

2. **Verifique se os contêineres estão rodando:**
   ```bash
   docker ps
   ```
   Certifique-se de que os contêineres `api` e `db` estejam na lista.

---

## Aplicando as Migrações Manualmente

1. **Certifique-se de que a ferramenta `dotnet-ef` está instalada:**
   Execute o seguinte comando para instalar a ferramenta globalmente, caso ainda não tenha feito:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

2. **Acesse o contêiner da API:**
   ```bash
   docker exec -it <container_id> /bin/sh
   ```

   Substitua `<container_id>` pelo ID do contêiner da API, obtido pelo comando `docker ps`.

3. **Execute o comando de migração:**
   ```bash
   dotnet ef database update --project src/TaskList.Infrastructure --startup-project src/TaskList.Api
   ```

4. **Saia do contêiner:**
   ```bash
   exit
   ```

---

## Testando a API

Com as migrações aplicadas, a API estará acessível em:

```
http://localhost:5000
```

### Endpoints Disponíveis

    1. **GET /tasks** - Retorna todas as tarefas
    2. **POST /tasks** - Cria uma nova tarefa
    3. **PUT /tasks/{id}** - Atualiza uma tarefa existente
    4. **DELETE /tasks/{id}** - Remove uma tarefa

Use ferramentas como [Postman](https://www.postman.com/) ou [cURL](https://curl.se/) para testar os endpoints.

---

## Encerrando os Contêineres

Para parar e remover os contêineres:

```bash
docker-compose down
```

---

Com isso, a TaskList API está configurada e pronta para execução 🚀