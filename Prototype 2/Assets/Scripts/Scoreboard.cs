using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
  private Transform entryContainer;
  private Transform entryTemplate;
  [SerializeField] private TMP_InputField nameInput;
  private List<ScoreEntry> scoreEntryList = new List<ScoreEntry>();

  private void Awake()
  {
    entryContainer = transform.Find("Score List");
    entryTemplate = entryContainer.Find("Score Template");

    entryTemplate.gameObject.SetActive(false);

    float templateHeight = 40f;

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

  public void AddScoreEntry()
  {
    int score = Mathf.RoundToInt(GameManager.score);
    Debug.Log(score);
    string name = nameInput.text;
    Debug.Log(name);
    // Create ScoreEntry
    ScoreEntry scoreElement = new ScoreEntry { score = score, name = name };

    // Add to list
    scoreEntryList.Add(scoreElement);
    Debug.Log(scoreEntryList.Count);
  }

  public void SaveScoreList()
  {

  }

  public void LoadScoreList()
  {

  }

  class ScoreEntry
  {
    public int score;
    public string name;
  }
}
