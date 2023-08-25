using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
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
    }


}
