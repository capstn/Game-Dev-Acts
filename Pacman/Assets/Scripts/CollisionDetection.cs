using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public int coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin eat!");
        coin += 1;
        collision.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
