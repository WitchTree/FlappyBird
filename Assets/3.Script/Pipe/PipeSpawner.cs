using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    //private int pipeCount = 5;
    [SerializeField]private GameObject[] pipes;
    
    private int current_index = 0; 

    private float lastSpawnTime;
    private float timeBetSpawn = 5f;

    void Start() {
        //pipes = new GameObject[pipeCount];
        lastSpawnTime = Time.time;
    }

    void Update() {
        //게임 오버 조건 추가하기

        SpawnPipes();

    }

    void SpawnPipes() {
        if (Time.time >= lastSpawnTime + timeBetSpawn) {
            lastSpawnTime = Time.time;

            float yPos = Random.Range(-10, 10);

            pipes[current_index].SetActive(false);
            pipes[current_index].SetActive(true);

            pipes[current_index].transform.position = new Vector3(transform.position.x, yPos, 0f);

            current_index++;
            if (current_index >= pipes.Length) {
                current_index = 0;
            }

        }
    }

}
