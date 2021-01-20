using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool _is_ground;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            _is_ground = false;
        }
        if(collision.gameObject.tag == "Floor")
        {
            if (_is_ground == true)
            {
                Destroy(gameObject);
                Score.score = 0;
            }
            _is_ground = true;
        }
    }
}