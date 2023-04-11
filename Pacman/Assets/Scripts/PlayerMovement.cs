using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
  

{
    [SerializeField] float movementSpeed = 10f;

    void Start()
    {

    }
    
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
            Debug.Log(characterRotation);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            characterRotation = Quaternion.Euler(1, 1, 100);
            Debug.Log(characterRotation);
        }

        transform.localScale = characterScale;
        transform.localRotation = characterRotation;
        
    }

}
