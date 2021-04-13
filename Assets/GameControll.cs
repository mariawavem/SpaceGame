using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    public GameObject MenuScreen;
    public Text scoreText;
    public Button StartButton;
    private int score = 0;
    private bool isStarted = false;
    private static GameControll instance;
    public bool getIsStarted()
    {
        return isStarted;
    }

    public static GameControll getInstance()
    {
        return instance;
    }
    public void increaseScore( int increment)
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }
    public void decreaseScore(int increment)
    {
        score -= increment;
        scoreText.text = "Score: " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartButton.onClick.AddListener(delegate
        {
            MenuScreen.SetActive(false);
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
