using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wall : MonoBehaviour
{
    public Type wallType;

    public enum Type
    {
        top,
        down,
        right,
        left
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GetComponent<BoxCollider2D>().enabled = false;

            if (wallType == Type.top || wallType == Type.down)
            {
                DestroyOther(Vector2.left);
                DestroyOther(Vector2.right);
            }

            if (wallType == Type.right || wallType == Type.left)
            {
                DestroyOther(Vector2.left);
                DestroyOther(Vector2.right);
            }
            Destroy(gameObject);

        }

    }
    void DestroyOther(Vector2 direction)
    {
        float cellsize = 0.175f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, cellsize);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }


}
