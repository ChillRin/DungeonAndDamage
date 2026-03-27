namespace DungeonAndDamege;

public class Teammate : Creature {
    public Teammate(string name, int health, int damage, int armour, float salary) : base(name, health, damage) {
        Armour = armour;
    }

    private int armour;
    private float salary;
    
    public int Armour {
        get { return armour; }
        private set { armour = value; }
    }
    
    public float Salary {
        get { return salary; }
        private set { salary = value; }
    }
}