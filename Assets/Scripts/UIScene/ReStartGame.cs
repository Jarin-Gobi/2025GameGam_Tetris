using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartGame : MonoBehaviour
{
    public void ReStart()
    {
        StartCoroutine("restart");
    }

    public void GoHome()
    {
        StartCoroutine("gohome");
    }

    IEnumerator restart()
    {
        BadEndingAudio.instance.PlaySFX(BadEndingAudio.Sfx.button);
        yield return new WaitForSeconds(0.02f);
        SceneManager.LoadScene(1);
    }

    IEnumerator gohome()
    {
        BadEndingAudio.instance.PlaySFX(BadEndingAudio.Sfx.button);
        yield return new WaitForSeconds(0.02f);
        SceneManager.LoadScene(0);
    }
}
