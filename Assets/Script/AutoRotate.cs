using UnityEngine;

public class AutoRotateDown : MonoBehaviour
{
    // Kecepatan rotasi
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotasi objek pada sumbu Y ke arah bawah
        transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
    }
}
