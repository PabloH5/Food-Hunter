using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text lifeTxt;
    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private Text bestScoreTxt;

    [SerializeField]
    private Text nameTxt;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject newRecordPanel;

    [SerializeField]
    private List<GameObject> foodList = new List<GameObject>();

    private string namePlayer;

    private int lifePlayer;
    private int scorePlayer;
    private int bestScorePlayer;

    private GameObject player;
    private GameObject menuManager;
    void Start()
    {
        if (GameObject.Find("Ghost") != null)
        {
            player = GameObject.Find("Ghost");
            InvokeRepeating("InstantiateFood", 3.0f, 1f);
        }
        else { Debug.LogWarning("The Ghost can't be found."); }

        if (GameObject.Find("MenuController") != null)
        {
            menuManager = GameObject.Find("MenuController");
            player.GetComponent<PlayerManager>().Pname = menuManager.GetComponent<MenuManager>().Pname;
            player.GetComponent<PlayerManager>().BestScore = menuManager.GetComponent<MenuManager>().BestScore;
        }
        else { Debug.LogWarning("The Menu Manager can't be found."); }

    }
    void Update()
    {
        if (player != null)
        {
            AsignPlayerFields();
            UpdateTextBox(lifePlayer, scorePlayer, bestScorePlayer, namePlayer);
            CheckNewRecord();
            CheckAlive();
        }
        else { Debug.LogWarning("The Ghost can't be found."); }
    }
    void CheckNewRecord()
    {
        if (player.GetComponent<PlayerManager>().BestScore < player.GetComponent<PlayerManager>().Score)
        {
            player.GetComponent<PlayerManager>().BestScore = player.GetComponent<PlayerManager>().Score;
            menuManager.GetComponent<MenuManager>().BestScore = player.GetComponent<PlayerManager>().Score;
            newRecordPanel.SetActive(true);
            Invoke("DesactiveNewRecord", 2.0f);
        }
    }
    void CheckAlive()
    {
        if (player.GetComponent<PlayerManager>().Life <= 0)
        {
            gameOverPanel.SetActive(true);
            menuManager.GetComponent<MenuManager>().SavePrefs(bestScorePlayer, namePlayer);
            Destroy(player);
        }
    }
    void AsignPlayerFields()
    {
        lifePlayer = player.GetComponent<PlayerManager>().Life;
        scorePlayer = player.GetComponent<PlayerManager>().Score;
        bestScorePlayer = player.GetComponent<PlayerManager>().BestScore;
        namePlayer = player.GetComponent<PlayerManager>().Pname;
    }
    void UpdateTextBox(int life, int score, int bScore, string name)
    {
        lifeTxt.text = "X" + life;
        scoreTxt.text = "Score: " + score;
        bestScoreTxt.text = "Best Score: " + bScore;
        nameTxt.text = name.ToUpper();
    }
    void InstantiateFood()
    {
        if (player != null)
        {
            int i = Random.Range(0, foodList.Count);
            GameObject obj = new GameObject();
            obj.transform.position = RandomPos();
            GameObject gameObject = Instantiate(foodList[i], obj.transform);
            Destroy(gameObject, 10f);
            Destroy(obj, 10f);
        }
        else { Debug.Log("Dead"); }
    }
    void DesactiveNewRecord()
    {
        newRecordPanel.SetActive(false);
    }
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-8, 8), 9, 0);
    }
    public void LoadMainScene()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("main");
    }
    public void ExitAplication()
    {
        menuManager.GetComponent<MenuManager>().SavePrefs(bestScorePlayer, namePlayer);
        Application.Quit();
    }
}
