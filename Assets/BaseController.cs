using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{   
    SpriteRenderer m_SpriteRenderer;
    public int maxHealth = 3;
    int health;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeHit(){
        health -= 1;
        Debug.Log(health);
        color = m_SpriteRenderer.color;
        m_SpriteRenderer.color = Color.Lerp(color, Color.black, 0.3f);
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
