namespace DungeonAndDamege;

public class Creature {
    public Creature() {}
    public Creature(string name, int health, int damage) {
        Name = name;
        Health = health;
        Damage = damage;
    }
    
    private string name;
    private int health;
    private int damage;

    public string Name {
        get { return name; }
        private set { name = value; }
    }
    
    public int Health {
        get { return health; }
        private set { health = value; }
    }
    
    public int Damage {
        get { return damage; }
        private set { damage = value; }
    }

    public int doDamage(int damage) {
        Health -= damage;
        return Health;
    }
}