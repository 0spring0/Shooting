using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private SphereCollider _mycollider;
    [SerializeField]
    private float _speed;
    private void Start()
    {
        Vector3 direction = new Vector3(Random.value * 2.0F - 1.0F, Random.value * 2.0F - 1.0F, Random.value * 2.0F - 1.0F) * _speed;
        _rigidbody.AddForce(direction, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
            Destroy(gameObject);
        if (other.gameObject.tag == "Wall")
            _mycollider.isTrigger = false;
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
            _mycollider.isTrigger = true;
    }
}
