using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _offset;

    private void Update()
    {
        transform.position = new Vector3((_target.transform.position + _offset).x, (_target.transform.position + _offset).y, transform.position.z);
    }
}
