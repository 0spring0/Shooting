using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        switch (tag)
        {
            case "Ball":
                CollisionBall(); break;
            default:
                break;
        }
    }

    private void CollisionBall()
    {
        Score.score += 1000;
        Destroy(gameObject);
    }
}
