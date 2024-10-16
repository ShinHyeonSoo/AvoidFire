using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUIManager : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;
    [SerializeField] private Transform heartPosition;//위치잡아주기

    private List<Image> heartList = new List<Image>();

    //초기화
    public void InitializeHealthUI(int currentHealth)
    {
        //기존하트 지우고
        foreach (Image healt in heartList)
        {
            Destroy(healt.gameObject);
        }
        heartList.Clear();
        //새로운 하트 만들기
        for (int i = 0; i < currentHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartPosition);
            Image heartImage = heart.GetComponent<Image>();
            heartImage.sprite = fullHeartSprite;
            heartList.Add(heartImage);
        }
    }

    //체력업데이트
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
