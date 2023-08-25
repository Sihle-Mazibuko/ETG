using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth;
    public float currentHealth {  get; private set; }

    Rigidbody2D rb;

    [Header("Invulnerability")]
    [SerializeField] float duration =1;
    [SerializeField] int numOfFlashes =3;
    SpriteRenderer spriteRen;

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
        if(currentHealth <= 0 && gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
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
           if(gameObject.tag == "Player")
            {
                SceneManager.LoadScene("0.6. Go Behind Walls");
            }
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
