using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] boundries = new Vector3[4];
    [SerializeField] GameObject fishPrefab;

    private void Start()
    {
        float spawnPositionX = Random.Range(boundries[0].x, boundries[1].x);
        float spawnPositionY = Random.Range(boundries[1].y, boundries[2].y);
        Instantiate(fishPrefab, new Vector3(spawnPositionX, spawnPositionY, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
    }
    
    
}
