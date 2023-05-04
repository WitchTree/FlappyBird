using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeControl : MonoBehaviour
{
    private float speed = 10f;
    //private bool isActive = false;

    void Update() {
        PipeMove();
        PipeSetDeactive();
    }

    void PipeMove() {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }

    void PipeSetDeactive() {
        if(transform.position.x < -12) {
            gameObject.SetActive(false);
        }
    }

    
}
