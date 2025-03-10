# Data Transfer Objects (DTOs)

**Data Transfer Objects (DTOs)** serve as data containers that transfer data between layers of your application. They play a crucial role in ensuring clean and efficient data communication, especially in microservices or API-driven applications.

---

## 📜 Benefits of Using DTOs

### ✅ Security
- Prevent sensitive information from being exposed to API consumers.
- Hide internal domain models or fields that should not be shared publicly.

### ✅ Decoupling
- Isolate the internal domain models from external API consumers.
- Changes in domain models will not directly impact API responses.

### ✅ Optimization
- Transfer only the necessary data required for a particular operation.
- Avoid over-fetching or under-fetching data.

### ✅ Validation
- Implement specific validation rules based on the operation.
- Create separate DTOs for `Create`, `Update`, and `Read` operations.

---

## 💼 The Role of DTOs in Your Finance Tracker Application

DTOs play several important roles in your layered architecture to ensure smooth data communication between the client, server, and database.

### 1. **API Request/Response Models**
These DTOs handle the data transferred when users interact with the API.

- **`CreateTransactionDto`**: Used when a user wants to create a new transaction.
- **`UpdateBudgetDto`**: Used when updating an existing budget.
- **`LoginUserDto`**: Contains credentials for user authentication.

---

### 2. **Data Transformation**
These DTOs are responsible for transforming complex entities into simpler formats for the client-side.

- **`TransactionDto`**: Transforms the `Transaction` entity into a simplified format for the UI.
- **`CategorySummaryDto`**: Aggregates transaction data by category with additional calculations.

---

### 3. **Security**
DTOs are crucial for excluding sensitive information like passwords, user hashes, etc., from API responses.

- **`UserDto`**: Excludes sensitive information like the password hash when returning user data.
- **`AuthResponseDto`**: Returns only the necessary authentication information (like token, expiry, etc.).

---

### 4. **Business Logic Support**
DTOs can also carry calculated or aggregated data, enhancing the business logic.

- **`BudgetProgressDto`**: Contains additional calculated fields like the percentage of budget used.
- **`DashboardDto`**: Aggregates multiple data sources to provide a consolidated dashboard view.
- **`ReportDto`**: Organizes financial data to generate user-friendly reports.

---

### 5. **Validation**
Some DTOs are specifically designed for validating incoming data from the client.

- **`RegisterUserDto`**: Includes fields like `password` and `confirmPassword` to ensure password match.
- **`CreateFinancialGoalDto`**: Contains all fields required to create a valid financial goal.

---

## 💻 Practical Implementation Flow

Here’s how the data flows through your application using DTOs.

### ✅ Data Flows **FROM Client** (Request):
1. **Client** sends `CreateTransactionDto` to **API**.
2. **API Controller** receives the DTO and passes it to the **Service layer**.
3. **Service Layer** maps the DTO to an **Entity** (e.g., `Transaction`).
4. **Repository** persists the entity into the **Database**.

---

### ✅ Data Flows **TO Client** (Response):
1. **Repository** fetches the entity from the **Database**.
2. **Service Layer** maps the **Entity** to a `TransactionDto`.
3. **Controller** returns the DTO as a response to the client.
4. **Client** displays the formatted data in the UI.

---

