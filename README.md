
# Inventory Management System

## Project Overview

As digital commerce continues to expand, many small and medium-sized businesses face challenges in establishing efficient and comprehensive online sales platforms. These businesses often rely on outdated, fragmented systems that complicate product management, customer engagement, and transaction processing. Such inefficiencies lead to operational delays, increased costs, and customer dissatisfaction.

This project proposes the development of a **web-based eCommerce and sales system** that provides businesses with an **all-in-one solution**. The platform focuses on:
- **Simplifying product management**
- **Streamlining order processing**
- **Enhancing customer satisfaction** through a smooth, intuitive shopping experience

By offering these integrated features, the system will help businesses optimize operations and maximize their online sales potential.

---

## Features

- 🛡️ **User Registration and Authentication**: Secure login/logout using ASP.NET Core Identity and JWT.
- 🛒 **Product Management**: Manage products efficiently (Add, edit, delete).
- 📦 **Order Management**: Seamless order placement and tracking.
- 🛍️ **Shopping Cart**: Customers can add, update, and remove items in their shopping cart.
- 📊 **Inventory Tracking**: Real-time product quantity tracking and updates.
- 🍪 **Cookies Integration**: Manage user sessions and preferences with cookies.
- 📱 **Responsive Design**: A mobile-friendly interface with Bootstrap.

---

## Database Design

The system's database has been carefully designed to handle product management, user authentication, orders, and inventory tracking.

## Technologies Used

- **ASP.NET Core**: Backend framework.
- **MVC (Model-View-Controller)**: Structured app architecture.
- **Entity Framework (EF)**: ORM for database management.
- **SQL Server**: Database management.
- **LINQ**: Querying data.
- **JWT (JSON Web Tokens)**: Secure user authentication.
- **AutoMapper**: For mapping models and DTOs.
- **Bootstrap**: Responsive frontend design.

---

## Prerequisites

- **.NET SDK** (version 6.0 or later)
- **SQL Server** (local or remote)
- **Visual Studio 2022** or **Visual Studio Code**
- **NuGet Packages**: Entity Framework, ASP.NET Core Identity, AutoMapper

---

## Installation and Setup

To set up and run the project locally:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/username/inventory-management-system.git
   ```

2. **Navigate to the project directory**:
   ```bash
   cd inventory-management-system
   ```

3. **Set up the database**:
   - Update the connection string in `appsettings.json`.
   - Run the migrations to create the database schema:
     ```bash
     dotnet ef database update
     ```

4. **Build and run the project**:
   ```bash
   dotnet run
   ```

5. **Open your browser** and navigate to `https://localhost:5001`.

---

## Contributing

Contributions are welcome! Please follow these steps if you'd like to contribute:

1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/AmazingFeature`).
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the branch (`git push origin feature/AmazingFeature`).
5. Open a Pull Request.

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
