using Assignment02.Entities;
using Assignment02.Extentions;
using Assignment02.Services;
using System.Collections;
using System.Xml.Linq;

namespace Assignment02;

internal class Program
{
    static void Main(string[] args)
    {
        /* Define a new display service */
        DisplayService displayService = new();

        /* Display app header */
        displayService.DisplayMessage("╔════════════════════════════════════════════════════════════════════╗");
        displayService.DisplayMessage("║                    Online Store Order Processing                   ║");
        displayService.DisplayMessage("╚════════════════════════════════════════════════════════════════════╝\n");

        /* Define a new list of different products */
        List<Product> catalog = new()
        {
            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };

        /* Test SearchProducts method through performing the following searches */
        List<Product> filteredProducts;
        displayService.DisplayMessage("========== Smart Product Search ==========\n");

        // Seach for all Electronics products only
        displayService.DisplayMessage("--------- Electronics ---------");
        filteredProducts = catalog.SearchProducts(product => product.Category == "Electronics");
        displayService.DisplayProducts(filteredProducts);

        // Seach for products cheaper than 50
        displayService.DisplayMessage("--------- Under $50 ---------");
        filteredProducts = catalog.SearchProducts(product => product.Price < 50d);
        displayService.DisplayProducts(filteredProducts);

        // Seach for products that are in stock (Stock > 0)
        displayService.DisplayMessage("--------- In Stock ---------");
        filteredProducts = catalog.SearchProducts(product => product.Stock > 0);
        displayService.DisplayProducts(filteredProducts);

        // Seach for clothing products under 100
        displayService.DisplayMessage("--------- Clothing Under $100 ---------");
        filteredProducts = catalog.SearchProducts(product => product.Category == "Clothing" && product.Price < 100);
        displayService.DisplayProducts(filteredProducts);

        /* Draw a separation line */
        displayService.DisplayMessage(new string('#',50) +"\n");

        /* Test PrintReports method through performing the following scenarios */
        displayService.DisplayMessage("========== Custom Report Generator ==========\n");

        // Scenario 1: Short Report: Print each product as Name - $Price
        displayService.DisplayMessage("--------- Short Report ---------");
        displayService.PrintReport(catalog,
            product => displayService.DisplayMessage($"{product.Name} - {product.Price:C0}"));

        // Scenario 2: Detailed Report: Print each product as [Category] Name | Price: $X | Stock: Y
        displayService.DisplayMessage("--------- Detailed Report ---------");
        displayService.PrintReport(catalog,
            product => displayService.DisplayMessage($"[{product.Category}] {product.Name} | Price: {product.Price:C0} | Stock: {product.Stock}"));

        /* Draw a separation line */
        displayService.DisplayMessage(new string('#', 50) + "\n");

        /* Test SearchProducts method through performing the following searches */
        List<string> transfomrndProducts;
        displayService.DisplayMessage("========== Custom Product Transformation ==========\n");

        // Scenario 3 Summary List: Transform each product into a string like "Laptop ($1200).
        // Print all results."
        displayService.DisplayMessage("--------- Summary List ---------");
        transfomrndProducts = catalog.TransformProducts(product => $"{product.Name} ({product.Price:C0})");
        displayService.DisplayTransformedProducts(transfomrndProducts);

        // Scenario 4 Price Label: Transform each product into "Expensive!" if Price > $100,
        // or "Affordable" otherwise. Print each as Name: Label.
        displayService.DisplayMessage("--------- Price Labels ---------");
        transfomrndProducts = catalog.TransformProducts(product => $"{product.Name}: {(product.Price > 100d ? "Expensive!" : "Affordable")}");
        displayService.DisplayTransformedProducts(transfomrndProducts);

        /* Draw a separation line */
        displayService.DisplayMessage(new string('#', 50) + "\n");

        /* Test FilterProducts method through performing the following searches */
        displayService.DisplayMessage("========== Product Filteration ==========\n");

        // Seach for all Electronics products only
        displayService.DisplayMessage("--------- Low-Stock Alert ---------");
        filteredProducts = catalog.FilterProducts(product => product.Stock < 20);
        displayService.DisplayLowStockAlert(filteredProducts);
    }
}
