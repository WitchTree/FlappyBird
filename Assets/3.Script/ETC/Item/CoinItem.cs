using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private GameObject coinItem;
       void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            coinItem.SetActive(false);
            GameManager.instance.score+=5;
            UIManager.instance.UpdateScoreUI(GameManager.instance.score);       
            Invoke(nameof(ResetItem),3.0f);
            }
        }

        void ResetItem()
        {
            itemManager.SelectItem();
        }
}
