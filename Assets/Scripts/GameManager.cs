using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int maxFuel = 200;
    public int fuel = 100;
    public int score = 0;
    public bool isPlaying = false;
    
    public GameObject gamePanel;
    public GameObject startPanel;
    public GameObject endPanel;
    
    public TMP_Text scoreText;
    public TMP_Text fuelText;
    public Slider fuelSlider;

   void Awake()
   {
       if (instance == null)
       {
           instance = this;
       }
       else
       {
           Destroy(gameObject);
       }
   }

   void Start()
   {
        fuel = maxFuel;
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = fuel;
        fuelText.text = fuel.ToString();
   }

    public void StartGame()
    {   
        score = 0;
        isPlaying = true;
        gamePanel.SetActive(true);
        startPanel.SetActive(false);
        StartCoroutine(GameStart());
    }

    public void EndGame()
    {
        isPlaying = false;
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AddFuel(int amount)
    {
        fuel = Mathf.Clamp(fuel + amount, 0, maxFuel);
        ShowUI();
    }

    void ShowUI()
    {
        fuelSlider.value = fuel;
        fuelText.text = fuel.ToString();
    }

    void Update()
    {
        if (isPlaying)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    IEnumerator GameStart()
    {
        while (isPlaying)
        {
            yield return new WaitForSeconds(1);
            fuel -= 10;
            ShowUI();

            if (fuel <= 0)
            {
                EndGame();
            }
        }
    }

}
