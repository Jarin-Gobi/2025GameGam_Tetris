using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBoss : MonoBehaviour
{
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public IEnumerator ShowAndHide()
    {
        rectTransform.localScale = Vector3.one;
        yield return new WaitForSeconds(2f);
        rectTransform.localScale = Vector3.zero;
    }
}
