using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private readonly IDictionary _item_list = new Dictionary<string, GameObject>();

    private IList _object_list = new List<GameObject> ();

    private void Generate(string name)
    {
        Debug.Assert(_item_list.Contains(name));
        _object_list.Add(Instantiate((GameObject)_item_list[name])) ;
    }
}
