using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    int count = 0;
    Damageable damageable;
    SpriteRenderer rend;
    private void Awake()
    {
        damageable = GetComponent<Damageable>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        if (!damageable.IsAlive)
        {
            if(count == 0)
            {
                AudioManager.instance.PlaySFX(AudioManager.Sfx.BossDeath);
                StartCoroutine(die());
                count++;
            }
            
        }
    }


    IEnumerator die()
    {

        float animTime = 1.0f;
        while(animTime > 0.0f)
        {
            yield return null;
            animTime -= Time.deltaTime;

            Color c = rend.color;
            c.a = animTime;
            rend.color = c;
        }
        yield return new WaitForSeconds(0.1f);
        Died();



        //for (float f = 1f; f >= -0.05f; f -= 0.05f)
        //{
        //    Color c = rend.color;
        //    c.a = f;
        //    rend.material.color = c;
        //    yield return new WaitForSeconds(0.05f);
        //}
        
    }

    public void Died()
    {
        if (GameManager.Instance.Stage > 0)
        {
            AudioManager.instance.PlayBGM(false, GameManager.Instance.Stage - 1);
            AudioManager.instance.PlayBGM(true, GameManager.Instance.Stage);
        }
        else
        {
            AudioManager.instance.PlayBGM(false, 0);
            AudioManager.instance.PlayBGM(true, 1);
        }
        if (GameManager.Instance.Stage >= 2)
        {
            GameManager.Instance.isLive = false;
            GameManager.Instance.showE.StartCoroutine("GoodEnding");
        }
        else
        {
            GameManager.Instance.Stage++;
            GameManager.Instance.StartBoss = false;
            for (int i = 0; i < GameManager.Instance.grounds.Length; i++)
            {
                GameManager.Instance.grounds[i].ChangeGround(GameManager.Instance.Stage);
            }
        }
        Destroy(gameObject);
    }
}
