using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensController : MonoBehaviour
{
    public float speed = 0.5f;
    public float wait = 0.4f;
    private bool invert = false;
    public float bound_l = 9;
    public float bound_r = 9;
    public float speedMultiplier = 0.01f;
    public float chanceOfAttack = 0.02f;

    public GameObject bullet;
    public GameObject gameController;

    void Start()
    {
        InvokeRepeating("AliensAttack", 0, wait);
    
    }

    void AliensAttack()
    {

        
        if (invert)
        {
            speed = -speed;
            gameObject.transform.position += Vector3.down * Mathf.Abs(speed);
            invert = false;
            return;
        }
        else
        {
            gameObject.transform.position += Vector3.right * speed;
        }

        foreach (Transform alien in gameObject.transform)
        {
            if (alien.position.x < -bound_l || alien.position.x > bound_r)
            {
                invert = true;
                break;
            }
            if (Random.value < chanceOfAttack){
                Instantiate(bullet, alien.position, alien.rotation);
            }
        }
    }

    

    public void AlienDied(int value){
        gameController.GetComponent<GameController>().addScore(value);
        if(speed > 0){
            speed = speed + speedMultiplier;
        }else{
            speed = speed - speedMultiplier;
        }
        
    }

}
