using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsPrefab;
    private Vector3 spawnPos = new Vector3(30, 0, 0);

    private PlayerController playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObs", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObs()
    {
        if (playerControl.gameOver == false)
        { 
            Instantiate(obsPrefab, spawnPos, obsPrefab.transform.rotation);
        }
    }
}
