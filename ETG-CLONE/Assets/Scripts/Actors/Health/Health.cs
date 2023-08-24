using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth;
    public float currentHealth;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;
    public GameObject Heart6;

    Rigidbody2D rb;
    public GameObject Object;

    [Header("Invulnerability")]
    [SerializeField] float duration =1;
    [SerializeField] int numOfFlashes =3;
    SpriteRenderer spriteRen;

    private void Start()
    {
        Heart1 = GameObject.Find("Heart 1");
        Heart2 = GameObject.Find("Heart 2");
        Heart3 = GameObject.Find("Heart 3");
        Heart4 = GameObject.Find("Heart 4");
        Heart5 = GameObject.Find("Heart 5");
        Heart6 = GameObject.Find("Heart 6");
    }
    private void Awake()
    {
        currentHealth = startHealth;
        rb = GetComponent<Rigidbody2D>();

        if(transform.tag == "Player")
        {
            spriteRen = GetComponent<SpriteRenderer>();
        }else if(transform.tag == "Enemy")
        {
            spriteRen = GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Object.SetActive(false);
        }
        if (transform.tag == "Player")
        {
            if(currentHealth == 6)
            {
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(true);
            }
            else if (currentHealth == 5)
            {
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                Heart6.SetActive(false);
            }
            else if (currentHealth == 4)
            {
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
            }
            else if (currentHealth == 3)
            {
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
            }
            else if (currentHealth == 2)
            {
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
            }
            else if (currentHealth == 1)
            {
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
            }
            else if (currentHealth <= 0)
            {
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                Heart6.SetActive(false);
            }
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {
            //Hurt character
            StartCoroutine(Invunerability());
        }
        else
        {
           
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

    //Character colour flash + invulnerability
    IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10,22,true);
        for (int i = 0; i < numOfFlashes; i++)
        {
            spriteRen.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(duration/(numOfFlashes * 2));
            spriteRen.color = Color.white;
            yield return new WaitForSeconds(duration/(numOfFlashes *2));
        }
        Physics2D.IgnoreLayerCollision(10, 22,false);

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
