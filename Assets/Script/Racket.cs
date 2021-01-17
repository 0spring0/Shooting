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


    // Start is called before the first frame update
    void Start()
    {
        _late_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - _late_position;
        _late_position = transform.position;
        RaycastHit info;
        bool col = false;
        col = Physics.BoxCast(transform.position + _box_collider.center, _box_collider.size * 0.5F, -direction, out info,transform.rotation,direction.magnitude);
        Debug.Log(transform.position + _box_collider.center);
        //col = Physics.Raycast(transform.position, -direction.normalized, out info, direction.magnitude);
        //Debug.box(transform.position, direction, Color.red);
        Gizmos.DrawCube(transform.position + _box_collider.center, _box_collider.size);
        if (col == false)
            return;
        if (info.transform.tag == "Ball")
        {
            info.rigidbody.AddForce(direction * _speed, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawRay(transform.position + _box_collider.center, new Vector3(0.0F, -1.0F, 0.0F));//(transform.position - _late_position));
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //ボールをラケットの向いている方向に振った速度に応じて力を与える
    //    if(collision.gameObject.tag == "Ball")
    //    {
    //        collision.rigidbody.AddForce(-collision.rigidbody.velocity, ForceMode.Impulse);
    //        //collision.rigidbody.AddForce(-(_late_position - transform.position) * _speed,ForceMode.Impulse);
    //    }
    //}
}
