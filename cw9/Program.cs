using cw9.Models;

Product CreateProduct() {
    Product product = new();
    Console.WriteLine("Podaj nazwę: ");
    product.Name = Console.ReadLine();
    Console.WriteLine("Podaj cenę: ");
    product.Price = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Podaj typ: ");
    product.Type = Console.ReadLine();

    return product;
}

var repo = new ProductsRepo();
var products = repo.GetProducts();

foreach(var product in products) {
    Console.WriteLine($"{product.Id}\t {product.Name}\t {product.Price}\t {product.Type}");
}

repo.AddProduct(CreateProduct());

