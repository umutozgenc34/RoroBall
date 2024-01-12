using UnityEngine;

public class Ball : MonoBehaviour
{
    public float rotationSpeed = 200f; // Dönme hýzý
    public float maxSpeed = 10f; // Maksimum hýz

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpýþma gerçekleþtiðinde kontrol et
        if (collision.gameObject.CompareTag("Goalpost") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Line"))
        {
            // Çarptýðý nesne "Goalpost", "Player" veya "Line" ise dönme hareketini uygula
            RotateBall();
        }
    }

    void RotateBall()
    {
        // Dönme hareketini uygula
        transform.Rotate(Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
        // Topun hýzýný kontrol et ve maksimum hýzý aþýyorsa sýnýrla
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}