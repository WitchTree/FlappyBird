using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-30 * speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -530)
        {
            transform.position = new Vector3(1060f, 0, 0);
        }
    }

}
