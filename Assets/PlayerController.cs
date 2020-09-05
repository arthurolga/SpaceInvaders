using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   

    float x_input;
    float y_input;
    public float bound;

    public GameObject bullet;
    public GameObject playerLifeText;


    Rigidbody2D rb;
    public float speed;
    public float shootSpeed;
    public int maxHealth;


    int health;
    string playerText;
    Vector3 screenSize;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        health=maxHealth;
        StartCoroutine(ShootingRoutine());
        playerText = string.Format("Vidas {0}/{1}", health, maxHealth);;
        playerLifeText.GetComponent<Text>().text = playerText;
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x_input, 0).normalized * speed;

        if(Input.GetAxis("Mouse X") != 0) {
           Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           transform.position = new Vector3(worldPosition.x, transform.position.y, 0);
       }
        // if (Input.GetKeyDown("right") )
        // {
        //     rb.velocity = new Vector2(1, 0) * speed;
        // } if (Input.GetKeyDown("left") ){
        //     rb.velocity = new Vector2(-1, 0) * speed;
        // }


        if (transform.position.x > screenSize.x - bound) {
            transform.position = new Vector3(screenSize.x - bound, transform.position.y, 0);
        }
        if (transform.position.x < -screenSize.x + bound) {
            transform.position = new Vector3(-screenSize.x + bound, transform.position.y, 0);
        }

    }

    IEnumerator ShootingRoutine(){

        while(true){
            if (Input.GetButton("Fire1")^Input.GetMouseButtonDown(0)^Input.GetKeyDown("space"))
            {
                SFXController.PlaySound("laser");
                Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f/shootSpeed);
            }
            yield return new WaitForSeconds(0);
            

        }
        
        
    }
    public void TakeHit(int dmg){
        health -= dmg;
        
        playerText = string.Format("Vidas {0}/{1}", health, maxHealth);;
        playerLifeText.GetComponent<Text>().text = playerText;
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
