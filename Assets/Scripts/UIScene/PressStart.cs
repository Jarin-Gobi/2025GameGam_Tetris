using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{
    // Update is called once per frame

    private void Start()
    {
        MainAudio.instance.PlayBGM(true, 0);
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine("Startpress");
        }
    }

    IEnumerator Startpress()
    {
        MainAudio.instance.PlaySFX(MainAudio.Sfx.Button);
        yield return new WaitForSeconds(0.02f);
        SceneManager.LoadScene(1);
    }
}
