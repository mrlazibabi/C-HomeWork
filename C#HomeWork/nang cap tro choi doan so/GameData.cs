
public class GameData
{
    public Record record { get; set; }
    public Record[] history { get; set; } = Array.Empty<Record>(); 

    public GameData() { }

    public void AddHistory(Record newRecord)
    {
        int length = history.Length;
        Record[] newHistory = new Record[length + 1]; 

        for (int i = 0; i < length; i++)
        {
            newHistory[i] = history[i]; 
        }

        newHistory[length] = newRecord; 
        history = newHistory; 
    }
}

public record Record(string name, int attempts);