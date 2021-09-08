using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D; // Rigidbody 2D bola
    public float xInitialForce; // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float yInitialForce;
    private Vector2 trajectoryOrigin; // Titik asal lintasan bola saat ini

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame(); // Mulai game
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetBall()
    {
        transform.position = Vector2.zero; // Reset posisi menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero; // Reset kecepatan menjadi (0,0)
    }

    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce); // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float randomDirection = Random.Range(0, 2); // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)

        if (randomDirection < 1.0f) // Jika nilainya di bawah 1, bola bergerak ke kiri. Jika tidak, bola bergerak ke kanan.
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce)); // Gunakan gaya untuk menggerakkan bola ini.
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame()
    {
        ResetBall(); // Kembalikan bola ke posisi semula
        Invoke("PushBall", 2); // Setelah 2 detik, berikan gaya ke bola
    }

    private void OnCollisionExit2D(Collision2D collision) // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin // Untuk mengakses informasi titik asal lintasan
    {
        get { return trajectoryOrigin; }
    }
}
