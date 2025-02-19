using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/itemData")]
public class ItemData : ScriptableObject
{ 
    public enum Itemtype
    {
        Cheeze, Pepperoni, Pimento, Pineapple, Olive, Mushroom, Tomato
    }

    [Header("Main Info")]
    public Itemtype itemtype;
    public int itemId;
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;

    [Header("Level Data")]
    public float baseDamage;
    public int baseCount;
    public float baseSpeed;
    public float[] damages;
    public int[] counts;
    public float[] speeds;

    [Header("Weapon")]
    public GameObject projectile;

}
