using System.Text.Json;
namespace Task4;

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

        JsonSerializerOptions options = new JsonSerializerOptions{WriteIndented = true};
        string json = JsonSerializer.Serialize(player, options);
        Console.WriteLine(json);
        Console.WriteLine();

        GameCharacter player_2 = JsonSerializer.Deserialize<GameCharacter>(json);

        Console.WriteLine($"Name: {player_2.Name}");
        Console.WriteLine($"Inventory: {player_2.Inventory.Length}");


    }

}

public class GameCharacter
{
    public string Name { get; set; }
    public int Level { get; set; }
    public double Health { get; set; }
    public string[] Inventory { get; set; }
}

