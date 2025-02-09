# Programming Principles in the Project
This file provides an overview of how different programming principles are used in the project. The principles include SOLID, DRY, KISS, YAGNI, and Composition Over Inheritance.
## 1. DRY (Don't Repeat Yourself
- The Money class [see lines 10-37](https://github.com/MariaVlod/software-design-course/blob/main/lab-1/WarehouseLibrary/Money.cs#L10-L37) encapsulates the logic for handling money values and normalization.
- The Display() method is used to print the values of Money objects [see lines 39-42](https://github.com/MariaVlod/software-design-course/blob/main/lab-1/WarehouseLibrary/Money.cs#L39-L42) avoiding code duplication across the project.

## 2. KISS (Keep It Simple, Stupid)
The code structure is straightforward and easy to understand:

- Each class has a clear responsibility for example [Product.cs](./WarehouseLibrary/Product.cs) handles product-related operations, [Warehouse.cs](./WarehouseLibrary/Warehouse.cs) handles management.
- The [Reporting.cs](./WarehouseLibrary/Reporting.cs) class provides a clear way to manage warehouse items without unnecessary complexity.

## 3. SOLID Principles

### 3.1 Single Responsibility Principle (SRP)

Each class is responsible for a single function:

- [Money](./WarehouseLibrary/Money.cs) class handles currency operations.
- [Product](./WarehouseLibrary/Product.cs) manages product details and price changes.
- [Warehouse](./WarehouseLibrary/Warehouse.cs) tracks inventory and deliveries.
- [Reporting](./WarehouseLibrary/Reporting.cs) provides reporting functionality for inventory management.
### 3.2 Open/Closed Principle (OCP)

The [Money](./WarehouseLibrary/Money.cs) class is open for extension but closed for modification:

- It allows new currencies to be introduced via inheritance (USD, EUR classes) [USD](./WarehouseLibrary/USD.cs) [EUR](./WarehouseLibrary/EUR.cs) without modifying the base class .
### 3.3 Liskov Substitution Principle (LSP)

- USD and EUR classes [USD](./WarehouseLibrary/USD.cs) [EUR](./WarehouseLibrary/EUR.cs) extend Money and can be used interchangeably with Money objects without breaking the program.
  ### 3.4 Interface Segregation Principle (ISP)

Project follows ISP by keeping separate classes for different responsibilities instead of one large interface. Example:

- [Warehouse](./WarehouseLibrary/Warehouse.cs) does not depend on unnecessary functionalities like [Product](./WarehouseLibrary/Product.cs) price changes.

### 3.5 Dependency Inversion Principle (DIP)

- The [Reporting](./WarehouseLibrary/Reporting.cs) class depends on abstractions ([Warehouse](./WarehouseLibrary/Warehouse.cs) objects) rather than concrete implementations and with that making it easy to extend and modify without breaking the existing functionality.

## 4. YAGNI (You Ain't Gonna Need It)

The project only includes necessary functionalities, avoiding unused features.

- No unnecessary features are added to the [ShoppingCart](./WarehouseLibrary/ShoppingCart.cs) class.
- The [Warehouse](./WarehouseLibrary/Warehouse.cs) class only contains relevant inventory details instead of extra tracking systems.

## 5. Composition Over Inheritance

Instead of deep inheritance hierarchies, composition is preferred:

- [Product](./WarehouseLibrary/Product.cs) has a [Money](./WarehouseLibrary/Money.cs) object [see lines 16-25](https://github.com/MariaVlod/software-design-course/blob/main/lab-1/WarehouseLibrary/Product.cs#L16-L25) rather than extending Money, promoting better reusability. 
- [Warehouse](./WarehouseLibrary/Warehouse.cs) includes [Money](./WarehouseLibrary/Money.cs) for UnitPrice [see line 13](https://github.com/MariaVlod/software-design-course/blob/main/lab-1/WarehouseLibrary/Warehouse.cs#L13), ensuring flexibility without unnecessary inheritance.
