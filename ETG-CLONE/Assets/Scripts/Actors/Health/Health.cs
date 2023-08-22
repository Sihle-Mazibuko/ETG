using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth;
    public float currentHealth {  get; private set; }

    Rigidbody2D rb;

    private void Awake()
    {
        currentHealth = startHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {
            //Hurt character
        }
        else
        {
            //Kill character
            DisableScripts(transform);
        }
    }

    private void DisableScripts(Transform parent)
    {
        // Disable scripts on the current object
        MonoBehaviour[] scripts = parent.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }

        // Disable scripts on child objects
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            DisableScripts(child);
        }
        // Disable shoot
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform shoot = GameObject.FindGameObjectWithTag("Enemy Gun").transform;
            shoot.gameObject.SetActive(false);
        }
    }


    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startHealth);

    }

    ////This was for testing
    //void DamagePlayer()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))  TakeDamage(1);
    //}

    //void Heal()
    //{
    //    if (Input.GetKeyDown(KeyCode.H)) AddHealth(1);

    //}

    //private void Update()
    //{
    //    DamagePlayer();
    //    Heal();
    //}


}
