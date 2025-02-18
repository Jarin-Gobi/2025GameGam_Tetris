using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Prefabs;

    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[Prefabs.Length];

        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject> ();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;


        foreach(GameObject item in pools[i])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive (true);
                break;
            }
        }
        if (!select)
        {
            select = Instantiate(Prefabs[i], transform);
            pools[i].Add (select);
        }
        return select;
    }
}
