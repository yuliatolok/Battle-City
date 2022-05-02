using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Explode()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
