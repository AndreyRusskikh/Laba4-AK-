using System;
using System.IO;

class Program
{
    static void DeleteFilesInDirectory(string directoryPath, string[] filesToDelete)
    {
        try
        {
            foreach (string file in filesToDelete)
            {
                string filePath = Path.Combine(directoryPath, file);

                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal); // Снимаем атрибуты файла перед удалением
                    File.Delete(filePath);
                    Console.WriteLine($"Удален файл: {filePath}");
                }
                else
                {
                    Console.WriteLine($"Файл не найден: {filePath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении файлов: {ex.Message}");
            Environment.ExitCode = 1; // Устанавливаем код завершения в 1 в случае ошибки
        }
    }

    static void Main()

    {

        Console.WriteLine("Введите каталог для удаления");

        string directoryPath = Console.ReadLine();

        if (directoryPath.Length < 1)
        {
            Console.WriteLine("Не указан каталог. Используйте: <путь_к_каталогу>");
            Environment.ExitCode = 1; // Устанавливаем код завершения в 1 в случае ошибки
            return;
        }


        Console.WriteLine($"Удаление файлов из каталога: {directoryPath}");
        Console.WriteLine("Выберите режим удаления:");
        Console.WriteLine("1. Удалить все файлы");
        Console.WriteLine("2. Удалить конкретные файлы");

        string input = Console.ReadLine();

        if (input == "1")
        {
            DeleteFilesInDirectory(directoryPath, Directory.GetFiles(directoryPath));
        }
        else if (input == "2")
        {
            Console.WriteLine("Введите имена файлов для удаления (разделяйте пробелом):");
            string fileNamesInput = Console.ReadLine();
            string[] filesToDelete = fileNamesInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            DeleteFilesInDirectory(directoryPath, filesToDelete);
        }
        else
        {
            Console.WriteLine("Неверный ввод. Режим удаления будет установлен по умолчанию (2)");
        }
    }
}
