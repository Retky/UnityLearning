using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHunger : MonoBehaviour
{
    public int hunger = 0;
    public int maxHunger = 6;
    public int hungerIncrease = 1;
    public int timeToAdd = 1;
    public int points = 10;
    public HungerBar hungerBar;
    public GameObject timeText;

    // Start is called before the first frame update
    void Start()
    {
        hungerBar.SetMaxHunger(maxHunger);
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food") && hunger < maxHunger)
        {
            IncreaseHunger();
        }
    }

    public void IncreaseHunger()
    {
        if (hunger < maxHunger)
        {
            hunger += hungerIncrease;
            hungerBar.SetHunger(hunger);
        }

        if (hunger == maxHunger)
        {
            FriendlyAnimal();
        }
    }

    private void FriendlyAnimal()
    {
        if (hunger == maxHunger)
        {
            gameObject.tag = "Friendly";
            Instantiate(timeText, transform.position, Quaternion.Euler(90, 0, 0));
            FindObjectOfType<GameManager>().AddTime(timeToAdd);
            FindObjectOfType<GameManager>().AddScore(points);
            gameObject.GetComponent<MoveForward>().speed = 8;
        }
    }
}
