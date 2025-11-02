using UnityEngine;

public class bulletspawning : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnposition;

    [Tooltip("The angle (in degrees) for the spread shot. 15 is a good start.")]
    public float spreadAngle = 15f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Quaternion rotationUp = spawnposition.rotation * Quaternion.Euler(0, 0, spreadAngle);
            Quaternion rotationDown = spawnposition.rotation * Quaternion.Euler(0, 0, -spreadAngle);

           
            SpawnOneBullet(spawnposition.rotation); 
            SpawnOneBullet(rotationUp);          
            SpawnOneBullet(rotationDown);        
        }
    }

    
    void SpawnOneBullet(Quaternion rotation)
    {
        
        GameObject newBullet = Instantiate(bullet, spawnposition.position, rotation);

        
        if (transform.localScale.x < 0)
        {
            SpriteRenderer sr = newBullet.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                
                sr.flipX = true;
            }
            else
            {
               
                newBullet.transform.localScale = new Vector3(
                    newBullet.transform.localScale.x * -1,
                    newBullet.transform.localScale.y,
                    newBullet.transform.localScale.z
                );
            }
        }
    }
}