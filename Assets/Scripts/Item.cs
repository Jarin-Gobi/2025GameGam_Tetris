using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    public Weapon weapon;
    public Gear gear;

    public Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon; 

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.itemName;
    }

    private void OnEnable()
    {
        switch (data.itemtype)
        {
            case ItemData.Itemtype.Pepperoni:
            case ItemData.Itemtype.Pimento:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
                break;
            case ItemData.Itemtype.Mushroom:
            case ItemData.Itemtype.Pineapple:
            case ItemData.Itemtype.Cheeze:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100);
                break;
            case ItemData.Itemtype.Tomato:
                level = 0;
                textDesc.text = string.Format(data.itemDesc);
                break;
            case ItemData.Itemtype.Olive:
                textDesc.text = string.Format(data.itemDesc, data.speeds[level]);
                break;
            default:
                textDesc.text = string.Format(data.itemDesc);
                break;
        }
        textLevel.text = "Lv." + (level + 1);
    }

    public void OnClick()
    {
        switch (data.itemtype)
        {
            case ItemData.Itemtype.Cheeze:
                if (level == 0)
                {
                    if (GameManager.Instance.ItemIcons.Count > 0)
                    {
                        GameManager.Instance.ItemIcons[GameManager.Instance.ItemVolum] = icon;
                        GameManager.Instance.itemArray.ShowIcone(GameManager.Instance.ItemVolum);
                        GameManager.Instance.ItemVolum++;
                    }
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;
                    float nextSpeed = data.baseSpeed;

                    nextDamage += data.baseDamage * data.damages[level];
                    nextCount += data.counts[level];
                    nextSpeed += data.baseSpeed + data.speeds[level];
                    weapon.LevelUp(nextCount, nextDamage, nextSpeed);
                }
                if (level == data.damages.Length)
                {
                    GetComponent<Button>().interactable = false;
                }
                break;
            case ItemData.Itemtype.Pimento:
            case ItemData.Itemtype.Pineapple:
            case ItemData.Itemtype.Pepperoni:
                if(level == 0)
                {
                    GameManager.Instance.player.OnTopping(data.itemId);
                    if (GameManager.Instance.ItemIcons.Count > 0)
                    {
                        GameManager.Instance.ItemIcons[GameManager.Instance.ItemVolum] = icon;
                        GameManager.Instance.itemArray.ShowIcone(GameManager.Instance.ItemVolum);
                        GameManager.Instance.ItemVolum++;
                    }
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;
                    float nextSpeed = data.baseSpeed;

                    nextDamage += data.baseDamage * data.damages[level];
                    nextCount += data.counts[level];
                    nextSpeed += data.baseSpeed + data.speeds[level];
                    weapon.LevelUp(nextCount, nextDamage, nextSpeed);
                }
                if (level == data.damages.Length)
                {
                    GetComponent<Button>().interactable = false;
                }
                break;
            case ItemData.Itemtype.Mushroom:
                if(level == 0)
                {
                    GameManager.Instance.player.OnTopping(data.itemId);
                    if (GameManager.Instance.ItemIcons.Count > 0)
                    {
                        GameManager.Instance.ItemIcons[GameManager.Instance.ItemVolum] = icon;
                        GameManager.Instance.itemArray.ShowIcone(GameManager.Instance.ItemVolum);
                        GameManager.Instance.ItemVolum++;
                    }
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data);
                }
                else
                {
                    float nextRate = data.damages[level];
                    gear.LevelUP(nextRate);
                }
                if (level == data.damages.Length)
                {
                    GetComponent<Button>().interactable = false;
                }
                break;
            case ItemData.Itemtype.Olive:
                if (level == 0)
                {
                    GameManager.Instance.player.OnTopping(data.itemId);
                    if (GameManager.Instance.ItemIcons.Count > 0)
                    {
                        GameManager.Instance.ItemIcons[GameManager.Instance.ItemVolum] = icon;
                        GameManager.Instance.itemArray.ShowIcone(GameManager.Instance.ItemVolum);
                        GameManager.Instance.ItemVolum++;
                    }
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else
                {
                    int nextCount = 0;
                    float nextSpeed = data.baseSpeed;

                    nextCount += data.counts[level];
                    nextSpeed += data.speeds[level];
                    weapon.LevelUp(nextCount, 0, nextSpeed);
                }
                if (level == data.damages.Length)
                {
                    GetComponent<Button>().interactable = false;
                }
                break;
            case ItemData.Itemtype.Tomato:
                if (level == 0)
                {
                    if (GameManager.Instance.ItemIcons.Count > 0)
                    {
                        GameManager.Instance.ItemIcons[GameManager.Instance.ItemVolum] = icon;
                        GameManager.Instance.itemArray.ShowIcone(GameManager.Instance.ItemVolum);
                        GameManager.Instance.ItemVolum++;
                    }
                }
                GameManager.Instance.player.damageable.Heal(4);
                break;
        }

        level++;
    }
}
