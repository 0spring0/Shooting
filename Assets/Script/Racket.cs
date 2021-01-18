using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private BoxCollider _box_collider;
    [SerializeField]
    private float _speed;
    private Vector3 _late_position;

    [SerializeField]
    private GameObject _prefub;


    // Start is called before the first frame update
    void Start()
    {
        _late_position = transform.position;
    }

    private void LateUpdate()
    {
        _late_position = transform.position;

        if (Input.GetKeyDown(KeyCode.Return))
            Instantiate(_prefub);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ボールをラケットの向いている方向に振った速度に応じて力を与える
        if (collision.gameObject.tag == "Ball")
        {
            collision.rigidbody.AddForce(-(_late_position - transform.position) * _speed,ForceMode.Impulse);
        }
    }
}
