using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUIManager : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;
    [SerializeField] private Transform heartPosition;//��ġ����ֱ�

    private List<Image> heartList = new List<Image>();

    //�ʱ�ȭ
    public void InitializeHealthUI(int currentHealth)
    {
        //������Ʈ �����
        foreach (Image healt in heartList)
        {
            Destroy(healt.gameObject);
        }
        heartList.Clear();
        //���ο� ��Ʈ �����
        for (int i = 0; i < currentHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartPosition);
            Image heartImage = heart.GetComponent<Image>();
            heartImage.sprite = fullHeartSprite;
            heartList.Add(heartImage);
        }
    }

    //ü�¾�����Ʈ
    public void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            if(i < currentHealth)
            {
                heartList[i].sprite = fullHeartSprite;
            }
            else
            {
                heartList[i].sprite = emptyHeartSprite;
            }
        }
    }
}
