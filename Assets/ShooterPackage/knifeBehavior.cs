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
        if (Input.GetMouseButtonDown(0) && !isStabbing && !isInsp)
        {
            StartCoroutine(stab());
            Debug.Log("Stabbing");
        }
        if (Input.GetKeyDown(KeyCode.F) && !isInsp)
        {
            StartCoroutine(inspect());
            Debug.Log("Inspecting knife");
        }
    }
    IEnumerator stab()
    {

        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, 10f);
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            Debug.Log("stabbed Enemy");
            hit.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
        }
        else if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("ragdoll"))
        {
            hit.collider.GetComponent<Rigidbody>().AddForce(-hit.normal * 10000);
        }
        else
        {
            Debug.Log("stab Missed");
        }

        isStabbing = true;
        animator.SetBool("Knifestab", true);
        yield return new WaitForSeconds(fireRate);
        isStabbing = false;
        animator.SetBool("Knifestab", false);
    }
    IEnumerator inspect()
    {
        isInsp = true;
        animator.SetBool("Knifeinspect", true);

        yield return new WaitForSeconds(inspRate);
        isInsp = false;
        animator.SetBool("Knifeinspect", false);
    }
}
