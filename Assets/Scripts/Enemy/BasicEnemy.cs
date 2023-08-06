using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    [Header("Attack")]
    [SerializeField]
    private BulletController _bullet;
    [SerializeField]
    private Transform _shootOrigin;
    [SerializeField]
    private float _delayToAttack;

    [Header("Detection")]
    [SerializeField]
    private Transform _playerDetection;
    [SerializeField]
    private float _playerDetectionRadius;
    [SerializeField]
    private LayerMask _playerLayer;

    [SerializeField]
    private Transform[] _waypoints;
    [SerializeField]
    private float _speed;

    private bool _detectPlayer;
    private float _startShootTime;
    private int _currentIndexWaypoint;

    private void Start()
    {
        _startShootTime = _delayToAttack;
        _currentIndexWaypoint = 0;
        SetIndexWaypoint();
    }

    private void Update()
    {
        Attack();
        Move();
    }

    public override void Attack()
    {
        DetectionPlayer();

        if (_detectPlayer)
        {
            _startShootTime -= Time.deltaTime;
            if (_startShootTime <= 0)
            {
                FireBullet();
                _startShootTime = _delayToAttack;
            }
        }
        else
        {
            _startShootTime = _delayToAttack;
        }
    }

    public override void Move()
    {
        if(Vector2.Distance(transform.position, _waypoints[_currentIndexWaypoint].position) < .2f)
        {
            SetIndexWaypoint();
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentIndexWaypoint].position, _speed * Time.deltaTime);
    }

    private void SetIndexWaypoint()
    {
        if (_waypoints.Length > 0)
        {
            if(_currentIndexWaypoint == 0)
            {
                _currentIndexWaypoint = 1;
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else if(_currentIndexWaypoint == 1)
            {
                _currentIndexWaypoint = 0;
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
        }
    }

    private void FireBullet()
    {
        BulletController bullet = Instantiate(_bullet, _shootOrigin.position, _bullet.transform.rotation);
        bullet.Fire(transform.right);
    }

    private void DetectionPlayer()
    {
        _detectPlayer = Physics2D.OverlapCircle(_playerDetection.position, _playerDetectionRadius, _playerLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_playerDetection.position, _playerDetectionRadius);
        Gizmos.DrawWireSphere(_waypoints[0].position, .3f);
        Gizmos.DrawWireSphere(_waypoints[1].position, .3f);
        Gizmos.DrawLine(transform.position, _waypoints[_currentIndexWaypoint].position);
    }
}
