using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 10;
    public float jump_speed;

    private int num_jumps;

    private int count;
    public TextMeshProUGUI countText;
    public GameObject WinTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        jump_speed = 7;
        SetCountText();
        WinTextObject.SetActive(false);

        num_jumps = 2;
    }

    // Update is called once per frame
    void Update() // update each and every single frame
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && num_jumps > 0)
        {
            num_jumps -= 1;
            rb.velocity = new Vector3(rb.velocity.x, jump_speed, rb.velocity.z);
        }
    }

	void FixedUpdate() // called before preforming any physics calculations
	{
        rb.AddForce(new Vector3(movementX, 0, movementY) * speed);
	}

	void OnMove(InputValue movementValue) // movementValue is a vec2 for x, y movement
	{
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
	}

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            WinTextObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            num_jumps = 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        // trigger is different then collider cuz trigger checks if something is overlapping with it
        // you have to turn on the tirgger to actually use it

        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // object still exists just not used now
            count += 1;
            SetCountText();
        }

    }
}
