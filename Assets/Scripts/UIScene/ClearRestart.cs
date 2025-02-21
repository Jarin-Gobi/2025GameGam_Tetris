using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearRestart : MonoBehaviour
{
    private void Start()
    {
        MainAudio.instance.PlayBGM(true, 0);
    }
    public void GoHome()
    {
        StartCoroutine("gohome");
    }

    IEnumerator gohome()
    {
        MainAudio.instance.PlaySFX(MainAudio.Sfx.Button);
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene(0);
    }
}
