using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool Hit;

    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Bullet5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hit == true)
        {
            if(Bullet1 != null)
            {
                Destroy(Bullet1);
            }
            if (Bullet2 != null)
            {
                Destroy(Bullet2);
            }
            if (Bullet3 != null)
            {
                Destroy(Bullet3);
            }
            if (Bullet4 != null)
            {
                Destroy(Bullet4);
            }
            if (Bullet5 != null)
            {
                Destroy(Bullet5);
            }
            
        }
    }
}
