using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    //private Script parentScript;
    public GameObject explosion;
    public int scoreValue=100;
    public int health=1;
    // Start is called before the first frame update
    void Start()
    {
        //parentScript = this.transform.parent.GetComponent<AliensController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeHit(){
        health -= 1;
        if(health <= 0){
            SFXController.PlaySound("explosion");
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            //parentScript.AlienDied();
            this.transform.parent.GetComponent<AliensController>().AlienDied(scoreValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Base")
        {
            Destroy(collision.gameObject);
            
        }

    }
}
