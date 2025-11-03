using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 5f;
    public float rotateSpeed = 720f;
    public GameObject hitVFX;

    private Vector2 startPoint;
    private Transform player;
    private Transform targetEnemy;
    private bool returning = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPoint = transform.position;

        // Find nearest enemy when thrown
        targetEnemy = FindClosestEnemy();
    }

    void Update()
    {
        if (!returning)
        {
            if (targetEnemy)
            {
                // Move toward enemy
                Vector2 dir = ((Vector2)targetEnemy.position - (Vector2)transform.position).normalized;
                transform.Translate(dir * speed * Time.deltaTime, Space.World);
            }
            else
            {
                // Move straight if no enemy found
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            if (Vector2.Distance(startPoint, transform.position) >= maxDistance)
                returning = true;
        }
        else
        {
            // Return to player
            Vector2 dir = ((Vector2)player.position - (Vector2)transform.position).normalized;
            transform.Translate(dir * speed * Time.deltaTime, Space.World);

            if (Vector2.Distance(player.position, transform.position) < 0.5f)
                Destroy(gameObject);
        }

        // Spin effect
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (hitVFX)
                Instantiate(hitVFX, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            returning = true; // return after hit
        }
    }

    private Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = e.transform;
            }
        }

        return closest;
    }
}
