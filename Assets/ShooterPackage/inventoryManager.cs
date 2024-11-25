using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public GameObject knife;
    public GameObject ak;
    public weaponBehavior weaponBehavior;
    public float switchdelay = 1.5f;
    public bool SwitchBool = false;
    // Start is called before the first frame update
    void Start()
    {
        ak.SetActive(true);
        knife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(SwitchBool == false)
            {
                // play anis here
                StartCoroutine(switchDelayToKnife());
             
            }
            else if(SwitchBool == true)
            {    
                // play anis here
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
        yield return new WaitForSeconds(switchdelay);
        SwitchBool = true;
    }
    IEnumerator switchDelayToAk()
    {
      
        ak.SetActive(true);
        knife.SetActive(false);
        yield return new WaitForSeconds(switchdelay);
        SwitchBool = false;
    }
}
