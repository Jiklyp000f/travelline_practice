while (true)
{
    Console.WriteLine("Выберите одну из команд(от 1 до 4):\n" +
    "1. Добавить перевод\n" +
    "2. Удалить перевод русского слова\n" +
    "3. Изменить перевод русского слова\n" +
    "4. Перевести русское слово на английский\n" +
    "5. Выход");
    char znachenie = Convert.ToChar(Console.ReadLine());
    switch (znachenie)
    {
        case '1':
            Console.WriteLine("Добавить перевод:");
            break;
        case '2':
            Console.WriteLine("Удалить перевод русского слова:");
            break;
        case '3':
            Console.WriteLine("Изменить перевод русского слова: ");
            break;
        case '4':
            Console.WriteLine("Перевод: ");
            break;
        case '5': 
            return;
        default:
            Console.WriteLine("Неверное значение!");
            break;
    }
}
