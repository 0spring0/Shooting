using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _speed;
    private bool _is_ground = false;
    private float _time;
    [SerializeField]
    private AudioSource _by_room;

    private void Start()
    {
        //発射
        _rigidbody.velocity = -transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        switch (tag)
        {
            case "Floor":
                CollisionFloor(); break;

            case "Wall":
                CollisionWall(); break;
        }
    }

    private void CollisionFloor()
    {
        PlayBoundsSound();
        //地面に2回バウンドするとアウト
        //壁に当たった場合はリセット
        if (_is_ground == true)
            End();
        _is_ground = true;
        _time = 0.0F;
    }

    private void CollisionWall()
    {
        PlayBoundsSound();
        _is_ground = false;
    }

    private void PlayBoundsSound()
    {
        if (_by_room.isPlaying == true)
            _by_room.Stop();
        _by_room.PlayOneShot(_by_room.clip);
    }

    private void OnCollisionStay(Collision collision)
    {
        //地面に転がる場合があるのでその場合は1m秒経ったら削除
        if (collision.gameObject.tag == "Floor")
        {
            _time += Time.deltaTime;
            if (_time > 1.0F)
                End();
        }
    }

    private void End()
    {
        Destroy(gameObject);
        Score.score = 0;
    }
}