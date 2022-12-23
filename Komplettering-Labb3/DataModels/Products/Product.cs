namespace Komplettering_Labb3.DataModels.Products;

public abstract class Product
{
    public string Name { get; set; }

    public float Price { get; set; }

    protected Product(string name, float price)
    {
        Name = name;
        Price = price;
    }
}