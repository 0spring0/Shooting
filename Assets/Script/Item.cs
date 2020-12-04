using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemBase _item;

    private void OnCollisionEnter(Collision collision)
    {

    }

    //料金
    public int GetPrice()
    {
        return _item.GetPrice();
    }
}
