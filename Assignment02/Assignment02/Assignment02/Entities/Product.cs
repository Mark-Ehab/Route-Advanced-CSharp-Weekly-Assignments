using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment02.Entities;

public class Product
{
    // Properties

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!; // "Electronics", "Clothing", "Food", "Books"
    public double Price { get; set; }
    public int Stock { get; set; }

    // Methods

    /// <summary>
    /// A method override to ToString method that
    /// returns custom details about the product
    /// </summary>
    /// <returns>Product custom details</returns>
    public override string ToString() => $"{this.Name} ­ {this.Price:C0}(Stock: {Stock})";
}