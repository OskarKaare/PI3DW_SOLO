using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeBehavior : MonoBehaviour
{
    public int damage = 70;
    public float fireRate = 1f;
    public float inspRate = 1.5f;
    public Animator animator;
    public bool isStabbing = false;
    public bool isInsp = false;
    public Camera fpsCam;
    public EnemyBehavior enemyBehavior;
  
    // Update is called once per frame
    void Update()
    {
        // if mousebutton 0 is pressed and not stabbing or inspecting start stab coroutine
        if (Input.GetMouseButtonDown(0) && !isStabbing && !isInsp)
        {
            StartCoroutine(stab());
            Debug.Log("Stabbing");
        }
        // if F is pressed and not inspecting or stabbing start inspect coroutine
        if (Input.GetKeyDown(KeyCode.F) && !isInsp && !isStabbing)
        {
            StartCoroutine(inspect());
            Debug.Log("Inspecting knife");
        }
    }
    IEnumerator stab()
    {
        // a ray cast is shot forward from the cameras position 10 units
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, 10f);
        // if it collides with a collider with the tag enemy
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            // the enemy  takes damage
            Debug.Log("stabbed Enemy");
            hit.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
        }
        // if the ray hits a collider with the layer ragdoll add force to its rigidbody 
        else if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("ragdoll"))
        {
            hit.collider.GetComponent<Rigidbody>().AddForce(-hit.normal * 10000);
        }
        else
        {
            Debug.Log("stab Missed");
        }
        // play the knife stab animation and set the isStabbing bool to true then wait for the fire rate variable and set the bools to false
        isStabbing = true;
        animator.SetBool("Knifestab", true);
        yield return new WaitForSeconds(fireRate);
        isStabbing = false;
        animator.SetBool("Knifestab", false);
    }
    IEnumerator inspect()
    {
        // play the knife inspect animation and set the isInsp bool to true then wait for the inspRate variable and set the bools to false
        isInsp = true;
        animator.SetBool("Knifeinspect", true);

        yield return new WaitForSeconds(inspRate);
        isInsp = false;
        animator.SetBool("Knifeinspect", false);
    }
}
