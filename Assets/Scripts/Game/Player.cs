using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _bulletSpeed = 1f;
    [SerializeField] private Transform _maze;
    private float _verticalSpeed;
    private float _horizontalSpeed;
    private BulletController _bulletController;

    public void Initialize(BulletController bulletController)
    {
        _bulletController = bulletController;
    }
    void Update()
    {
        GetSpeed();
        Move();
        FaceDirection();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = _bulletController.GetBullet();
            bullet.transform.position = _maze.position;
            bullet.transform.rotation = _maze.rotation;
            bullet.gameObject.SetActive(true);
            bullet.Shoot(_bulletSpeed);
        }
    }

    private void GetSpeed()
    {
        _verticalSpeed = Input.GetAxis("Vertical") * Time.deltaTime * _speed;
        _horizontalSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        
        if (Mathf.Abs(_horizontalSpeed) > Mathf.Abs(_verticalSpeed))
        {
            _verticalSpeed = 0f;
        }
        else
        {
            _horizontalSpeed = 0f;
        }
    }
    private void Move()
    {
        transform.position += new Vector3(_horizontalSpeed, _verticalSpeed);
    }

    private void FaceDirection()
    {
        if (_verticalSpeed > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (_verticalSpeed < -Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (_horizontalSpeed > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (_horizontalSpeed < -Mathf.Epsilon)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}