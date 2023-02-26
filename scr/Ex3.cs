using System.Globalization;

class Ex3
{
    public static void Run()
    {
        // шлях до файлу CSV
        string filePath = "products.csv";

        // CultureInfo.CurrentCulture.

        // Читання файлу CSV і створення списку об’єктів Product
        List<Product> products = File.ReadAllLines(filePath)
                                      .Skip(1) // Пропускаємо рядок заголовка
                                      .Select(line => line.Split(','))
                                      .Select(fields => new Product
                                      {
                                          Name = fields[0],
                                          Category = fields[1],
                                          Price = int.Parse(fields[2])
                                      })
                                      .ToList();

        // Групуємо
        var groupedProducts = products.GroupBy(p => p.Category);

        // Виводимо згруповані даних
        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"Категорія: {group.Key}");
            foreach (var product in group)
            {
                // виводить результат в гривнях
                Console.WriteLine($"\t{product.Name}, {product.Price.ToString("C", new CultureInfo("uk-UA"))}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }
}
