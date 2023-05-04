using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MobileTouch : MonoBehaviour
{
    private Rigidbody player_R;
    private int JumpPower = 40;

    private void Start()
    {
        player_R = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                player_R.velocity = new Vector3(0, JumpPower, 0);
                player_R.AddForce(Vector3.down * 10);
            }
        }

    }

    
}
