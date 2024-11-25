using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    private float walk = 10.0f;
    public Camera cam;
    public float jumpHeight = 0.05f;
    public CharacterController controller;
    private float verticalVelocity = 0.0f; // New variable to track vertical velocity
    private float gravity = -6.81f; // Gravity constant
    public int health = 100;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = cam.transform.right * horizontal + player.transform.forward * vertical;

        // Apply gravity
        if (controller.isGrounded)
        {
            verticalVelocity = 0.0f; // Reset vertical velocity when grounded

            // Check for jump input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity); // Calculate jump velocity
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime; // Apply gravity when not grounded
        }

        move.y = verticalVelocity; // Apply vertical velocity to move vector

        controller.Move(move * walk * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("player took damage");
        if (health <= 0)
        {
            Debug.Log("Player is dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
