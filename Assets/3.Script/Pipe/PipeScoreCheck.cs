using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScoreCheck : MonoBehaviour
{
    void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player")) {
            GameManager.instance.score++;
            UIManager.instance.UpdateScoreUI(GameManager.instance.score);
            
            //Debug.Log(GameManager.instance.score);
        }
    }
}
