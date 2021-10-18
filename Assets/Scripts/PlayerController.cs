using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject playerRotAxis;

    private Vector3 mousePos;
    private Vector3 playerPos;
    private float angleMouseToPlayer;

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
    private void RotateToCursor()
    {
        if (objectToGrab != null)
        {//mousePos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePos = Input.mousePosition;

        var brickPos = Camera.main.WorldToScreenPoint(objectToGrab.transform.position);
        var angleMouseToBrick = Mathf.Atan2(brickPos.x - mousePos.x, brickPos.y - mousePos.y) * Mathf.Rad2Deg;
        playerRotAxis.transform.rotation = Quaternion.Euler(new Vector3(0, angleMouseToBrick, 0));

        playerPos = Camera.main.WorldToScreenPoint(playerRb.position);
        angleMouseToPlayer = Mathf.Atan2(playerPos.x - mousePos.x, playerPos.y - mousePos.y) * Mathf.Rad2Deg;
        playerRotAxis.transform.rotation = Quaternion.Euler(new Vector3(0, angleMouseToPlayer, 0));

        }
        
    }
    private void GrabSmth()
    {
        if (objectToGrab != null && Input.GetKeyDown(KeyCode.Space))
        {
            
            objectToGrab.transform.parent = playerRotAxis.gameObject.transform;

            freeHands = false;
        }
    }
    private void ReleaseHands()
    {
        if (objectToGrab != null && Input.GetKeyDown(KeyCode.Space))
        {
            objectToGrab.transform.parent = null;
            objectToGrab = null;
            freeHands = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            objectToGrab = null;
            freeHands = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RotateToCursor();
        
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null && (collision.gameObject.CompareTag("Brick") || collision.gameObject.CompareTag("Gem")) && freeHands == true)
        {
            objectToGrab = collision.gameObject;
        }
        
    }
}
