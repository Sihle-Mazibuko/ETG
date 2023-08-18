using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinShoot : MonoBehaviour
{
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Shoot());
        Instantiate(Bullet, transform.position, transform.rotation);
        
    }
}
