using Week5HW.Interfaces;
using Week5HW.Models;

namespace Week5HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Colored.WriteLine("Bakda ne qeder benzin var?",ConsoleColor.Blue);
            double benzin = CheckNum(0);

            Colored.Write("Mashinin bakinin hecmi ne qederdir?", ConsoleColor.Blue);
            Colored.WriteLine("(*Bakdaki benzinden az olmamalidir)", ConsoleColor.Red);
            double tutum = CheckNum(benzin);

            Colored.WriteLine("100-e ne qeder yandirir?", ConsoleColor.Blue);
            double consumption = CheckNum(1);

            Car car = new(benzin, consumption, tutum);
            Menu(car);
        }
        public static void Menu(Car car)
        {
            Colored.WriteLine($@"
[1] Sur
[2] Zapravkaya gir
[3] Benzini goster
[4] Getdiyimiz yolu goster
[5] Cixis
", ConsoleColor.White);
            Colored.Write(">>>",ConsoleColor.Yellow);
            int choose = CheckChoose();
            Choose(choose, car);
        }

        public static void Choose(int choose, Car car)
        {
            Console.Clear();
            Console.WriteLine();
            switch (choose)
            {
                case 1:
                    Colored.WriteLine("Nece km yol gedek?", ConsoleColor.Blue);
                    double mile = CheckNum(1);
                    if (car.Fuel == 0)
                    {
                        Colored.WriteLine("Zapravkaya qeder itele...", ConsoleColor.Magenta);
                    }
                    else if (car.Drive(mile))
                    {
                        car.Fuel -= (mile * (car.FuelConsumption / 100));
                        Colored.WriteLine($"Qalan benzin: {car.Fuel}l",ConsoleColor.Yellow);
                        Car.MilAge += mile;
                        Colored.WriteLine($"Gedilen Yol: {Car.MilAge}km", ConsoleColor.Cyan);
                    }
                    else Colored.WriteLine("Bu yolu getmek mumkun deyil", ConsoleColor.Red);
                    Menu(car);
                    break;

                case 2:
                    if (car.Fuel == car.TankCapacity) Colored.WriteLine("Benzin full bakdir", ConsoleColor.Red);
                    else
                    {
                        Colored.Write("SO", ConsoleColor.Blue);
                        Colored.Write("C", ConsoleColor.Red);
                        Colored.Write("AR", ConsoleColor.Green);
                        Colored.WriteLine("-a xosh geldiniz", ConsoleColor.White);
                        Colored.WriteLine("Ne qeder dolduraq?", ConsoleColor.Blue);
                        double refuel = CheckNum(0);
                        if (car.Refuel(refuel))
                        {
                            car.Fuel += refuel;
                            Colored.WriteLine($"Doldu. Benzin: {car.Fuel}l",ConsoleColor.Yellow);
                        }
                        else Colored.WriteLine("Doldurmaq mumkun olmadi", ConsoleColor.Red);
                    }
                    Menu(car);
                    break;
                case 3:
                    Colored.WriteLine($"Benzin: { car.Fuel}l", ConsoleColor.Yellow);
                    Menu(car);
                    break;
                case 4:
                    Colored.WriteLine($"Getdiyimiz yol: {Car.MilAge}km", ConsoleColor.Cyan);
                    Menu(car);
                    break;
                case 5:
                    Colored.Write("See you again....",ConsoleColor.Magenta);
                    break;
            }
        }



        public static double CheckNum(double min)
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double num) && num > min) return num;
                else Colored.WriteLine("Yeniden daxil edin", ConsoleColor.Red);
            }
        }
        public static int CheckChoose()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num < 6) return num;
                else Colored.WriteLine("Bele emel movcud deyil, Basqasini yoxlayin", ConsoleColor.Red);
            }
        }
    }


}