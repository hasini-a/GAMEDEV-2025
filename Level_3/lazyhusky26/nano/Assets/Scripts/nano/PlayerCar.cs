using UnityEngine;

public class PlayerCarTransform : MonoBehaviour
{
    public GameObject carPrefab;
    public AudioClip keySound;
    public GameObject vfxOnEnemyHit;

    private AudioSource audioSource;
    private bool isCarMode = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isCarMode)
        {
            StartCoroutine(ActivateCarMode());
        }
    }

    private System.Collections.IEnumerator ActivateCarMode()
    {
        // 🔑 Play key sound
        if (keySound)
            audioSource.PlayOneShot(keySound);

        // Wait a moment for comedic timing
        yield return new WaitForSeconds(0.6f);

        // Hide player sprite
        GetComponent<SpriteRenderer>().enabled = false;

        // 🚗 Spawn the car
        GameObject car = Instantiate(carPrefab, transform.position, Quaternion.Euler(0, 180, 0));

        CarController carScript = car.GetComponent<CarController>();

        // Give the car access to the VFX
        if (carScript)
            carScript.vfxOnEnemyHit = vfxOnEnemyHit;

        // Disable player movement (if any)
        if (TryGetComponent<PlayerMovement>(out var move))
            move.enabled = false;

        isCarMode = true;

        // Follow player transform — optional
        carScript.onCarExit += () =>
        {
            transform.position = car.transform.position;
            GetComponent<SpriteRenderer>().enabled = true;
            if (move) move.enabled = true;
            Destroy(car);
            isCarMode = false;
        };
    }
}
