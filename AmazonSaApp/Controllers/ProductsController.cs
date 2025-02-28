using Microsoft.AspNetCore.Mvc;
public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 3000, Description = "Gaming Laptop" },
            new Product { Id = 2, Name = "Phone", Price = 1500, Description = "Smartphone" }
        };

        return View(products);
    }
}
