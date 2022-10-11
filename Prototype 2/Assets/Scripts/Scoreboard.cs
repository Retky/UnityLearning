using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
  private Transform entryContainer;
  private Transform entryTemplate;
  private List<ScoreEntry> scoreEntryList = new List<ScoreEntry>();

  private void Awake()
  {
    entryContainer = transform.Find("Score List");
    entryTemplate = entryContainer.Find("Score Template");

    entryTemplate.gameObject.SetActive(false);

    float templateHeight = 40f;

    AddScoreEntry(1000, "AAA");
    AddScoreEntry(900, "BBB");
    AddScoreEntry(400, "CCC");
    AddScoreEntry(1200, "DDD");
    AddScoreEntry(500, "EEE");
    AddScoreEntry(700, "FFF");
    AddScoreEntry(800, "GGG");
    AddScoreEntry(900, "HHH");
    AddScoreEntry(1000, "III");
    AddScoreEntry(1100, "JJJ");

    scoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

    scoreEntryList.ForEach(scoreEntry =>
    {
      Transform entryTransform = Instantiate(entryTemplate, entryContainer);
      RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
      entryRectTransform.anchoredPosition = new Vector2(0, -(templateHeight * scoreEntryList.IndexOf(scoreEntry)));
      entryTransform.gameObject.SetActive(true);

      entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = (scoreEntryList.IndexOf(scoreEntry) + 1).ToString();
      entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = scoreEntry.score.ToString();
      entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = scoreEntry.name;
    });
  }

  public void AddScoreEntry(int score, string name)
  {
    // Create ScoreEntry
    ScoreEntry scoreElement = new ScoreEntry { score = score, name = name };

    // Add to list
    scoreEntryList.Add(scoreElement);
  }

  class ScoreEntry
  {
    public int score;
    public string name;
  }
}
