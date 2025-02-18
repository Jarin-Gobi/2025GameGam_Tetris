using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public int count;
    public float speed;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = -150;
                Batch();
                break;
            default:

                break;
        }
    }

    void Batch()
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet = GameManager.Instance.Pool.Get(prefabId).transform;
            bullet.parent = transform;
        }
    }
}
