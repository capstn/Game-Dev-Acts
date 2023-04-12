using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public float speed = 5.0f;
    private Transform pacmanTransform;
    private bool isChasing = false;

    void Start()
    {
        pacmanTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, pacmanTransform.position, speed * Time.deltaTime);
        }
    }

    public void ChasePacman()
    {
        isChasing = true;
    }
}