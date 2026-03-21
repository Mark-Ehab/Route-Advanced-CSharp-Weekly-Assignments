using Assignment02.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.Services;

public class DisplayService
{
    // Methods

    /// <summary>
    /// A method to print a message
    /// </summary>
    /// <param name="message">The message to be printed</param>
    public void DisplayMessage(string? message = null)
    {
        if(message is null)
        {
            Console.WriteLine();
            return;
        }

        Console.WriteLine(message);
    }

    /// <summary>
    /// A method to print details of products list 
    /// </summary>
    /// <param name="products">List of products</param>
    public void DisplayProducts(List<Product> products)
    {
        foreach (Product product in products)
        {
            this.DisplayMessage(product.ToString());
        }
        this.DisplayMessage();
    }

    /// <summary>
    /// A method to print details of transformed products 
    /// </summary>
    /// <param name="transformedProducts">List of transformed products</param>
    public void DisplayTransformedProducts(List<string> transformedProducts)
    {
        foreach (string product in transformedProducts)
        {
            this.DisplayMessage(product);
        }
        this.DisplayMessage();
    }

    /// <summary>
    /// Display Low Stock Alerts for products whose stock 
    /// is less than 20
    /// </summary>
    /// <param name="lowStockProducts">List of products whose stock is less than 20</param>
    public void DisplayLowStockAlert(List<Product> lowStockProducts)
    {
        foreach (Product product in lowStockProducts)
        {
            this.DisplayMessage($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
        }
        this.DisplayMessage();
    }

    /// <summary>
    /// A method to print a custom report for each 
    /// product in a list of products
    /// </summary>
    /// <param name="products">List of products</param>
    /// <param name="action">Action that decides report format</param>
    public void PrintReport(List<Product> products, Action<Product> action)
    {
        foreach (Product product in products)
        {
            action(product);
        }
        this.DisplayMessage();
    }
    /*-----------------------------------------------------------------------------------
        In previous method Action<Product> delegate is used cause it's required to pass 
        a method that prints a custom report format for each product in the list without
        returning anything
    -----------------------------------------------------------------------------------*/
}