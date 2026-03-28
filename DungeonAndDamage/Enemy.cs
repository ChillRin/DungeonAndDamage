namespace DungeonAndDamege;

public class Enemy : Creature {

    public Enemy(string name, int health, int damage, float reward) : base(name, health, damage)  {
        Reward = reward;
    }
    
    private float reward;
    
    public float Reward {
        get { return reward; }
        private set { reward = value; }
    }
    
    public override void ApplyDamage(int damage) {
        Health -= damage;
    }
}