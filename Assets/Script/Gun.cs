using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Bullet _bullet = null;

    public void Update()
    {
        Shot();
    }

    public void Reload(Bullet bullet)
    {
        //銃が保持できる弾は1つのみ
        if (_bullet)
            return;

        //銃に弾を装填する
        _bullet = bullet;
    }

    private void Shot()
    {
        //発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _bullet.Shot();

            //銃が保持する弾を破棄
            _bullet = null;
        }
    }
}
