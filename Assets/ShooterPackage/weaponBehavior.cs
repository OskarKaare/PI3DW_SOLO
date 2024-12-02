using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponBehavior : MonoBehaviour
{
    public int damage = 30;
    public float fireRate = 0.5f;
    public ParticleSystem muzzleFlash;
    public int maxAmmo = 150;
    public int maxClip = 30;
    public int currentAmmo = 30;
    public float reloadDelay= 2f;
    public bool isReloading = false;
    public Animator animator;
    public bool isShooting = false;
    public Camera fpsCam;
    public bool isInsp = false;
    public int inspRate = 2;




    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
       // if mousebutton 0 is pressed
        if (Input.GetMouseButton(0) && currentAmmo > 0 && !isReloading && !isShooting && !isInsp)
        {
            StartCoroutine(shoot());
            Debug.Log("Shooting");
        }
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxClip && maxAmmo > 0 && !isReloading && !isInsp )
        {
            StartCoroutine(reload());
            Debug.Log("Reloading");
        }
        if (Input.GetKeyDown(KeyCode.F) && !isReloading && !isShooting)
        {
            StartCoroutine(inspect());
        }
    }
  
    IEnumerator reload()
    {
        
        isReloading = true;
        animator.SetBool("Anireload", true);
        yield return new WaitForSeconds(reloadDelay);

        if (currentAmmo > 0)
        {
          
            maxAmmo += currentAmmo;
        }

        if (maxAmmo >= maxClip)
        {
            // animator.SetBool("Reloading", true);
            currentAmmo = maxClip;
            maxAmmo -= maxClip;
        }
        else if (maxAmmo < maxClip && maxAmmo > 0)
        {
            // animator.SetBool("Reloading", true);
            currentAmmo = maxAmmo;
            maxAmmo = 0;
        }
        else
        {
            currentAmmo = 0;

        }
        // animator.SetBool("Reloading", false);
        isReloading = false;
        animator.SetBool("Anireload", false);
    }
    IEnumerator shoot()
    {
     
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, 200f))
        {
            if (hit.collider != null && hit.collider.tag == "Enemy")
            {
                Debug.Log("Hit Enemy");
                hit.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
            }
            else if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("ragdoll"))         
            {
              hit.collider.GetComponent<Rigidbody>().AddForce (-hit.normal * 10000);
            }
            else
            {
                Debug.Log("Missed");
            }
        }
        else
        {
            Debug.Log("Missed");
        }
        
        currentAmmo--;
        if (currentAmmo <= 0 && maxAmmo>0)
        {
            StartCoroutine(reload());
        }
        else if(currentAmmo <= 0 && maxAmmo <= 0)
        {
            //play click sound /no ammo stuff
            Debug.Log("No Ammo");
        }
        muzzleFlash.Play();
        isShooting = true;
        animator.SetBool("Anishoot", true);
        yield return new WaitForSeconds(fireRate);
        animator.SetBool("Anishoot", false);
        isShooting = false;
    }

    IEnumerator inspect()
    {
        animator.SetBool("Aniinspect", true);
        isInsp = true;
        yield return new WaitForSeconds(inspRate);
        animator.SetBool("Aniinspect", false);
        isInsp = false;
    }
}
