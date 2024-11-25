using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBehavior : MonoBehaviour
{
    public TMP_Text ammoCount;
    public TMP_Text health;
    public weaponBehavior weapon;
    public PlayerMovement player;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        ammoCount.text = (weapon.currentAmmo + " / " + weapon.maxAmmo);
        health.text = ("Health: " + player.health+"%");
    }
}
