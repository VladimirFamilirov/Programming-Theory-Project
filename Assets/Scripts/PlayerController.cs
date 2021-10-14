using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float verticalInput;
    private float horizontalInput;
    private float speed = 15.0f;

    private bool freeHands = true;
    private GameObject objectToGrab;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if (freeHands == true)
        {

        GrabSmth();
        }
        else
        {

        ReleaseHands();
        }
    }
    private void GrabSmth()
    {
        if (Input.GetKeyDown(KeyCode.Space) && objectToGrab != null)
        {
            objectToGrab.transform.parent = playerRb.gameObject.transform;
            freeHands = false;
        }
    }
    private void ReleaseHands()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectToGrab.transform.parent = null;
            objectToGrab = null;
            freeHands = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick") && freeHands == true)
        {
            objectToGrab = collision.gameObject;
        }
        
    }
}
