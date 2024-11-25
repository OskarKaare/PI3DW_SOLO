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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isStabbing && !isInsp)
        {
            StartCoroutine(stab());
            Debug.Log("Stabbing");
        }
        if(Input.GetKeyDown(KeyCode.F) && !isInsp)
        {
            StartCoroutine(inspect());
            Debug.Log("Inspecting");
        }
    }
    IEnumerator stab()
    {
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, 5f);
        if (hit.collider.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            enemyBehavior.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Missed");
        }
        isStabbing = true;
        //ani here
        yield return new WaitForSeconds(fireRate);
        isStabbing = false;
    }
    IEnumerator inspect()
    {
        isInsp = true;
        //ani here
        yield return new WaitForSeconds(inspRate);
        isInsp = false;
    }
}
