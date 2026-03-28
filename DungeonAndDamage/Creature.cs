namespace DungeonAndDamege;

public abstract class Creature {
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
        protected set { health = value; }
    }
    
    public int Damage {
        get { return damage; }
        protected set { damage = value; }
    }
    
    public abstract void ApplyDamage(int damage);
}