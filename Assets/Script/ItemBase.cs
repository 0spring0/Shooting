using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemBase
{
    private readonly int _price;

    public ItemBase(int price)
    {
        _price = price;
    }

    public int GetPrice()
    {
        return _price;
    }

    public ItemBase Clone()
    {
        return (ItemBase)MemberwiseClone();
    }
}
