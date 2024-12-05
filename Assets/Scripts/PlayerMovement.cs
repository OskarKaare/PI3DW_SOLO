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
        // make a vector move that is the direction the player is moving
        Vector3 move = cam.transform.right * horizontal + player.transform.forward * vertical;

        // Apply gravity
        if (controller.isGrounded)
        {
            // Reset vertical velocity when grounded
            verticalVelocity = 0.0f; 

            // Check for jump input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Jump velocity is calcualted
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity); 
            }
        }
        else
        {
            // If not grounded, apply gravity
            verticalVelocity += gravity * Time.deltaTime; 
        }

        // apply the vertical velocity to the move vector
        move.y = verticalVelocity; 
        // move the player with a vector and walk speed variable(and time)
        controller.Move(move * walk * Time.deltaTime);
    }
    // player take damage method
    public void TakeDamage(int damage)
    {
        // health is reduced by the damage amount
        health -= damage;
        Debug.Log("player took damage");
        // and if health is less than or equal to 0, the player dies :(
        if (health <= 0)
        {
            // reload scene on death
            Debug.Log("Player is dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
