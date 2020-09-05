using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionCoroutine());
    }


    IEnumerator ExplosionCoroutine()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
