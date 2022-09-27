using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int dificulty;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

    }

    void SetDifficulty()
    {
        gameManager.StartGame(dificulty);
    }
}
