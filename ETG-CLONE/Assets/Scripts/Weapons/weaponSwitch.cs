using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    public int totalWeapons = 1;
    int currentWeaponIndex;

    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject currentWeapon;

    private void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);

        currentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
    weapons[currentWeaponIndex].SetActive(false);
        
        currentWeaponIndex = (currentWeaponIndex + 1) % totalWeapons;
        
        weapons[currentWeaponIndex].SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];        }
    }

}
