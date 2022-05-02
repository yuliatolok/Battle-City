using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;
    private Rigidbody2D _rigidbody;

    public void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Shoot(float speed)
    {
        _rigidbody.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
       Debug.Log(col.gameObject.name);
        _explosion.Explode();
    }
}
