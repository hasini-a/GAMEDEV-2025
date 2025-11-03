using UnityEngine;
using System;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject vfxOnEnemyHit;
    public Action onCarExit;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(h, v).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Optional: press P again to exit the car
        if (Input.GetKeyDown(KeyCode.P))
        {
            onCarExit?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (vfxOnEnemyHit)
                Instantiate(vfxOnEnemyHit, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject); // Enemy dies 💀
        }
    }
}
