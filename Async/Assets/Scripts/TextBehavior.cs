using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Using for the Task class(allow us to return a value in the async methods)
using System.Threading.Tasks;
// Using for the text object
using TMPro;

// This should control the text that appears on the screen and change it based on the player's actions
public class TextBehavior : MonoBehaviour
{
    // Initialize the import variables
    // Serializable to show in inspector but private since it's only used in this script.
    [SerializeField] private TextMeshProUGUI displayText;

    // Start is called before the first frame update
    async void Start()
    {
        // Using the ContThreeSeconds function return string change the displayText
        displayText.text = await CountThreeSeconds();
        // This log show that Start is waiting for the CountThreeSeconds function to finish
        Debug.Log("Start: CountThreeSeconds finished");

        AutoChangeText();
        Debug.Log("Start: AutoChangeText finished");
    }

    // This method will get an integer and return diferent strings based on the integer value
    async Task<string> CountThreeSeconds()
    {
        Debug.Log("CountThreeSeconds called");
        // Promise to return a string if successful
        try
        {
            int number = await GetRandomInteger();
            Debug.Log("Success");
            return $"The number is {number}";
        }
        // If the promise fails it will log the error and return the error message.
        catch (System.Exception e)
        {
            Debug.Log(e);
            return $"{e.Message}";
        }
    }

    // This method will change the displayText insted of returning the string
    public async void AutoChangeText()
    {
        Debug.Log("AutoChangeText called");

        try {
            int number = await GetRandomInteger();
            Debug.Log("Success");
            displayText.text = $"Now the number is {number}";
        } catch (System.Exception e)
        {
            Debug.Log(e);
            displayText.text = $"Now {e.Message}";
        }
    }
    
    // This method will return a random odd integer between 0 and 10 after 3 seconds or throw an exception if the number is even
    public async Task<int> GetRandomInteger()
    {
        Debug.Log("GetRandomInteger called");
        // Set a random number between 1 and 10
        int randomInt = Random.Range(1, 10);
        Debug.Log($"GetRandomInteger: Random number is {randomInt}");

        // Wait for 1.5 seconds
        await Task.Yield();

        // Return the random number if it's odd
        if (randomInt % 2 == 1)
        {
            return randomInt;
        } else
        {
            // Throw an exception if the number is even
            throw new System.Exception("The number is even");
        }
    }
}
