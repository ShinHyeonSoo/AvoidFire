using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingManager : MonoBehaviour
{
    private const int maxRankCount = 5; // 최대랭킹
    public TMP_Text[] nameTexts; // 이름
    public TMP_Text[] scoreTexts; // 점수

    private List<RankEntry> rankList = new List<RankEntry>();

    private void Start()
    {
        LoadRanking();
        UpdateRankingUI();
    }

    public void AddNewScore(string playerName, int score)
    {
        RankEntry newEntry = new RankEntry(playerName, score);
        rankList.Add(newEntry);

        rankList.Sort((entry1, entry2) => entry2.score.CompareTo(entry1.score));

        if (rankList.Count > maxRankCount)
        {
            rankList.RemoveAt(rankList.Count - 1);
        }

        SaveRanking();
        UpdateRankingUI();
    }

    private void SaveRanking()
    {
        for (int i = 0; i < rankList.Count; i++)
        {
            PlayerPrefs.SetString($"RankName{i}", rankList[i].playerName);
            PlayerPrefs.SetInt($"RankScore{i}", rankList[i].score);
        }
        PlayerPrefs.Save();
    }

    private void LoadRanking()
    {
        rankList.Clear();

        for (int i = 0; i < maxRankCount; i++)
        {
            if (PlayerPrefs.HasKey($"RankName{i}") && PlayerPrefs.HasKey($"RankScore{i}"))
            {
                string playerName = PlayerPrefs.GetString($"RankName{i}");
                int score = PlayerPrefs.GetInt($"RankScore{i}");
                rankList.Add(new RankEntry(playerName, score));
            }
        }
    }

    private void UpdateRankingUI()
    {
        for (int i = 0; i < maxRankCount; i++)
        {
            if (i < rankList.Count)
            {
                nameTexts[i].text = rankList[i].playerName;
                scoreTexts[i].text = rankList[i].score.ToString();
            }
            else
            {
                nameTexts[i].text = "---";
                scoreTexts[i].text = "---";
            }
        }
    }
}
