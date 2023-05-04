using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody player_R;
    private int JumpPower = 40;


    private void Start()
    {
        player_R = GetComponent<Rigidbody>();
    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_R.velocity = new Vector3(0, JumpPower, 0);
           
        }
        player_R.AddForce(Vector3.down * 10);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        GameManager.instance.isGameover = true;
    }
    
    
}
