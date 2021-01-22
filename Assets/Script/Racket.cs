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
    [SerializeField]
    private float _bounds;
    private Vector3 _late_position;


    // Start is called before the first frame update
    void Start()
    {
        _late_position = transform.position;
    }

    private void LateUpdate()
    {
        _late_position = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ボールをラケットの振った方向に振った速度に応じて力を与える
        if (collision.gameObject.tag == "Ball")
        {
            Score.score += 100;

            //ラケットの方向を計算
            float dot = Vector3.Dot(transform.up, collision.transform.position - transform.position);

            //跳ね返し
            collision.rigidbody.AddForce(transform.forward * Mathf.Sign(dot) * _bounds, ForceMode.Impulse);
            collision.rigidbody.AddForce((transform.position - _late_position) * _speed,ForceMode.Impulse);
        }
    }
}