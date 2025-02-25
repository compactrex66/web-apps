// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

void cw1() {
    Console.Write("Podaj a: ");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Liczba {number} podniesiona do kwadratu: {number * number}");
}

void cw2() {
    double number1, number2;
    try {
        Console.Write("Podaj a: ");
        number1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj b: ");
        number2 = Convert.ToDouble(Console.ReadLine());
    } catch(FormatException exception) {
        Console.WriteLine("Podaj liczbę");
        return;
    }
    Console.Write($"{number1} + {number2} = {number1 + number2} \n{number1} - {number2} = {number1 - number2} \n{number1} * {number2} = {number1 * number2} \n{number1} / {number2} = " + ((number2 != 0) ? (number1 / number2) : "Nie można dzielić przez zero"));
}

void cw3() {
    int number1;
    Console.Write("Podaj liczbę: ");
    number1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine((number1 < 0) ? "Nie można pierwiastkować liczby mniejszej niż 0" : Math.Sqrt(number1));
}

void cw4() {
    double a, b, c;
    try {
        Console.Write("Podaj a: ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj b: ");
        b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Podaj c: ");
        c = Convert.ToDouble(Console.ReadLine());
    } catch(FormatException exception) {
        Console.WriteLine(exception.Message);
        return;
    }
    double delta = b * b - 4 * a * c;
    if (delta > 0) { 
        double sqrtDelta = Math.Sqrt(delta);
        double x1 = ((b * -1) - sqrtDelta) / (2 * a);
        double x2 = ((b * -1) + sqrtDelta) / (2 * a);
        Console.WriteLine($"x1: {x1} \nx2: {x2}");
    } else if(delta == 0) {
        double sqrtDelta = Math.Sqrt(delta);
        double x1 = ((b * -1) - sqrtDelta) / 2 * a;
        Console.WriteLine($"x1: {x1}");
    } else {
        Console.WriteLine("Nie ma żadnych pierwiastków");
    }
}

cw4();