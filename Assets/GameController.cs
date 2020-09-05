using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public GameObject aliens;
    public GameObject player;
    public bool resetScoreOnStart;
    int currentScore;
    int highScore;
    bool isScoreAdderRunning;
    // Start is called before the first frame update
    void Start()
    {   


        if(resetScoreOnStart){
            Debug.Log("Zerou!");
            PlayerPrefs.SetInt("CurrentScore", 0);

        }
        

        currentScore = PlayerPrefs.GetInt("CurrentScore", 10);
        Debug.Log(currentScore);
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        isScoreAdderRunning = false;
    }

    // Update is called once per frame
    void Update()
    {

        if( player == null) 
        {
            StartCoroutine(LoseScene(2));
        }
        else if(aliens.transform.childCount == 0)
        {
            //PlayerPrefs.SetInt("CurrentScore", 1000);
            if(!isScoreAdderRunning){
                StartCoroutine(AddScoreOverTime(2000));
            }
            StartCoroutine(NextLevel(2));
            // StartCoroutine(ReloadScene(2));
        }
        if (aliens.transform.position.y <= -5){
            Destroy(player);
        }

        if (currentScore > highScore){
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore = currentScore;
        }

        

    }

    

    public void addScore(int value){
        currentScore += value;
        Debug.Log("Novo Valor:");
        Debug.Log(currentScore);
        PlayerPrefs.SetInt("CurrentScore", currentScore);
    }

    IEnumerator AddScoreOverTime(int value){
        isScoreAdderRunning = true;
        int addedScore = 0;
        while(addedScore < value){
            addScore(100);
            addedScore+=100;
            yield return new WaitForSeconds(0.05f);
            
        }

    }

    IEnumerator ReloadScene(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    IEnumerator NextLevel(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Level2");

    }

    IEnumerator LoseScene(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Level1");

    }
}
