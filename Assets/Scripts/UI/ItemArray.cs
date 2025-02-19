using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemArray : MonoBehaviour
{
    private Image[] images;
    private Color color;
    private void Awake()
    {
        images = GetComponentsInChildren<Image>();
    }
    public void ShowIcone(int index)
    {
        if (GameManager.Instance.ItemIcons[index] != null)
        {
            images[index].sprite = GameManager.Instance.ItemIcons[index].sprite;
            color = images[index].color;
            color.a = 255f;
            images[index].color = color;
        }

    }
}