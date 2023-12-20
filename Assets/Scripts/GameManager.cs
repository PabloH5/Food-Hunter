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
    private GameObject gameOver;

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

        if (GameObject.Find("MenuManager") != null)
        {
            menuManager = GameObject.Find("MenuManager");
        }
        else { Debug.LogWarning("The Menu Manager can't be found."); }
    }
    void Update()
    {
        if (player != null)
        {
            lifePlayer = player.GetComponent<PlayerManager>().Life;
            scorePlayer = player.GetComponent<PlayerManager>().Score;
            bestScorePlayer = player.GetComponent<PlayerManager>().BestScore;

            lifeTxt.text = "X" + lifePlayer;
            scoreTxt.text = "Score: " + scorePlayer;
            bestScoreTxt.text = "Best Score: " + bestScorePlayer;
            UpdateTextBox(lifePlayer, scorePlayer, bestScorePlayer);
            CheckAlive();
        }
        else { Debug.LogWarning("The Ghost can't be found."); }

    }
    void CheckAlive()
    {
        if (player.GetComponent<PlayerManager>().Life <= 0)
        {
            if (player.GetComponent<PlayerManager>().BestScore < player.GetComponent<PlayerManager>().Score)
            {
                player.GetComponent<PlayerManager>().BestScore = player.GetComponent<PlayerManager>().Score;
            }
            gameOver.SetActive(true);
            Destroy(player);
        }
    }
    void UpdateTextBox(int life, int score, int bScore)
    {
        lifeTxt.text = "X" + life;
        scoreTxt.text = "Score: " + score;
        bestScoreTxt.text = "Best Score: " + bScore;
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
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-8, 8), 9, 0);
    }
    public void LoadMainScene()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene("main");
    }
    public void ExitAplication()
    {
        Application.Quit();
    }
}
