using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    // ��Ʈ ��������Ʈ�� �迭, ������� Full, Half, Empty ��Ʈ�̴�.
    [SerializeField]
    private Sprite[] heartSprites;

    // ��Ʈ ������Ʈ�� ������, �⺻ ��������Ʈ�� Full �̴�.
    [SerializeField]
    private Image heartPrefab;

    // ĵ������ ǥ�õ� ��Ʈ ������Ʈ�� �迭, ���ʺ��� 0��°�̴�.
    private Image[] hearts;

    // ��Ʈ ������Ʈ ������ �Ÿ� , 31.8 + 5
    private float offsetX = 80;

    private const int Full = 0;
    private const int Half = 1;
    private const int Empty = 2;

    private void Start()
    {
        // �ִ� ü�¸�ŭ�� ��Ʈ ������Ʈ�� �����Ѵ�.
        hearts = new Image[(int)GameManager.Instance.player.damageable.MaxHealth / 2];

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = Instantiate(heartPrefab, Vector3.zero, Quaternion.identity, transform);
            hearts[i].rectTransform.anchorMin = new Vector2(0.0f, 1.0f);
            hearts[i].rectTransform.anchorMax = new Vector2(0.0f, 1.0f);
            hearts[i].rectTransform.pivot = new Vector2(0.0f, 1.0f);
            hearts[i].rectTransform.anchoredPosition = new Vector3(15.0f + offsetX * i, -15.0f, 0.0f);
        }
    }

    // �÷��̾��� HP �� ����Ǹ� ȣ��Ǵ� �Լ�
    public void ApplyHeart(float damage)
    {
        for (int i = (int)GameManager.Instance.player.damageable.Health - 1; i >= (int)GameManager.Instance.player.damageable.Health - damage; i--)
        {
            if((float)i / 2 - i / 2 == 0.5f)
            {
                hearts[i / 2].sprite = heartSprites[Half];
            }
            else
            {
                hearts[i / 2].sprite = heartSprites[Empty];
            }
        }
    }

    public void Healheart(float Heal)
    {
        for(int i = (int)GameManager.Instance.player.damageable.Health - 1; i <= Heal - 1; i++)
        {
            if((float)i / 2 - i / 2 == 0.5f)
            {
                hearts[i / 2].sprite = heartSprites[Full];
            }
            else
            {
                hearts[i / 2].sprite = heartSprites[Half];
            }
        }
    }
}
