using System.Text.Json;
namespace Task5;

class Program
{
    static void Main(string[] args)
    {
        GameCharacter player = new GameCharacter
        {
            Name = "Raiten",
            Level = 75,
            Health = 102.3,
            Inventory = ["Sword", "Shield", "Potion"]
        };

        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(player, options);
        string path = Path.Combine(AppContext.BaseDirectory, "save.json");
        File.WriteAllText(path, json);

        string loadedJson = File.ReadAllText(path);

        Console.WriteLine(loadedJson);
        Console.WriteLine();

        GameCharacter player_2 = JsonSerializer.Deserialize<GameCharacter>(loadedJson)!;

        Console.WriteLine("=== Загруженный персонаж ===");
        Console.WriteLine($"Имя: {player_2.Name}");
        Console.WriteLine($"Уровень: {player_2.Level}");
        Console.WriteLine($"Здоровье: {player_2.Health}");
        Console.WriteLine($"Инвентарь: {string.Join(", ", player_2.Inventory)}");


    }

}

public class GameCharacter
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public double Health { get; set; }
    public string[] Inventory { get; set; } = [];
}

