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
        // Update the UI text with the current ammo count form the weaponBehavior script
        ammoCount.text = (weapon.currentAmmo + " / " + weapon.maxAmmo);
        // Update the UI text with the current health from the PlayerMovement script
        health.text = ("Health: " + player.health+"%");
    }
}
