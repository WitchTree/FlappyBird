using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleItem : MonoBehaviour
{
    [SerializeField] private GameObject clock;
    [SerializeField] private GameObject clockInside;
    [SerializeField] private GameObject[]doubleScore;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private GameObject appleItem;

    void Update()
    {
        

        if (clockInside.transform.localScale.y <= 0.3f)
        {
            clockInside.GetComponent<Image>().color = new Color32(255, 96, 96, 255);
        }

        if (clockInside.transform.localScale.y > 0.3f)
        {
            clockInside.GetComponent<Image>().color = new Color32(255, 236, 100, 255);
        }

        if (clockInside.transform.localScale.y > 0.7f)
        {
            clockInside.GetComponent<Image>().color = new Color32(69, 171, 97, 255);
        }
    }
    
    void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            clock.SetActive(true);
            LeanTween.scaleY(clockInside, 0, 12f);
            appleItem.SetActive(false);
            for(int i=0;i<5;i++)
            {
                doubleScore[i].SetActive(true);
            }
            
            Invoke(nameof(ResetItem),3.0f);
            Invoke(nameof(ResetApple),12.1f);
            
            }
        }

         void ResetItem()
        {
            itemManager.SelectItem();
        }
    public void ResetApple()
    {
        clock.SetActive(false);
        clockInside.transform.localScale = new Vector3(1, 1, 1); 
        for(int i=0;i<5;i++)
        {
            doubleScore[i].SetActive(false);
        }
    }
}
