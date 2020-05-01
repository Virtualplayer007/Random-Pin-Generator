using System.Text;
using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace RandomPinGenerator
{
    public class mainClass
    {
        public static string saveToFileStr = File.ReadAllText(@"/Users/tymonblabla/Main/saveToFile.txt", Encoding.UTF8);
        public static string pinFile = File.ReadAllText(@"/Users/tymonblabla/Main/Pins.txt", Encoding.UTF8);
        public static int numCount = int.Parse(File.ReadAllText(@"/Users/tymonblabla/Main/numCount.txt", Encoding.UTF8));
        public static string pinRandom;
        public static string GetRandomNumber()
        {
            Random random = new Random();
            numCount = int.Parse(File.ReadAllText(@"/Users/tymonblabla/Main/numCount.txt", Encoding.UTF8));
            if(numCount == 6)
            {
                int number1 = random.Next(10, 99);
                int number2 = random.Next(10, 99);
                int number3 = random.Next(10, 99);
                string number1str = number1.ToString();
                string number2str = number2.ToString();
                string number3str = number3.ToString();
                pinRandom = number2str + number1str + number3str;
            }
            if(numCount == 4)
            {
                int number1 = random.Next(10, 99);
                int number2 = random.Next(10, 99);
                string number1str = number1.ToString();
                string number2str = number2.ToString();
                pinRandom = number2str + number1str;
            }
            return pinRandom;
        }
        public static void Main()
        {
            bool saveToFile = bool.Parse(saveToFileStr);
            int choice;
            int pin;
            while(true)
            {
                
            Console.WriteLine("Wybierz opcje: ");
            Console.WriteLine("1) Wylosuj pin");
            Console.WriteLine("2) Informacje o programie");
            Console.WriteLine("3) Ustawienia");
            Console.WriteLine("4) Wyjdz");
            Console.WriteLine("5) Wyczysc konsole");
            Console.WriteLine("6) Ostatni wylosowany pin");
            Console.WriteLine("7) Wyczyść piny");
            Console.Write("Wybor: ");
            choice = int.Parse(Console.ReadLine());
            bool warunek = true;
            while(warunek)
            {
                if(choice > 7 || choice < 1)
                {
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Console.Write("Wybor: ");
                    choice = int.Parse(Console.ReadLine());
                }
                else
                {
                    warunek = false;
                }
            }
            switch(choice)
            {
                case 1:
                    Console.Write("Generowanie");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1500);
                    Console.Write(".");
                    Thread.Sleep(800);
                    Console.Write(".");
                    pin = int.Parse(GetRandomNumber());
                    Console.WriteLine("\nWygenerowano. Wynik: " + pin.ToString());
                    if(saveToFile == true)
                    {
                        File.WriteAllText(@"/Users/tymonblabla/Main/Pins.txt", String.Empty);
                        File.WriteAllText(@"/Users/tymonblabla/Main/Pins.txt", pin.ToString());
                    }
                    else if(saveToFile == false) 
                    {
                        File.WriteAllText(@"/Users/tymonblabla/Main/Pins.txt", String.Empty);
                    }
                    Console.ReadKey();
                break;
                case 2:
                Console.WriteLine("Wersja 0.9.1 (Beta)");
                Console.ReadKey();
                break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Aby zmienic ustawienie napisz '<ustawienie> true/false | liczba'");
                    Console.WriteLine("Zapis do pliku: " + saveToFile.ToString());
                    Console.WriteLine("Liczba cyfr: " + numCount);
                    Console.WriteLine("Zaawansowane ustawienia");
                    Console.Write("Wybor: ");
                    string ustawienie = Console.ReadLine();
                    bool ustawienieSaveToFile = (ustawienie == "Zapis do pliku true"); 
                    if(ustawienieSaveToFile)
                    {
                        saveToFile = true;
                        File.WriteAllText(@"/Users/tymonblabla/Main/saveToFile.txt", saveToFile.ToString());
                        Console.WriteLine("Zmieniono status zapis do pliku na " + saveToFile.ToString());
                    }
                    else if(ustawienie == "Zapis do pliku false")
                    {
                        saveToFile = false;
                        File.WriteAllText(@"/Users/tymonblabla/Main/saveToFile.txt", saveToFile.ToString());
                        Console.WriteLine("Zmieniono status zapis do pliku na " + saveToFile.ToString());
                    }
                    else if(ustawienie == "Liczba cyfr 4")
                    {
                        File.WriteAllText("/Users/tymonblabla/Main/numCount.txt", String.Empty);
                        File.WriteAllText("/Users/tymonblabla/Main/numCount.txt", "4");
                        Console.WriteLine("Zmieniono wartość Liczba cyfr na 4.");
                    }
                    else if(ustawienie == "Liczba cyfr 6")
                    {
                        File.WriteAllText("/Users/tymonblabla/Main/numCount.txt", String.Empty);
                        File.WriteAllText("/Users/tymonblabla/Main/numCount.txt", "6");
                        Console.WriteLine("Zmieniono wartość Liczba cyfr na 6.");
                    }
                    else if(ustawienie == "Zaawansowane ustawienia")
                    {
                        Console.Clear();
                        Console.WriteLine("Coming soon");
                        Console.WriteLine("Wpisz q aby wyjsc z ustawien zaawansowanych");
                        string advanced = Console.ReadLine();
                        if(advanced == "q")
                        {
                            break;
                        }
                    }
                break;
                case 4:
                    System.Environment.Exit(0);
                break;
                case 5:
                    Console.Clear();
                break;
                case 6:
                    pinFile = File.ReadAllText(@"/Users/tymonblabla/Main/Pins.txt", Encoding.UTF8);
                    if(saveToFile == true)
                    {
                        Console.WriteLine("Ostatnie wygenerowane piny: " + pinFile);
                    }
                    else if(saveToFile == false)
                    {
                        Console.WriteLine("Zapisywanie do pliku jest wyłączone");
                    }
                    Console.ReadKey();
                break;
                case 7:
                    if(saveToFile == true)
                    {
                        File.WriteAllText(@"/Users/tymonblabla/Main/Pins.txt", String.Empty);
                    }
                    else if(saveToFile == false)
                    {
                        Console.WriteLine("Zapis jest wylaczony.");
                    }
                break;
            }
            }
        }
    }
}