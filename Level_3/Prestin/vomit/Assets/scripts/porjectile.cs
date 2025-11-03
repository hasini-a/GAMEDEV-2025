using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
       
        rb.velocity = transform.right * speed;
    }
}