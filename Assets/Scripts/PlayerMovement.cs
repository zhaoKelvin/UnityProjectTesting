using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    private bool _leftKey = false;
    private bool _rightKey = false;

    private void Update()
    {
        if (Input.GetKey("d"))
        {
            _rightKey = true;
        }
        else
        {
            _rightKey = false;
        }
        if (Input.GetKey("a"))
        {
            _leftKey = true;
        }
        else
        {
            _leftKey = false;
        }
    }

    // We marked this as "Fixed"Update because we
    // are using it to mess with physics
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);   // Add a force of 2000 on the z-axis

        if (_rightKey == true)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if (_leftKey == true)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
