using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Serialized fields for UI elements and GameObjects, settable in Unity Editor
    [SerializeField]
    private Text lifeTxt; // Text field to display player's life
    [SerializeField]
    private Text scoreTxt; // Text field to display player's score
    [SerializeField]
    private Text bestScoreTxt; // Text field to display player's best score
    [SerializeField]
    private Text nameTxt; // Text field to display player's name
    [SerializeField]
    private GameObject gameOverPanel; // Panel shown when the game is over
    [SerializeField]
    private GameObject newRecordPanel; // Panel shown when a new record is set
    [SerializeField]
    private List<GameObject> foodList = new List<GameObject>(); // List of food GameObjects

    // Private variables to store player information
    private string namePlayer;
    private int lifePlayer;
    private int scorePlayer;
    private int bestScorePlayer;

    // GameObject references
    private GameObject player; // Player GameObject
    private GameObject menuManager; // MenuManager GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Find and set the player and menu manager GameObjects, with error checking
        if (GameObject.Find("Ghost") != null)
        {
            player = GameObject.Find("Ghost");
            InvokeRepeating("InstantiateFood", 3.0f, 1f); // Repeatedly call InstantiateFood
        }
        else { Debug.LogWarning("The Ghost can't be found."); }

        if (GameObject.Find("MenuController") != null)
        {
            menuManager = GameObject.Find("MenuController");
            // Set player's name and best score from MenuManager
            player.GetComponent<PlayerManager>().Pname = menuManager.GetComponent<MenuManager>().Pname;
            player.GetComponent<PlayerManager>().BestScore = menuManager.GetComponent<MenuManager>().BestScore;
        }
        else { Debug.LogWarning("The Menu Manager can't be found."); }
    }

    // Update is called once per frame
    void Update()
    {
        // Update gameplay elements if player is not null
        if (player != null)
        {
            AsignPlayerFields();
            UpdateTextBox(lifePlayer, scorePlayer, bestScorePlayer, namePlayer);
            CheckNewRecord();
            CheckAlive();
        }
        else { Debug.LogWarning("The Ghost can't be found."); }
    }

    // Check if the player has set a new record
    void CheckNewRecord()
    {
        if (player.GetComponent<PlayerManager>().BestScore < player.GetComponent<PlayerManager>().Score)
        {
            player.GetComponent<PlayerManager>().BestScore = player.GetComponent<PlayerManager>().Score;
            menuManager.GetComponent<MenuManager>().BestScore = player.GetComponent<PlayerManager>().Score;
            newRecordPanel.SetActive(true);
            Invoke("DesactiveNewRecord", 2.0f); // Deactivate new record panel after 2 seconds
        }
    }

    // Check if the player is still alive
    void CheckAlive()
    {
        if (player.GetComponent<PlayerManager>().Life <= 0)
        {
            gameOverPanel.SetActive(true);
            menuManager.GetComponent<MenuManager>().SavePrefs(bestScorePlayer, namePlayer);
            Destroy(player); // Destroy player GameObject
        }
    }

    // Assign player fields from the PlayerManager component
    void AsignPlayerFields()
    {
        lifePlayer = player.GetComponent<PlayerManager>().Life;
        scorePlayer = player.GetComponent<PlayerManager>().Score;
        bestScorePlayer = player.GetComponent<PlayerManager>().BestScore;
        namePlayer = player.GetComponent<PlayerManager>().Pname;
    }

    // Update the UI text boxes with player data
    void UpdateTextBox(int life, int score, int bScore, string name)
    {
        lifeTxt.text = "X" + life;
        scoreTxt.text = "Score: " + score;
        bestScoreTxt.text = "Best Score: " + bScore;
        nameTxt.text = name.ToUpper();
    }

    // Instantiate food at random positions
    void InstantiateFood()
    {
        if (player != null)
        {
            int i = Random.Range(0, foodList.Count);
            GameObject obj = new GameObject();
            obj.transform.position = RandomPos(); // Set random position
            GameObject gameObject = Instantiate(foodList[i], obj.transform);
            Destroy(gameObject, 10f); // Destroy food after 10 seconds
            Destroy(obj, 10f); // Destroy temporary object after 10 seconds
        }
        else { Debug.Log("Dead"); }
    }

    // Deactivate the new record panel
    void DesactiveNewRecord()
    {
        newRecordPanel.SetActive(false);
    }

    // Generate a random position for food spawning
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-8, 8), 9, 0);
    }

    // Load the main game scene
    public void LoadMainScene()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("main");
    }

    // Exit the application and save preferences
    public void ExitAplication()
    {
        menuManager.GetComponent<MenuManager>().SavePrefs(bestScorePlayer, namePlayer);
        Application.Quit();
    }
}
