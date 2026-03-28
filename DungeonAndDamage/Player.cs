namespace DungeonAndDamege;

public class Player {
    public Player(string name) {
        Name = name;
    }
    
    public List<Teammate> teammates = new List<Teammate> {};
    public Teammate[] in_actions = new Teammate[5];
    private string name;
    public string Name { get => name; set => name = value; }
    
    private float gold = 1;
    public float Gold { get => gold; set => gold = value; }

    public void Salary(float salary) {
        Gold += salary;
    }
}