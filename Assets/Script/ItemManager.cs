using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private readonly IDictionary _item_list = new Dictionary<string, ItemBase>();

    private IList _object_list = new List<GameObject> ();

    private ItemBase Generate(string name)
    {
        Debug.Assert(_item_list.Contains(name));
        return (ItemBase)_item_list[name];
    }
}
