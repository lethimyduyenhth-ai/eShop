# 🛍️ eShop - E-Commerce Application (.NET 8 Blazor Web App)

eShop is a modern e-commerce application built using **ASP.NET Core 8 Blazor**, **Clean Architecture**, and **Entity Framework Core with SQL Server**.

## 🏗️ Architecture Overview

The solution follows Clean Architecture principles with decoupled modules:

- **`eShop_coreBusiness`**: Core Domain Entities (`Product`, `Order`, `OrderLineItem`) and Domain Services (`OrderService`).
- **`eshop_UseCases`**: Application Use Cases and Plugin Interfaces (`IProductRepository`, `IOrderRepository`, etc.).
- **`Plugins/eShop.DataStore.EFCore`**: Entity Framework Core DataStore Plugin with SQL Server mapping (`eShopContext`).
- **`Plugins/eShop.DataStore.HardCode`**: In-Memory DataStore Plugin for offline development and testing.
- **`eShop.Web.CustomerPortal`**: Customer-facing Blazor components (Product Search, Shopping Cart, Checkout, Order Confirmation).
- **`eShop.Web.AdminPortal`**: Admin Portal Blazor components (Outstanding Orders management, Order Processing).
- **`eShop.Web`**: Main ASP.NET Core 8 Blazor Host application with Cookie Authentication & Minimal API endpoints.

## 🚀 Key Features

- **Customer Portal**: Product Catalog, Search, Interactive Shopping Cart, Checkout & Order Confirmation.
- **Admin Portal**: Protected Order Management Screen (`/admin` / `/outstandingorders`) with Order Detail Modal & Processing workflow.
- **Authentication**: Cookie-based Authentication (`/login`, `/logout`) with Role-based Authorization (`Admin`).
- **Database Support**: Full EF Core SQL Server integration with automatic database initialization (`EnsureCreated`).

## 🛠️ How to Run

1. Open `eShop.sln` in Visual Studio 2022 or VS Code.
2. Ensure SQL Server (LocalDB or Local Instance) is running.
3. Update connection string in `appsettings.json` if needed.
4. Run `eShop.Web` project (`https://localhost:7024`).
