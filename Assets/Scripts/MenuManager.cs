using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Drawing;

public class MenuManager : MonoBehaviour
{
    // Serialized fields allow these private variables to be set in the Unity Editor
    [SerializeField]
    private InputField nameTxt; // Input field for player's name
    [SerializeField]
    private Text bestScoreTxt; // Text field to display the best score

    // Public variables to store player name and best score
    public string pName;
    public string Pname
    {
        get { return pName; } // Getter for player name
        set { pName = value; } // Setter for player name
    }

    private int bestScore = 0; // Default best score
    public int BestScore
    {
        get { return bestScore; } // Getter for best score
        set { bestScore = value; } // Setter for best score
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // Prevents the object from being destroyed when scenes change
        LoadPrefs(); // Load player preferences (name and best score) at start
    }

    // Updates player name from input field and displays it with the best score
    public void GetNameFromInputField()
    {
        Pname = nameTxt.text; // Update player name
        bestScoreTxt.text = "BEST SCORE: " + Pname.ToUpper() + " | " + BestScore; // Display best score with player name
    }

    // Loads the main game scene
    public void LoadMainScene()
    {
        SceneManager.LoadScene("main"); // Load the scene named "main"
    }

    // Quits the application
    public void ExitApplication()
    {
        Application.Quit(); // Closes the application
    }

    // Saves player preferences (best score and name) to local storage
    public void SavePrefs(int bs, string nm)
    {
        PlayerPrefs.SetInt("bestScore", bs); // Save best score
        PlayerPrefs.SetString("pName", nm); // Save player name
        PlayerPrefs.Save(); // Commit changes to local storage
    }

    // Loads player preferences (best score and name) from local storage
    public void LoadPrefs()
    {
        bestScore = PlayerPrefs.GetInt("bestScore", bestScore); // Load best score, default to current bestScore
        pName = PlayerPrefs.GetString("pName", pName); // Load player name, default to current pName
    }
}
