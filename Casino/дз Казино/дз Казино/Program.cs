int balance = 10000;
Random random = new Random();
Console.WriteLine($"Добро пожаловать в ИГРУ! Ваш счёт составляет {balance} у.е. Приятной игры!");
int stavka;
while (balance > 0)
{
    Console.WriteLine("Введите ставку: ");
    stavka = Convert.ToInt32(Console.ReadLine());
    while (stavka <= 0 | stavka > balance)
    {
        Console.WriteLine("Введите ставку: ");
        stavka = Convert.ToInt32(Console.ReadLine());
    }
    int randomNumber = random.Next(0, 21);
    int multiplicator = random.Next(1, 5);
    if (randomNumber > 0 & randomNumber < 18)
    {
        balance = balance - stavka;
        Console.WriteLine($"Вы проиграли! Ваш баланс составляет {balance} у.е.");
    }
    else
    {
        balance = balance + (stavka * (1 + (multiplicator * randomNumber % 17)));
        Console.WriteLine($"Вы ВЫИГРАЛИ! Ваш баланс составляет {balance} у.е");
    }
}
Console.WriteLine($"Увы! Ваш счёт составляет {balance} у.е.!");
