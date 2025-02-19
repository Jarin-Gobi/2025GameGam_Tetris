using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    private float timer;
    Attack attack;
    PlayerController player;

    private void Awake()
    {
        player = GameManager.Instance.player;
    }


    private void Update()
    {
        if (!GameManager.Instance.isLive)
        {
            return;
        }
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                break;
            default:
                timer += Time.deltaTime;
                if(timer > speed)
                {
                    timer = 0;
                    Fire();
                }
                break;
        }
    }


    public void LevelUp(int count, float damage, float speed)
    {
        this.damage += damage;
        this.count += count;
        this.speed = speed;
        if (id == 0)
        {
            Batch();
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            GetComponentsInChildren<Attack>()[i].attackDamage += damage;
        }
    }

    public void Init(ItemData data)
    {
        name = "Weapon" + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        id = data.itemId;
        damage = data.baseDamage;
        count = data.baseCount;
        speed = data.baseSpeed;

        for (int i = 0; i < GameManager.Instance.Pool.Prefabs.Length; i++)
        {
            if(data.projectile == GameManager.Instance.Pool.Prefabs[i])
            {
                prefabId = i;
                break;
            }
        }
        switch (id)
        {
            case 0:
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
            Transform bullet;
            if (i < transform.childCount)
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.Instance.Pool.Get(prefabId).transform;
                bullet.parent = transform;
            }


            attack = bullet.GetComponent<Attack>();
            attack.attackDamage = damage;
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 2f, Space.World);
        }
    }

    void Fire()
    {
        if (!player.scanner.nearestTarget)
        {
            return;
        }

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;

        Transform bullet = GameManager.Instance.Pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up,dir);
        bullet.GetComponent<Bullet>().Init(count, dir);
        attack = bullet.GetComponent<Attack>();
        attack.attackDamage = damage;
    }
}
