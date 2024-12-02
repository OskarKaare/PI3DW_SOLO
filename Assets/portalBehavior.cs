using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalBehavior : MonoBehaviour
{
    public MeshCollider MeshCol;

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the portal");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
