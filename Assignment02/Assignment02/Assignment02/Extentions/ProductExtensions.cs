using Assignment02.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.Extentions;

public static class ProductExtensions
{

    // Methods

    /// <summary>
    /// An extension mehtod that filters a list products
    /// based on a specific filteration criterion
    /// </summary>
    /// <param name="products">List of products to be filtered</param>
    /// <param name="filter">Custom product filteration criterion</param>
    /// <returns>A new list of filtered products</returns>
    public static List<Product> SearchProducts(this List<Product> products, Func<Product, bool> filter)
    {
        List<Product> result = [];

        foreach (Product product in products)
        {
            if (filter(product))
            {
                result.Add(product);
            }
        }

        return result;
    }

    /*-----------------------------------------------------------------------------------
        In previous method Func<Product, bool> delegate is used cause it's required to 
        pass a method that that filters each product to be searched based on a specific 
        criterion or condition which will return true if the condition is fullfiled or 
        false otherwise
    -----------------------------------------------------------------------------------*/

    /// <summary>
    /// An extension method that tranforms a list of 
    /// products to list of strings based on a specific
    /// product transformer
    /// </summary>
    /// <param name="products">List of products</param>
    /// <param name="transform">Custom transformation criterion</param>
    /// <returns>List of strings of products been transformed</returns>
    public static List<string> TransformProducts(this List<Product> products, Func<Product, string> transform)
    { 
        List<string> result = [];

        foreach (Product product in products)
        {
            result.Add($"{transform(product)}");
        }

        return result;
    }

    /*-----------------------------------------------------------------------------------
        In previous method Func<Product, string> delegate is used cause it's required 
        to pass a method that that tranforms each product to a specific string format
    -----------------------------------------------------------------------------------*/

    /// <summary>
    /// An extension mehtod that filters a list products
    /// based on a specific filteration criterion
    /// </summary>
    /// <param name="products">List of products to be filtered</param>
    /// <param name="filter">Custom product filteration predicate</param>
    /// <returns>A new list of filtered products</returns>
    public static List<Product> FilterProducts(this List<Product> products, Predicate<Product> filter)
    {
        List<Product> result = [];

        foreach (Product product in products)
        {
            if (filter(product))
            {
                result.Add(product);
            }
        }

        return result;
    }
    /*-----------------------------------------------------------------------------------
        In previous method Predicate<Product> delegate is used cause it's required to 
        pass a method that that filters each product based on a specific criterion or 
        condition which will return true if the condition is fullfiled or false otherwise
    -----------------------------------------------------------------------------------*/
}