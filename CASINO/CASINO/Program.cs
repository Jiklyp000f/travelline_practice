﻿int balance = 10000;
Random random = new Random();
Console.WriteLine( $"Добро пожаловать в ИГРУ! Ваш счёт составляет {balance} у.е. Приятной игры!" );

while ( balance > 0 )
{
    Console.WriteLine( "Введите ставку: " );
    if ( !int.TryParse( Console.ReadLine(), out int bet ) || bet < 1 || bet > balance )
    {
        Console.WriteLine( $"Некорректное значение! Пожалуйста, введите допустимую ставку (Она не должна быть больше {balance} y.e. и не меньше нуля)." );
        continue;
    }

    int randomNumber = random.Next( 0, 21 );
    int multiplicator = random.Next( 1, 5 );

    if ( randomNumber < 18 )
    {
        balance -= bet;
        Console.WriteLine( $"Вы проиграли! Ваш баланс составляет {balance} у.е." );
    }
    else
    {
        balance += bet * ( 1 + multiplicator * randomNumber % 17 );
        Console.WriteLine( $"Вы ВЫИГРАЛИ! Ваш баланс составляет {balance} у.е" );
    }
}

Console.WriteLine( $"Увы! Ваш счёт составляет {balance} у.е.!" );
