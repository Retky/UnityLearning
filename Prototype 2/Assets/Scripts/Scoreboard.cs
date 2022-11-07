using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Scoreboard : MonoBehaviour
{
  private Transform entryContainer;
  private Transform entryTemplate;
  [SerializeField] private GameObject pluginManager;
  [SerializeField] private TMP_InputField nameInput;
  public ScoreList scoreList;
  private float templateHeight = 40f;

  private void Start()
  {
    pluginManager.GetComponent<PluginManager>().loadScore();
  }

  private void Awake()
  {
    entryContainer = transform.Find("Score List");
    entryTemplate = entryContainer.Find("Score Template");

    entryTemplate.gameObject.SetActive(false);
  }

  private void UpdateBoard()
  {
    foreach (Transform child in entryContainer)
    {
      if (child == entryTemplate) continue;
      Destroy(child.gameObject);
    }

    scoreList.scoreEntryList.Sort((a, b) => b.score.CompareTo(a.score));

    for (int i = 0; i < 10; i++)
    {
      if (i >= scoreList.scoreEntryList.Count) break;
      Transform entryTransform = Instantiate(entryTemplate, entryContainer);
      RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
      entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
      entryTransform.gameObject.SetActive(true);

      entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
      entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = scoreList.scoreEntryList[i].name;
      entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = scoreList.scoreEntryList[i].score.ToString();
    }
  }

  public void AddScoreEntry()
  {
    int score = Mathf.RoundToInt(GameManager.score);
    string name = nameInput.text;

    // Create ScoreEntry
    ScoreEntry scoreElement = new ScoreEntry { score = score, name = name };

    // Add to list
    scoreList.scoreEntryList.Add(scoreElement);

    SaveScoreList();
    UpdateBoard();
  }

  public void SaveScoreList()
  {
    pluginManager.GetComponent<PluginManager>().SaveScore(JsonUtility.ToJson(scoreList));
  }

  public void LoadScoreList(string str)
  {
    Debug.Log(str);
    scoreList = JsonUtility.FromJson<ScoreList>(str);
    UpdateBoard();
  }
}

[Serializable]
public class ScoreList
{
  public List<ScoreEntry> scoreEntryList = new List<ScoreEntry>();
}

[Serializable]
public class ScoreEntry
{
  public int score;
  public string name;
}
