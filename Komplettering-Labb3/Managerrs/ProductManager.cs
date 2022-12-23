using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Komplettering_Labb3.DataModels.Products;
using Komplettering_Labb3.DataModels.Users;
using System.IO;
using System.Text.Json;

namespace Komplettering_Labb3.Managerrs;

public static class ProductManager
{
    private static IEnumerable<Product>? _products = new List<Product>();
    public static IEnumerable<Product>? Products => _products;
    
    // Skicka detta efter att produktlistan ändrats eller lästs in
    public static event Action ProductListChanged;

    public static void AddProduct(Product product)
    {
        Item item = new Item(product.Name, product.Price);
        var temp = (List<Product>)Products;
        temp.Add(item);
    }
    
    public static void RemoveProduct(Product product)
    {
        var temp = (List<Product>)Products;
       temp.Remove(product);
    }

    public static async Task SaveProductsToFile()
    {
        string filePath = (Path.Combine(Environment.GetFolderPath(folder: Environment.SpecialFolder.LocalApplicationData), "Products"));
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            await sw.WriteLineAsync(JsonSerializer.Serialize(Products,
                new JsonSerializerOptions() { WriteIndented = true }));
        }
    }

    public static async Task LoadProductsFromFile()
    {
        string filePath = (Path.Combine(Environment.GetFolderPath(folder: Environment.SpecialFolder.LocalApplicationData), "Products"));
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = await r.ReadToEndAsync();
            var products = JsonSerializer.Deserialize<List<User>>(json);
        }
    }
}