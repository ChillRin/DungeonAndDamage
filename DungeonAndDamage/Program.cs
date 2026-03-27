namespace DungeonAndDamege;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Загрузка мира...");
        // Создание противников
        Enemy[] enemies = {
            new Enemy("Стая слизней", 20, 1, 0.25f),
            new Enemy("Большой слизень", 10, 4, 0.75f),
            new Enemy("Гоблин мечник", 15, 5, 1f),
            new Enemy("Гоблин копейщик", 10, 10, 1.25f),
            new Enemy("Король гоблинов", 30, 10, 2f)
        };
        Console.WriteLine("- Противники загружены");
        
        // Создание колекции персонажей
        object[,] person_storage = {
            // Teamate object, rarity float
            { new Teammate("Мечник", 10, 5, 10, 0.5f), 20 },
            { new Teammate("Лучник", 10, 1, 5, 0.5f), 40 },
            { new Teammate("Щитовик", 10, 3, 20, 0.5f), 60 },
        };
        
        
        // Приветствие с игроком
        bool work = true;
        while (work) {
            
        }
    }
}