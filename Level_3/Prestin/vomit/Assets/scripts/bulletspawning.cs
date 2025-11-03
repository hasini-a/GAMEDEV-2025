using UnityEngine;

public class bulletspawning : MonoBehaviour
{
  
    public GameObject particlePrefab; 
    public Transform spawnposition;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            GameObject newParticleEffect = Instantiate(particlePrefab, spawnposition.position, spawnposition.rotation);

            
           
            if (transform.localScale.x < 0)
            {
                newParticleEffect.transform.localScale = new Vector3(
                    newParticleEffect.transform.localScale.x * -1, 
                    newParticleEffect.transform.localScale.y, 
                    newParticleEffect.transform.localScale.z
                );
            }
            
            
        }
    }
}