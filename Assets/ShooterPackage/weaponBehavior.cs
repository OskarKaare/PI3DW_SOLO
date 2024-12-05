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
    public AudioSource ShootSound;
    public AudioSource ReloadSound;


    // Update is called once per frame
    void Update()
    {
       // if mousebutton 0 is pressed and current ammo is greater than 0 and not reloading, shooting or inspecting start shoot coroutine
        if (Input.GetMouseButton(0) && currentAmmo > 0 && !isReloading && !isShooting && !isInsp)
        {
            StartCoroutine(shoot());
            Debug.Log("Shooting");
        }
        // if R is pressed and current ammo is less than max clip and max ammo is greater than 0 and not reloading or inspecting start reload coroutine
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxClip && maxAmmo > 0 && !isReloading && !isInsp )
        {
            StartCoroutine(reload());
            Debug.Log("Reloading");
        }
        // if F is pressed and not reloading or shooting start inspect coroutine
        if (Input.GetKeyDown(KeyCode.F) && !isReloading && !isShooting)
        {
            StartCoroutine(inspect());
        }
    }
  
    IEnumerator reload()
    {
          
        isReloading = true;
        ReloadSound.Play();
        animator.SetBool("Anireload", true);
        yield return new WaitForSeconds(reloadDelay);
        // if current ammo is greater than 0 add current ammo to max ammo
        if (currentAmmo > 0)
        {
          
            maxAmmo += currentAmmo;
        }
        // if max ammo is greater than or equal to max clip set current ammo to max clip and subtract max clip from max ammo
        if (maxAmmo >= maxClip)
        {
           
            currentAmmo = maxClip;
            maxAmmo -= maxClip;
        }
        // if max ammo is less than max clip and greater than 0 set current ammo to max ammo and set max ammo to 0
        else if (maxAmmo < maxClip && maxAmmo > 0)
        {
           
            currentAmmo = maxAmmo;
            maxAmmo = 0;
        }
        // if max ammo is less than or equal to 0 set current ammo to 0
        else
        {
            currentAmmo = 0;
        }
       
        isReloading = false;
        animator.SetBool("Anireload", false);
    }
    IEnumerator shoot()
    {
     // if the ray hits anything within 200 units
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, 200f))
        {
            // if ray hits an object with the tag "Enemy" call the TakeDamage method from the EnemyBehavior script
            if (hit.collider != null && hit.collider.tag == "Enemy")
            {

                Debug.Log("Hit Enemy");
                hit.collider.GetComponent<EnemyBehavior>().TakeDamage(damage);
            }
            // if the ray hits an object with the layer "ragdoll" add force to the objects rigidbody
            else if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("ragdoll"))         
            {
              hit.collider.GetComponent<Rigidbody>().AddForce (-hit.normal * 1000);
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
        // play sound and substract 1 from current ammo
        ShootSound.PlayOneShot(ShootSound.clip);
        currentAmmo--;
        // if current ammo is less than or equal to 0 and max ammo is greater than 0 start reload coroutine
        if (currentAmmo <= 0 && maxAmmo>0)
        {
            StartCoroutine(reload());
        }
        // if current ammo is less than or equal to 0 and max ammo is less than or equal to 0
        else if(currentAmmo <= 0 && maxAmmo <= 0)
        {
            Debug.Log("No Ammo");
        }
        // play muzzle flash and pause courutine with fire rate variable
        muzzleFlash.Play();
        isShooting = true;
        animator.SetBool("Anishoot", true);
        yield return new WaitForSeconds(fireRate);
        animator.SetBool("Anishoot", false);
        isShooting = false;
    }

    IEnumerator inspect()
    {
        // play inspect animation and pause coroutine with inspRate variable
        animator.SetBool("Aniinspect", true);
        isInsp = true;
        yield return new WaitForSeconds(inspRate);
        animator.SetBool("Aniinspect", false);
        isInsp = false;
    }
  
}
