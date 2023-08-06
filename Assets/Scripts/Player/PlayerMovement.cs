using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputHandler _inputHandler;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _jumpForce = 1f;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private float _groundCheckRadius;
    [SerializeField]
    private LayerMask _groundLayer;

    private bool _isGround;
    private bool _doubleJump;

    private void Awake()
    {
        _inputHandler.MoveEvent += Move;
        _inputHandler.JumpEvent += Jump;
    }

    private void OnDestroy()
    {
        _inputHandler.MoveEvent -= Move;
        _inputHandler.JumpEvent -= Jump;
    }

    private void Update()
    {
        CheckCollisionWithGround();
    }

    private void Move(float dir)
    {
        _rb.velocity = new Vector2(dir * _speed, _rb.velocity.y);
        Facing(dir);
    }

    private void Facing(float dir)
    {
        if(dir > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void Jump()
    {
        if (_isGround)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _doubleJump = true;
        }
        else if(_doubleJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _doubleJump = false;
        }
    }

    private void CheckCollisionWithGround()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
