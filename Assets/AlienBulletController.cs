using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletController : MonoBehaviour
{   
    public float speed = 5.0f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeHit(1);
            Destroy(gameObject);
        }
        if (collision.tag == "Base")
        {
            collision.gameObject.GetComponent<BaseController>().TakeHit();
            Destroy(gameObject);
        }
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }  

}
