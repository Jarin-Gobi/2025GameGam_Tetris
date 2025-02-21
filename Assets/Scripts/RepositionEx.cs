using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionEx : MonoBehaviour
{
    Transform playerTransform;


    private void Start()
    {
        playerTransform = GameManager.Instance.player.transform;
    }
    // Update is called once per frame
    void Update()
    {
        float distX = playerTransform.position.x - transform.position.x;
        if(distX > 40.0f)
        {
            transform.Translate(60.0f, 0, 0);
        }
        else if(distX < -40.0f)
        {
            transform.Translate(-60.0f, 0, 0);
        }

        float distY = playerTransform.position.y - transform.position.y;
        if(distY > 22f)
        {
            transform.Translate(0, 33f, 0);
        }
        else if(distY < -22)
        {
            transform.Translate(0, -33f, 0);
        }


    }
}
