using UnityEngine;

public class PlayerBoomerangThrow : MonoBehaviour
{
    public GameObject boomerangPrefab;
    public Transform throwPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject boomerang = Instantiate(boomerangPrefab, throwPoint.position, throwPoint.rotation);
        }
    }
}
