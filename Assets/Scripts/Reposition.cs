using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector3 PlayerPos = GameManager.Instance.player.transform.position;
        Vector3 MyPos = transform.position;
        float diffX = Mathf.Abs(PlayerPos.x - MyPos.x);
        float diffY = Mathf.Abs(PlayerPos.y - MyPos.y);

        Vector3 PlayerDir = GameManager.Instance.player.dirVec;
        float dirX = PlayerDir.x < 0 ? -1 : 1;
        float dirY = PlayerDir.y < 0 ? -1 : 1;


        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY * 2)
                {
                    transform.Translate(Vector3.right * dirX * 44);
                }
                else if(diffX < diffY * 2)
                {
                    transform.Translate(Vector3.up * dirY * 22);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(PlayerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));
                }
                break;
        }
    }
}
