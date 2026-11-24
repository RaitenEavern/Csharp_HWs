using System.Text.Json;
namespace Task6;

class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine(AppContext.BaseDirectory, "settings.json");

        if (File.Exists(path))
        {
            string loadedSettings = File.ReadAllText(path);
            GameSettings settings = JsonSerializer.Deserialize<GameSettings>(loadedSettings)!;

            Console.WriteLine("Текущие настройки:");
            Console.WriteLine($"PlayerName: {settings.PlayerName}");
            Console.WriteLine($"Difficulty: {settings.Difficulty}");
            Console.WriteLine($"MusicVolume: {settings.MusicVolume}");

        }
        else
        {
            Console.WriteLine("Файл настроек не найден. Создаём новые настройки.");
            GameSettings settings = new GameSettings();
            Console.WriteLine("Введите данные:");

            Console.Write("PlayerName: ");
            settings.PlayerName = Console.ReadLine()!;
            Console.WriteLine();

            Console.Write("Difficulty (1 — легко, 2 — нормально, 3 — сложно): ");
            settings.Difficulty = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            Console.Write("MusicVolume (0–100): ");
            settings.MusicVolume = int.Parse(Console.ReadLine()!);
            Console.WriteLine();

            JsonSerializerOptions options = new JsonSerializerOptions{WriteIndented = true};
            string json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(path, json);



        }
    }
}

public class GameSettings
{
    public string PlayerName { get; set; } = "";
    public int Difficulty { get; set; }
    public int MusicVolume { get; set; }
}