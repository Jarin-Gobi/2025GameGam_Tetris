using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowEnding : MonoBehaviour
{
    [SerializeField] public Image image;
    [SerializeField] public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public IEnumerator GoodEnding()
    {
        rectTransform.localScale = Vector3.one;
        image.DOFade(255f, 100f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
    public IEnumerator BadEnding()
    {
        rectTransform.localScale = Vector3.one;
        image.DOFade(255f, 100f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}