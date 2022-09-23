using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHunger : MonoBehaviour
{
    public int hunger = 0;
    public int maxHunger = 6;
    public int hungerIncrease = 1;
    public HungerBar hungerBar;

    // Start is called before the first frame update
    void Start()
    {
        hungerBar.SetMaxHunger(maxHunger);
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger == maxHunger)
        {
            gameObject.tag = "Friendly";
            gameObject.GetComponent<MoveForward>().speed = 8;
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
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
    }
}
