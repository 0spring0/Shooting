using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private GameObject _child;
    bool _is_alive = true;

    private void Update()
    {
        if (_is_alive == true)
            return;

        //SEが終わり次第削除
        if (_audio.isPlaying == false)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        switch (tag)
        {
            case "Ball":
                if (_is_alive == false)
                    return;
                CollisionBall(); break;
            default:
                break;
        }
    }

    private void CollisionBall()
    {
        //ボールとの衝突で削除
        _child.SetActive(false);
        _is_alive = false;
        _audio.PlayOneShot(_audio.clip);
        Score.score += 1000;
    }
}
