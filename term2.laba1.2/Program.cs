using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            {"apple", 2},
            {"orange", 4},
            {"banana", 3},
            {"pineapple", 5}
        };

        Dictionary<string, int> multipliedAndSortedDictionary = MultiplyAndSortDictionary(dictionary);

        PrintSortedDictionary(multipliedAndSortedDictionary);

        SaveToJsonFile(multipliedAndSortedDictionary, "result.json");
    }

    static Dictionary<string, int> MultiplyAndSortDictionary(Dictionary<string, int> inputDictionary)
    {
        int multiplicationResult = inputDictionary.Values.Aggregate((a, b) => a * b);

        Dictionary<string, int> resultDictionary = inputDictionary.ToDictionary(pair => pair.Key, pair => pair.Value * multiplicationResult);

        resultDictionary = resultDictionary.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        return resultDictionary;
    }

    static void PrintSortedDictionary(Dictionary<string, int> sortedDictionary)
    {
        foreach (var pair in sortedDictionary)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }

    static void SaveToJsonFile(Dictionary<string, int> dictionary, string filePath)
    {
        string jsonString = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine($"Відсортований словник збережено у файл {filePath}");
    }
}