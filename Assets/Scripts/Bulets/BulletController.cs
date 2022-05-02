using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Bullet _buletPrefab;
    public Bullet GetBullet()
    {
        var bullet = Instantiate(_buletPrefab);
        bullet.Initialize();
        return bullet;
    }
}
