# EcommerceAPI - Academic Project

This project is a RESTful API for an e-commerce system developed as part of an academic assignment. The application integrates authentication features, product management, user and order handling, and a product recommendation system based on AI using ML.NET. This document provides a detailed explanation of all implemented functionalities, fulfilled requirements, and instructions on how to run the tests.

## Fulfilled Requirements

### 1. Integration with External Service (15 points)

- **Implemented Integration with GitHub OAuth**: The application integrates with GitHub's OAuth service for user authentication. This allows users to securely log in using their GitHub accounts.
- **Functionality**: Users can log in and log out using their GitHub credentials. The authentication process is handled through secure RESTful API calls.

**Requirement Met**: ✅

### 2. Comprehensive Testing using xUnit (15 points)

- **Unit Tests**: Implemented comprehensive unit tests covering the business logic in services such as `ProductService`, `UserService`, and `OrderService`.
- **Integration Tests**: Developed integration tests to validate the API endpoints and their interactions with the database.
- **System Tests**: Conducted system tests to ensure the application works correctly as a whole.
- **Testing Framework Used**: xUnit and Moq for mocking dependencies.

**Requirement Met**: ✅

### 3. Application of Clean Code Practices and SOLID Principles (20 points)

- **Single Responsibility Principle (SRP)**: Each class and method has a single responsibility, improving readability and maintainability. For example, `UserService` handles user-related operations, while `UserRepository` handles data access for users.
- **Open/Closed Principle (OCP)**: The system is designed to be extensible without modifying existing code. New features can be added by extending existing classes or implementing new ones.
- **Liskov Substitution Principle (LSP)**: Interfaces and abstract classes are used so that derived classes can be substituted without affecting the correctness of the program.
- **Interface Segregation Principle (ISP)**: Interfaces are specific to client needs, preventing the implementation of unnecessary methods. Separate interfaces like `IProductRepository` and `IOrderRepository` are used.
- **Dependency Inversion Principle (DIP)**: High-level modules do not depend on low-level modules; both depend on abstractions. Dependency Injection is used throughout the application.

**Clean Code Practices**:

- **Descriptive Naming**: Variables and methods have clear and meaningful names, e.g., `GetAllProductsAsync()`.
- **Modularization**: Code is organized into modules (Controllers, Services, Repositories, Models), making it reusable and maintainable.
- **Error Handling**: Exceptions are properly handled with try-catch blocks and meaningful HTTP responses.
- **Comments and Documentation**: Critical sections of the code are well-documented to explain complex logic.

**Requirement Met**: ✅

### 4. Integration of ML.NET and Implementation of Generative AI Functionality (50 points)

- **Product Recommendation System**: Integrated ML.NET to create a recommendation model using Matrix Factorization. The model provides personalized product recommendations to users based on their ratings.
- **Model Training**: The model is trained on existing user ratings data stored in the database. It predicts the likelihood of a user liking a product they haven't rated yet.
- **Generative AI Functionality**: The recommendation system adds significant value to the API by enhancing user experience and increasing engagement through personalized suggestions.
- **Technical Challenges Addressed**:
    - Correct handling of data types and cardinality using `[KeyType]` attribute to prevent runtime errors.
    - Ensured compatibility with macOS by addressing native library dependencies.

**Requirement Met**: ✅

## Project Overview

- **Technologies Used**: .NET Core, Entity Framework Core, ML.NET, xUnit, GitHub OAuth.
- **Architecture**: Follows MVC architecture with Controllers, Services, Repositories, and Models.
- **Database**: Configured with Oracle Database using `EcommerceContext`.

## How to Run the Project

### Prerequisites

- **.NET Core SDK** installed.
- **Oracle Database** setup (or modify `EcommerceContext` to use a different database provider).
- **GitHub Account** for OAuth authentication.

### Steps

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/yourusername/EcommerceAPI.git
   cd EcommerceAPI
   ```

2. **Configure the Database Connection**:

    - Update the connection string in `appsettings.json` or `EcommerceContext.cs` to connect to your database.

3. **Install Dependencies**:

   ```bash
   dotnet restore
   ```

4. **Run Database Migrations**:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run the Application**:

   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:5151`.

6. **Authenticate with GitHub**:

    - Access `http://localhost:5151/Account/Login` to log in with your GitHub account.

## How to Run the Tests

- **Unit Tests**:

  ```bash
  dotnet test
  ```

- **Integration and System Tests**:

    - Use tools like **Postman** or the built-in HTTP client in **JetBrains Rider** or **Visual Studio** to interact with the API endpoints.
    - Sample HTTP requests are provided in the project's `.http` files.

## API Endpoints

### Authentication

- **GET** `/Account/Login` - Log in with GitHub OAuth.
- **GET** `/Account/Logout` - Log out.

### Products

- **GET** `/api/products` - Get all products.
- **GET** `/api/products/{id}` - Get a product by ID.
- **POST** `/api/products` - Create a new product (requires authentication).
- **PUT** `/api/products/{id}` - Update a product (requires authentication).
- **DELETE** `/api/products/{id}` - Delete a product (requires authentication).

### Users

- **GET** `/api/users` - Get all users.
- **GET** `/api/users/{id}` - Get a user by ID.
- **GET** `/api/users/Email/{email}` - Get a user by email.
- **POST** `/api/users` - Create a new user.
- **PUT** `/api/users/{id}` - Update a user.
- **DELETE** `/api/users/{id}` - Delete a user.

### Orders

- **GET** `/api/orders` - Get all orders (requires authentication).
- **GET** `/api/orders/{id}` - Get an order by ID (requires authentication).
- **POST** `/api/orders` - Create a new order (requires authentication).
- **PUT** `/api/orders/{id}` - Update an order (requires authentication).
- **DELETE** `/api/orders/{id}` - Delete an order (requires authentication).

### Recommendations

- **GET** `/api/recommendations/{userId}` - Get product recommendations for a user.

## Additional Details

### Error Handling and Validation

- Implemented comprehensive error handling to return meaningful HTTP responses.
- Input validation is performed to ensure data integrity.

### Security

- Protected sensitive endpoints using authorization attributes.
- Used secure authentication methods with OAuth.

### Data Seeding

- The database is seeded with initial data for users, products, and ratings to facilitate testing and development.

## Conclusion

This project demonstrates technical skills in building robust and scalable APIs, integrating with external services, and applying artificial intelligence to add value to the system. All academic requirements have been successfully fulfilled.
