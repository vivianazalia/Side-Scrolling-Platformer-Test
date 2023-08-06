using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _force = 10f;
    [SerializeField]
    private float _lifetime = 3f;

    private void Awake()
    {
        Destroy(gameObject, _lifetime);
    }

    public void Fire(Vector2 direction)
    {
        _rb.velocity = _force * direction;
    }
}
