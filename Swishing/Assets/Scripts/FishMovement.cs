using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FishMovement : MonoBehaviour
{
    
    [SerializeField] private float fishSpeed = 5;
    [SerializeField] private Vector3[] moveTargets =  new Vector3[2];
    int moveDirection = 0;
    private float xTarget;
    private float yTarget;
    private int side;

    private void Start()
    {
        yTarget = Random.Range(moveTargets[0].y, moveTargets[1].y);
        
        side =  Random.Range(0, 2);
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, new Vector3(moveTargets[side].x, yTarget, 0)) < 1.0f)
        {
            side = (side + 1) % moveTargets.Length;
            
            yTarget = Random.Range(moveTargets[0].y, moveTargets[1].y);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveTargets[side].x, yTarget, 0), Time.deltaTime * fishSpeed);
    }
}
