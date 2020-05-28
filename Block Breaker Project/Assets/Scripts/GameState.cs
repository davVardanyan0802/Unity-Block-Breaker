using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    // Start is called before the first frame update


    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}
