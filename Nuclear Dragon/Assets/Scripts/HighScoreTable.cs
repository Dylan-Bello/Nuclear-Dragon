using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    void Awake()
    {
        Debug.Log(this.gameObject.name);
        //entryContainer = transform.Find("HighScoreEntryContainer");
        //entryTemplate = transform.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry{ score = 521854, name = "mark" },
            new HighScoreEntry{ score = 521854, name = "marrrk" },
            new HighScoreEntry{ score = 5854, name = "mrrrrk" },
            new HighScoreEntry{ score = 52854, name = "marrrk" },
            new HighScoreEntry{ score = 521854, name = "mark" },
            new HighScoreEntry{ score = 51854, name = "marrk" },

        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        
        
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("Rank").GetComponent<Text>().text = rankString;

        int Score = highscoreEntry.score;

        entryTransform.Find("Score").GetComponent<Text>().text = Score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("PlayerName").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);

        
    }
}

public class HighScoreEntry
{
    public int score;
    public string name;
}
