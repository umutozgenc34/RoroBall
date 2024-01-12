using UnityEngine;

public class Ball : MonoBehaviour
{
    public float rotationSpeed = 200f; // D�nme h�z�
    public float maxSpeed = 10f; // Maksimum h�z

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �arp��ma ger�ekle�ti�inde kontrol et
        if (collision.gameObject.CompareTag("Goalpost") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Line"))
        {
            // �arpt��� nesne "Goalpost", "Player" veya "Line" ise d�nme hareketini uygula
            RotateBall();
        }
    }

    void RotateBall()
    {
        // D�nme hareketini uygula
        transform.Rotate(Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
        // Topun h�z�n� kontrol et ve maksimum h�z� a��yorsa s�n�rla
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}