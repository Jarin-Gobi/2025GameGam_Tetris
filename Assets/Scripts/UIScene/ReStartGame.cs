using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartGame : MonoBehaviour
{
    public void ReStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
