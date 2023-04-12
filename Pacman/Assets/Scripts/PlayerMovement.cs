using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    public GameObject ghost;
    private int coinCount = 0;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

        Vector3 characterScale = transform.localScale;
        Quaternion characterRotation = transform.localRotation;

        if (Input.GetAxis("Horizontal") < 0 )
        {
            characterScale.x = -1;
            characterRotation.z = 0;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
            characterRotation.z = 0;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            characterRotation = Quaternion.Euler(1, 1, -100);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            characterRotation = Quaternion.Euler(1, 1, 100);
        }

        transform.localScale = characterScale;
        transform.localRotation = characterRotation;
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            ghost.GetComponent<GhostScript>().ChasePacman();
        }
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
