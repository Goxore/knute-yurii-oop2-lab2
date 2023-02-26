class Ex2
{
    public static void Run()
    {
        // шлях до файлу CSV
        string filePath = "workers.csv";

        // Читання файлу CSV і створення списку об’єктів Worker
        List<Worker> workers = File.ReadAllLines(filePath)
                                      .Skip(1) // Пропускаємо рядок заголовка
                                      .Select(line => line.Split(','))
                                      .Select(fields => new Worker
                                      {
                                          Id = int.Parse(fields[0]),
                                          Name = fields[1],
                                          Salary = int.Parse(fields[2]),
                                          Expirience = double.Parse(fields[3])
                                      })
                                      .ToList();

        // Сортуємо робітників
        List<Worker> sortedWorkers = workers.OrderBy(worker => worker.Salary).ToList();

        // Виводимо відфільтрований список студентів
        foreach (Worker worker in sortedWorkers)
        {
            Console.WriteLine($"Ім'я: {worker.Name}, Зарплата: {worker.Salary}, роки досвіду: {worker.Expirience}");
        }
    }

    class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public double Expirience { get; set; }
    }
}
