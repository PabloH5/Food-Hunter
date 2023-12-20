using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Drawing;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    InputField nameTxt;
    [SerializeField]
    Text bestScoreTxt;
    public string pName;
    public string Pname
    {
        get { return pName; }
        set { pName = value; }
    }
    private int bestScore = 0;
    public int BestScore
    {
        get { return bestScore; }
        set { bestScore = value; }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadPrefs();
    }
    void Start()
    {

    }
    public void GetNameFromInputField()
    {
        Pname = nameTxt.text;
        bestScoreTxt.text = "BEST SCORE: " + Pname.ToUpper() + " | " + BestScore;
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("main");
    }
    public void ExitAplication()
    {
        Application.Quit();
    }
    public void SavePrefs(int bs, string nm)
    {
        PlayerPrefs.SetInt("bestScore", bs);
        PlayerPrefs.SetString("pName", nm);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        bestScore = PlayerPrefs.GetInt("bestScore", bestScore);
        pName = PlayerPrefs.GetString("pName", pName);
    }
}
