using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed;

    public void Shot()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }
}
