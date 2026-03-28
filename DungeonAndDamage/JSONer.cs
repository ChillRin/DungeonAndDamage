using Newtonsoft.Json;

namespace DungeonAndDamege;

public class JSONer {
    public JSONer() {}

    public object LoadPerson() {
        if (File.Exists("person.json")) {
            string json = File.ReadAllText("person.json");
            return JsonConvert.DeserializeObject<Player>(json);
        }
        else {
            return null;
        }
    }

    public void SavePerson(object person) {
        string json = JsonConvert.SerializeObject(person);
        File.WriteAllText("person.json", json);
    }
}