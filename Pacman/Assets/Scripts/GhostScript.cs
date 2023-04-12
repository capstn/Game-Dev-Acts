using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public float speed = 1.0f;
    public float visionRange = 5.0f;
    public float idleTime = 1.0f;

    private Transform pacmanTransform;
    private bool isChasing = false;
    private float idleTimer = 0.0f;
    private Vector2 randomDirection = Vector2.zero;

    void Start()
    {
        pacmanTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isChasing && IsPlayerInSight())
        {
            isChasing = true;
        }

        if (isChasing)
        {
            idleTimer = 0.0f;
            transform.position = Vector2.MoveTowards(transform.position, pacmanTransform.position, speed * Time.deltaTime);
        }
        else
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleTime)
            {
                idleTimer = 0.0f;
                randomDirection = GetRandomDirection();
            }

            transform.position += (Vector3) randomDirection * speed * Time.deltaTime;
        }
    }

    private bool IsPlayerInSight()
    {
        float distance = Vector2.Distance(transform.position, pacmanTransform.position);

        if (distance < visionRange)
        {
            Vector2 direction = (pacmanTransform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, LayerMask.GetMask("Walls"));

            if (hit.collider == null)
            {
                return true;
            }
        }

        return false;
    }

    private Vector2 GetRandomDirection()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        return directions[Random.Range(0, directions.Length)];
    }

    public void ChasePacman()
    {
        isChasing = true;
    }
}