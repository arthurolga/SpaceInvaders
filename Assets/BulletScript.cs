using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<EnemyController>().TakeHit();
            Destroy(gameObject);
        }
        if (collision.tag == "Base")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<BaseController>().TakeHit();
            Destroy(gameObject);
        }

    }



}
