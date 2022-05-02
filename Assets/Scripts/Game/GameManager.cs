using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private PowerUpController _powerUpController;
    [SerializeField] private BulletController _bulletController;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.Initialize(_bulletController);
    }
}
