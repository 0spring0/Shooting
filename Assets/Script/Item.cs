using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemBase _item;

    private void OnCollisionEnter(Collision collision)
    {
        // ”地面ではない”場合処理終了
        if (collision.gameObject.tag != "ground")
            return;

        // アイテムの取得の通知

        // アイテムの新規生成
    }

    // 料金
    public int GetPrice()
    {
        return _item.GetPrice();
    }
}
