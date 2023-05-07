using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject appleItem;
    [SerializeField] private GameObject coinItem;

    void Start()
    {
        SelectItem();
    }

    public void SelectItem()
    {
        int temp=Random.Range(1,3);
        if(temp==1)
        {
            appleItem.SetActive(true);
            coinItem.SetActive(false);           
                  
        }

        else if(temp==2)
        {
            appleItem.SetActive(false);
            coinItem.SetActive(true);  
        
        }
    }

    
}
