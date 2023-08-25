using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    int totalWeapons = 1;
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
        SwitchWeapon();
    }

    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 weaponRelativePosition = weapons[currentWeaponIndex].transform.localPosition;
            weapons[currentWeaponIndex].SetActive(false);

            currentWeaponIndex = (currentWeaponIndex + 1) % totalWeapons;

            weapons[currentWeaponIndex].SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];

            weapons[currentWeaponIndex].transform.localPosition = weaponRelativePosition;

        }
    }
}
