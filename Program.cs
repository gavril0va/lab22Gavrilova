using System.Collections.Generic;

HashSet<string> excludedWords = new HashSet<string> { "и", "в", "на" };

Console.Write("Введите слово для добавления в исключения: ");
string addWord = Console.ReadLine() ?? "";
addWord = addWord.Trim().ToLower();

if (excludedWords.Add(addWord))
{
    Console.WriteLine("Исключение добавлено");
}
else
{
    Console.WriteLine("Такое исключение уже есть");
}

Console.Write("Введите слово для удаления из исключений: ");
string removeWord = Console.ReadLine() ?? "";
removeWord = removeWord.Trim().ToLower();

if (excludedWords.Remove(removeWord))
{
    Console.WriteLine("Исключение удалено");
}
else
{
    Console.WriteLine("Такого исключения нет");
}

Console.WriteLine("Количество исключений: " + excludedWords.Count);

Console.Write("Введите текст: ");
string text = Console.ReadLine() ?? "";

string[] words = text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> frequencies = new Dictionary<string, int>();
int skipped = 0;

foreach (string word in words)
{
    if (excludedWords.Contains(word))
    {
        skipped = skipped + 1;
    }
    else
    {
        AddWord(frequencies, word);
    }
}

Console.WriteLine();
Console.WriteLine(">>> Анализ слов <<<");
Console.WriteLine();
Console.WriteLine("Исходная строка: [" + text + "]");
Console.WriteLine("Всего слов: " + words.Length);
Console.WriteLine("Пропущено слов: " + skipped);
Console.WriteLine("Учтено слов: " + SumFrequencies(frequencies));
Console.WriteLine("Разных учтённых слов: " + frequencies.Count);
Console.WriteLine();
Console.WriteLine("Частоты слов:");
PrintFrequencies(frequencies);

Console.WriteLine();
Console.Write("Введите слово для поиска: ");
string searchWord = Console.ReadLine() ?? "";
searchWord = searchWord.Trim().ToLower();

if (frequencies.TryGetValue(searchWord, out int count))
{
    Console.WriteLine("Количество вхождений: " + count);
}
else
{
    Console.WriteLine("Слово не найдено");
}

void PrintFrequencies(Dictionary<string, int> frequencies)
{
    if (frequencies.Count == 0)
    {
        Console.WriteLine("Нет слов для анализа");
        return;
    }

    foreach (KeyValuePair<string, int> pair in frequencies)
    {
        Console.WriteLine(pair.Key + ": " + pair.Value);
    }
}

void AddWord(Dictionary<string, int> frequencies, string word)
{
    if (frequencies.ContainsKey(word))
    {
        frequencies[word] = frequencies[word] + 1;
    }
    else
    {
        frequencies.Add(word, 1);
    }
}

int SumFrequencies(Dictionary<string, int> frequencies)
{
    int sum = 0;

    foreach (KeyValuePair<string, int> pair in frequencies)
    {
        sum = sum + pair.Value;
    }

    return sum;
}
