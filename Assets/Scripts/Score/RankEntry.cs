[System.Serializable]
public class RankEntry
{
    public string playerName;
    public int score;

    public RankEntry(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}