using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalBehavior : MonoBehaviour
{
   // run method when player collides with the portal

    private void OnTriggerEnter(Collider other)
    {
        // if the player collies with the portal, reload the scene
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You WON");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
