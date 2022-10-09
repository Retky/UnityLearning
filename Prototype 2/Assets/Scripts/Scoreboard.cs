using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
  private Transform entryContainer;
  private Transform entryTemplate;

  private void Awake()
  {
    entryContainer = transform.Find("Score List");
    entryTemplate = entryContainer.Find("Score Template");

    entryTemplate.gameObject.SetActive(false);

    float templateHeight = 40f;

    for (int i = 0; i < 10; i++)
    {
      Transform entryTransform = Instantiate(entryTemplate, entryContainer);
      RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
      entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
      entryTransform.gameObject.SetActive(true);

      int rank = i + 1;
      string rankString;
      switch (rank)
      {
        default:
          rankString = rank + "TH";
          break;
        case 1:
          rankString = "1ST";
          break;
        case 2:
          rankString = "2ND";
          break;
        case 3:
          rankString = "3RD";
          break;
      }

      entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = rankString;

      int score = Random.Range(0, 100);
      entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();

      string name = "AAA";
      entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
    }
  }

  private class ScoreEntry
  {
    public int score;
    public string name;
  }
}
