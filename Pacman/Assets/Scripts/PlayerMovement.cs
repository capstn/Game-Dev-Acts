using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    public GameObject ghost;
    private int coinCount = 0;


    private void Start()
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
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            characterRotation = Quaternion.Euler(1, 1, 100);
        }

        transform.localScale = characterScale;
        transform.localRotation = characterRotation;
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            foreach (GameObject obj in Object.FindObjectsOfType<GameObject>())
            {
                if (obj != gameObject)
                {
                    Destroy(obj);
                }
            }

            // Restart the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
