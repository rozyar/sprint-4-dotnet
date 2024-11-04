# EcommerceAPI - Projeto Acadêmico

Este projeto é uma API RESTful para um sistema de e-commerce desenvolvido como parte de uma tarefa acadêmica. A aplicação integra funcionalidades de autenticação, gerenciamento de produtos, manipulação de usuários e pedidos, além de um sistema de recomendação de produtos baseado em IA usando ML.NET. Este documento fornece uma explicação detalhada de todas as funcionalidades implementadas, os requisitos cumpridos e instruções de como executar os testes.

## Requisitos Cumpridos

### 1. Integração com Serviço Externo (15 pontos)

- **Integração Implementada com OAuth do GitHub**: A aplicação integra-se ao serviço OAuth do GitHub para autenticação de usuários. Isso permite que os usuários façam login de forma segura usando suas contas do GitHub.
- **Funcionalidade**: Os usuários podem fazer login e logout usando suas credenciais do GitHub. O processo de autenticação é realizado por meio de chamadas seguras de API RESTful.

**Requisito Cumprido**: ✅

### 2. Testes Abrangentes com xUnit (15 pontos)

- **Testes Unitários**: Implementados testes unitários abrangentes cobrindo a lógica de negócios em serviços como `ProductService`, `UserService` e `OrderService`.
- **Testes de Integração**: Desenvolvidos testes de integração para validar os endpoints da API e suas interações com o banco de dados.
- **Testes de Sistema**: Realizados testes de sistema para garantir que a aplicação funcione corretamente como um todo.
- **Framework de Testes Utilizado**: xUnit e Moq para simulação de dependências.

**Requisito Cumprido**: ✅

### 3. Aplicação de Práticas de Código Limpo e Princípios SOLID (20 pontos)

- **Princípio da Responsabilidade Única (SRP)**: Cada classe e método possui uma única responsabilidade, melhorando a legibilidade e a manutenção. Por exemplo, `UserService` lida com operações relacionadas a usuários, enquanto `UserRepository` cuida do acesso a dados de usuários.
- **Princípio Aberto/Fechado (OCP)**: O sistema foi projetado para ser extensível sem modificar o código existente. Novos recursos podem ser adicionados estendendo classes existentes ou implementando novas.
- **Princípio da Substituição de Liskov (LSP)**: Interfaces e classes abstratas são utilizadas para que classes derivadas possam ser substituídas sem afetar a correção do programa.
- **Princípio da Segregação de Interfaces (ISP)**: As interfaces são específicas para as necessidades dos clientes, evitando a implementação de métodos desnecessários. Interfaces separadas como `IProductRepository` e `IOrderRepository` são utilizadas.
- **Princípio da Inversão de Dependência (DIP)**: Módulos de alto nível não dependem de módulos de baixo nível; ambos dependem de abstrações. Injeção de Dependência é utilizada em toda a aplicação.

**Práticas de Código Limpo**:

- **Nomenclatura Descritiva**: Variáveis e métodos possuem nomes claros e significativos, como `GetAllProductsAsync()`.
- **Modularização**: O código está organizado em módulos (Controllers, Services, Repositories, Models), tornando-o reutilizável e fácil de manter.
- **Tratamento de Erros**: Exceções são devidamente tratadas com blocos try-catch e respostas HTTP significativas.
- **Comentários e Documentação**: Seções críticas do código são bem documentadas para explicar lógicas complexas.

**Requisito Cumprido**: ✅

### 4. Integração de ML.NET e Implementação de Funcionalidade de IA Generativa (50 pontos)

- **Sistema de Recomendação de Produtos**: Integrado ML.NET para criar um modelo de recomendação usando Fatoração de Matrizes. O modelo oferece recomendações de produtos personalizadas aos usuários com base em suas avaliações.
- **Treinamento do Modelo**: O modelo é treinado com base nos dados de avaliações existentes armazenados no banco de dados. Ele prevê a probabilidade de um usuário gostar de um produto que ainda não avaliou.
- **Funcionalidade de IA Generativa**: O sistema de recomendação adiciona valor significativo à API, melhorando a experiência do usuário e aumentando o engajamento por meio de sugestões personalizadas.
- **Desafios Técnicos Abordados**:
    - Manipulação correta de tipos de dados e cardinalidade usando o atributo `[KeyType]` para evitar erros em tempo de execução.
    - Garantida a compatibilidade com macOS ao lidar com dependências de bibliotecas nativas.

**Requisito Cumprido**: ✅

## Visão Geral do Projeto

- **Tecnologias Utilizadas**: .NET Core, Entity Framework Core, ML.NET, xUnit, OAuth do GitHub.
- **Arquitetura**: Segue a arquitetura MVC com Controllers, Services, Repositories e Models.
- **Banco de Dados**: Configurado com Oracle Database usando `EcommerceContext`.

## Como Executar o Projeto

### Pré-requisitos

- **SDK do .NET Core** instalado.
- **Banco de Dados Oracle** configurado (ou modifique `EcommerceContext` para usar outro provedor de banco de dados).
- **Conta no GitHub** para autenticação OAuth.

### Passos

1. **Clonar o Repositório**:

   ```bash
   git clone https://github.com/seuusuario/EcommerceAPI.git
   cd EcommerceAPI
   ```

2. **Configurar a Conexão com o Banco de Dados**:

    - Atualize a string de conexão em `appsettings.json` ou `EcommerceContext.cs` para conectar ao seu banco de dados.

3. **Instalar Dependências**:

   ```bash
   dotnet restore
   ```

4. **Executar Migrações do Banco de Dados**:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Executar a Aplicação**:

   ```bash
   dotnet run
   ```

   A API estará disponível em `http://localhost:5151`.

6. **Autenticar com GitHub**:

    - Acesse `http://localhost:5151/Account/Login` para fazer login com sua conta do GitHub.

## Como Executar os Testes

- **Testes Unitários**:

  ```bash
  dotnet test
  ```

- **Testes de Integração e Sistema**:

    - Use ferramentas como **Postman** ou o cliente HTTP embutido no **JetBrains Rider** ou **Visual Studio** para interagir com os endpoints da API.
    - Exemplos de solicitações HTTP são fornecidos nos arquivos `.http` do projeto.

## Endpoints da API

### Autenticação

- **GET** `/Account/Login` - Fazer login com OAuth do GitHub.
- **GET** `/Account/Logout` - Fazer logout.

### Produtos

- **GET** `/api/products` - Obter todos os produtos.
- **GET** `/api/products/{id}` - Obter um produto por ID.
- **POST** `/api/products` - Criar um novo produto (requer autenticação).
- **PUT** `/api/products/{id}` - Atualizar um produto (requer autenticação).
- **DELETE** `/api/products/{id}` - Excluir um produto (requer autenticação).

### Usuários

- **GET** `/api/users` - Obter todos os usuários.
- **GET** `/api/users/{id}` - Obter um usuário por ID.
- **GET** `/api/users/Email/{email}` - Obter um usuário por e-mail.
- **POST** `/api/users` - Criar um novo usuário.
- **PUT** `/api/users/{id}` - Atualizar um usuário.
- **DELETE** `/api/users/{id}` - Excluir um usuário.

### Pedidos

- **GET** `/api/orders` - Obter todos os pedidos (requer autenticação).
- **GET** `/api/orders/{id}` - Obter um pedido por ID (requer autenticação).
- **POST** `/api/orders` - Criar um novo pedido (requer autenticação).
- **PUT** `/api/orders/{id}` - Atualizar um pedido (requer autenticação).
- **DELETE** `/api/orders/{id}` - Excluir um pedido (requer autenticação).

### Recomendações

- **GET** `/api/recommendations/{userId}` - Obter recomendações de produtos para um usuário.

## Detalhes Adicionais

### Tratamento de Erros e Validação

- Implementado tratamento abrangente de erros para retornar respostas HTTP significativas.
- A validação de entrada é realizada para garantir a integridade dos dados.

### Segurança

- Endpoints sensíveis são protegidos com atributos de autorização.
- Métodos de autenticação seguros com OAuth foram utilizados.

### Seed de Dados

- O banco de dados é preenchido com dados iniciais de usuários, produtos e avaliações para facilitar o teste e o desenvolvimento.

## Conclusão

Este projeto demonstra habilidades técnicas na construção de APIs robustas e escaláveis, integrando serviços externos e aplicando inteligência artificial para agregar valor ao sistema. Todos os requisitos acadêmicos foram cumpridos com sucesso.
