using UnityEngine;

public class Collisiondetection : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Bullet"))
        {
           
            Destroy(other.gameObject);
            
            
            Destroy(gameObject);
        }
    }
}