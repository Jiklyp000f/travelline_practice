using System.Collections.Generic;
using System;
class NewTranslator
{
    private readonly Dictionary<string, string> translations;

    public NewTranslator()
    {
        translations = new Dictionary<string, string>();
    }

    public void Run()
    {
        Console.WriteLine("=== Переводчик ===");

        while ( true )
        {
            Console.WriteLine( "\nМеню: \n" +
                "1. Добавить перевод\n" +
                "2. Удалить перевод\n" +
                "3. Изменить перевод\n" +
                "4. Перевести слово\n" +
                "5. Выйти" );

            Console.Write( "Выберите команду: " );
            string? choice = Console.ReadLine();

            switch ( choice )
            {
                case "1":
                    AddTranslation();
                    break;
                case "2":
                    RemoveTranslation();
                    break;
                case "3":
                    ChangeTranslation();
                    break;
                case "4":
                    Translate();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine( "Неверная команда. Попробуйте еще раз." );
                    continue;
            }
        }
    }

    private void AddTranslation()
    {
        Console.Write( "Введите слово на русском: " );
        string? word = ReadLineWithCtrlZCheck();

        if ( word == null )
        {
            return;
        }

        Console.Write( "Введите перевод на английском: " );
        string? translation = ReadLineWithCtrlZCheck();

        if ( translation == null )
        {
            return;
        }

        translations[ word ] = translation;

        Console.WriteLine( "Перевод добавлен." );
    }

    private void RemoveTranslation()
    {
        Console.Write( "Введите слово на русском для удаления перевода: " );
        string word = Console.ReadLine();

        if ( translations.Remove( word ) )
        {
            Console.WriteLine( "Перевод удален." );
        }
        else
        {
            Console.WriteLine( "Перевод для указанного слова не найден." );
        }
    }

    private void ChangeTranslation()
    {
        Console.Write( "Введите слово на русском для изменения перевода: " );
        string word = Console.ReadLine();

        if ( translations.ContainsKey( word ) )
        {
            Console.Write( "Введите новый перевод на английском: " );
            string newTranslation = Console.ReadLine();

            translations[ word ] = newTranslation;

            Console.WriteLine( "Перевод изменен." );
        }
        else
        {
            Console.WriteLine( "Перевод для указанного слова не найден." );
        }
    }

    private void Translate()
    {
        Console.Write( "Введите слово на русском для перевода: " );
        string word = Console.ReadLine();

        if ( translations.TryGetValue( word, out string translation ) )
        {
            Console.WriteLine( $"Перевод: {translation}" );
        }
        else
        {
            Console.WriteLine( "Перевод для указанного слова не найден." );
        }
    }

    private string? ReadLineWithCtrlZCheck()
    {
        if ( !Console.KeyAvailable )
        {
            return Console.ReadLine();
        }

        var key = Console.ReadKey( intercept: true ).Key;
        if ( key == ConsoleKey.Z && ( ConsoleModifiers.Control & ConsoleModifiers.Control ) != 0 )
        {
            Console.WriteLine( "\nВыход из операции добавления по запросу пользователя." );
            return null;
        }

        return Console.ReadLine();
    }
}
