using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 15f;
    public float maxDistance = 8f;
    public float rotateSpeed = 1000f;
    public GameObject hitVFX;

    private Vector2 startPoint;
    private Vector2 moveDir;

    void Start()
    {
        startPoint = transform.position;
        // Move in the direction the shuriken is facing (its right axis)
        moveDir = transform.right.normalized;
    }

    void Update()
    {
        // Move in that direction every frame
        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);

        // Spin
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Destroy after traveling too far
        if (Vector2.Distance(startPoint, transform.position) >= maxDistance)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (hitVFX)
                Instantiate(hitVFX, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
