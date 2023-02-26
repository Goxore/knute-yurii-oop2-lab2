class Ex4
{
    public static void Run()
    {

        // створити список рядків для обробки
        List<string> stringsToProcess = new List<string> { "яблуко", "банан", "вишня", "ананас" };

        // створення делегату, який приймає рядок як вхідні дані та повертає його довжину
        Func<string, int> stringLengthDelegate = s => s.Length;

        // використовуємо делегат для обробки списку рядків
        foreach (string str in stringsToProcess)
        {
            int strLength = stringLengthDelegate(str);
            Console.WriteLine("{0} має довжину {1}", str, strLength);
        }

    }
}
