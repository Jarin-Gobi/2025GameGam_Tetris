using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    public void SpawnB()
    {
        AudioManager.instance.PlaySFX(AudioManager.Sfx.BossSpawn);
        Boss = Instantiate(GameManager.Instance.Boss[GameManager.Instance.Stage], GetRandomPosition(), Quaternion.identity);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Boss.transform.position = GetRandomPosition();
        }
    }

    Vector3 GetRandomPosition()
    {
        Collider2D range = GetComponent<Collider2D>();

        Vector3 orgPos = transform.position;

        float rangeX = range.bounds.size.x;
        float rangeY = range.bounds.size.y;

        Vector3 offset = range.offset;

        rangeX = Random.Range((rangeX / 2) * -1, rangeX / 2);
        rangeY = Random.Range((rangeY / 2) * -1, rangeY / 2);

        Vector3 RanPos = new Vector3(rangeX, rangeY, 0f) + offset;
        Vector3 SpawnPos = orgPos + RanPos;
        return SpawnPos;
    }

}
