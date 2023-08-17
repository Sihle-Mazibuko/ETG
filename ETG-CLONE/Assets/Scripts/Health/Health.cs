using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth;
    public float currentHealth {  get; private set; }

    private void Awake()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if(currentHealth> 0)
        {
            //Hurt character
        }
        else
        {
            //Kill character
        }
    }

}
