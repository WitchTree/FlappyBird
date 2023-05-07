using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody player_R;
    private int JumpPower = 40;
    [SerializeField] private AudioSource jumpSound;


    private void Start()
    {
        player_R = GetComponent<Rigidbody>();
    
    }
    private void Update()
    {
        //(Input.GetTouch(0).phase==TouchPhase.Stationary)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player_R.velocity = new Vector3(0, JumpPower, 0);
           
            jumpSound.Play();
        }
        player_R.AddForce(Vector3.down * 20);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        GameManager.instance.isGameover = true;
    }
    
    
}
