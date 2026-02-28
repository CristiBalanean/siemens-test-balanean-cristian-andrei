# SieMarket - Order Management System

## Problem Description
This project implements an order management system for SieMarket, an online electronics store.

It includes:
- `OrderItem` class to represent individual products in an order
- `Order` class with methods to:
  - Calculate final prices (with 10% discount for orders over 500€)
  - Find the top spending customer across all orders
  - Retrieve popular products sorted by total quantity sold

## Project Structure
```
siemens-test/
├── Problem1/
│   ├── CoffeeShopUML.drawio.html   # UML Class Diagram
│   └── CoffeeShopER.drawio.html    # ER Database Diagram
└── Problem2/
    └── Program.cs                  # C# implementation
```

## Requirements
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)

## How to Run
Clone the repository and navigate to the Problem2 folder:
```bash
git clone https://github.com/CristiBalanean/siemens-test-balanean-cristian-andrei
cd Problem2
dotnet run
```

## Expected Output
```
Order Prices:
Order 1 (Alice): $765.00
Order 2 (Bob): $320.00
Order 3 (Alice): $400.00
Order 4 (Bob): $1,462.50

Top Spending Customer:
Top spender: Bob

Popular Products:
Laptop: 3 units sold
Mouse: 3 units sold
Phone: 1 units sold
Case: 1 units sold
Monitor: 1 units sold
```
