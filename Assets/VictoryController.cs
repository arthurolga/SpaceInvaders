using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryController : MonoBehaviour
{   
    public GameObject aliens;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( player == null)
            gameObject.GetComponent<Text>().text = "Vitória dos Aliens";
        else if(aliens.transform.childCount == 0)
        {
            gameObject.GetComponent<Text>().text = "Vitória do Jogador";
        }

    }
}
