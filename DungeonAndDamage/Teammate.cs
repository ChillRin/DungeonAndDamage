namespace DungeonAndDamege;

public class Teammate : Creature {
    public Teammate(string name, int health, int damage, int armour, float salary) : base(name, health, damage) {
        Armour = armour;
        MaxHealth = health;
        MaxArmour = armour;
    }

    private int armour;
    private float salary;
    
    private int maxHealth;
    private int maxArmour;
    
    private bool alive = true;
    
    public int Armour {
        get => armour;
        private set => armour = value;
    }
    
    public float Salary {
        get => salary;
        private set => salary = value; 
    }
    
    public int MaxHealth {
        get => maxHealth;
        private set => maxHealth = value;
    }

    public int MaxArmour {
        get => maxArmour;
        private set => maxArmour = value;
    }
    
    public bool Alive {
        get => alive;
        private set => alive = value;
    }

    public void Heal(int health, int armour) {
        Health += health;
        Armour += armour;

        if (Health > maxHealth) {
            Health = MaxHealth;
        }

        if (Armour > maxArmour) {
            Armour = MaxArmour;
        }
    }

    public void Heal(int health) {
        Health += health;

        if (Health > maxHealth) {
            Health = MaxHealth;
        }
    }

    public override void ApplyDamage(int damage) {
        Health -= damage;
        if (Health <= 0) {
            Alive = false;
        }
    }
}