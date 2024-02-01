using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{

    public GameObject bombEffect;
    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(bombEffect, transform.position, Quaternion.identity);

        GameObject eff = Instantiate(bombEffect);

        eff.transform.position = transform.position;

        Destroy(gameObject);
    }
}
