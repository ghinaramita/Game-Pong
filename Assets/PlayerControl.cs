using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W; // Tombol untuk menggerakkan ke atas
    public KeyCode downButton = KeyCode.S; // Tombol untuk menggerakkan ke bawah
    public float speed = 10.0f;  // Kecepatan gerak
    public float yBoundary = 9.0f; // Batas atas dan bawah game scene (Batas bawah menggunakan minus (-))
    private Rigidbody2D rigidBody2D;  // Rigidbody 2D raket ini
    private int score;   // Skor pemain
    private ContactPoint2D lastContactPoint; // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity; // Dapatkan kecepatan raket sekarang.

        if (Input.GetKey(upButton)) // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas).
        {
            velocity.y = speed;
        }

        else if (Input.GetKey(downButton)) // Jika pemain menekan tombol ke bawah, beri kecepatan negatif ke komponen y (ke bawah).
        {
            velocity.y = -speed;
        }

        else
        {
            velocity.y = 0.0f; // Jika pemain tidak menekan tombol apa-apa, kecepatannya nol.
        }

        rigidBody2D.velocity = velocity; // Masukkan kembali kecepatannya ke rigidBody2D.

        Vector3 position = transform.position; // Dapatkan posisi raket sekarang.

        if (position.y > yBoundary) // Jika posisi raket melewati batas atas (yBoundary), kembalikan ke batas atas tersebut.
        {
            position.y = yBoundary;
        }

        else if (position.y < -yBoundary) // Jika posisi raket melewati batas bawah (-yBoundary), kembalikan ke batas atas tersebut.
        {
            position.y = -yBoundary;
        }

        transform.position = position; // Masukkan kembali posisinya ke transform.
    }

    public void IncrementScore() // Menaikkan skor sebanyak 1 poin
    {
        score++;
    }

    public void ResetScore() // Mengembalikan skor menjadi 0
    {
        score = 0;
    }

    public int Score // Mendapatkan nilai skor
    {
        get { return score; }
    }

    public ContactPoint2D LastContactPoint // Untuk mengakses informasi titik kontak dari kelas lain
    {
        get { return lastContactPoint; }
    }

    void OnCollisionEnter2D(Collision2D collision) // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
