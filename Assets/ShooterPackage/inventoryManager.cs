using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public GameObject knife;
    public GameObject ak;
    public weaponBehavior weaponBehavior;
    public knifeBehavior knifeBehavior;
    public float switchdelay = 1.5f;
    public bool SwitchBool = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ak.SetActive(true);
        knife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (SwitchBool == false && weaponBehavior.isInsp == false && weaponBehavior.isReloading == false && weaponBehavior.isShooting == false && knifeBehavior.isInsp == false && knifeBehavior.isStabbing == false)
            {

                StartCoroutine(switchDelayToKnife());

            }
            else if (SwitchBool == true && weaponBehavior.isInsp == false && weaponBehavior.isReloading == false && weaponBehavior.isShooting == false && knifeBehavior.isInsp == false && knifeBehavior.isStabbing == false)
            {

                StartCoroutine(switchDelayToAk());

            }
            else
            {
                return;
            }
        }
    }

    IEnumerator switchDelayToKnife()
    {

        knife.SetActive(true);
        ak.SetActive(false);
        animator.SetBool("Aniidle", false);
        animator.SetBool("Knifeidle", true);

        yield return new WaitForSeconds(switchdelay);
        SwitchBool = true;
    }
    IEnumerator switchDelayToAk()
    {

        ak.SetActive(true);
        knife.SetActive(false);
        animator.SetBool("Knifeidle", false);
        animator.SetBool("Aniidle", true);

        yield return new WaitForSeconds(switchdelay);
        SwitchBool = false;
    }
}
