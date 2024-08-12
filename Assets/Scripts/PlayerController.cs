using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float boundZ = 75f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    // Moves the plaer base on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalUnput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalUnput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // Prevent the player from leaving the top or bottom of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -boundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundZ);
        }

        if (transform.position.z > boundZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundZ);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
