using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{   
    int score;
    int hiscore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("CurrentScore", 0);
        hiscore = PlayerPrefs.GetInt("HighScore", 0);
        //playerText = string.Format("Vidas {0}/{1}", health, maxHealth);;
        gameObject.GetComponent<Text>().text = string.Format("{0} \n HS: {1}", score,hiscore);
    }
}
