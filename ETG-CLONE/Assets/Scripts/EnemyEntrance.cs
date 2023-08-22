using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntrance : MonoBehaviour
{
    public GameObject Object;
    public GameObject Boom;
    public GameObject CurrentEnemy;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public int EnemyNum;

    // Adjust the speed for the application.
    public float speed = 1.0f;

    // The target (cylinder) position.
    private Transform target;

    

    

    // Start is called before the first frame update
    void Start()
    {
        EnemyNum = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyNum == 1 || EnemyNum == 2)
        {
            CurrentEnemy = Enemy1;
        }
        if (EnemyNum == 3 || EnemyNum == 4)
        {
            CurrentEnemy = Enemy2;
        }
        if (EnemyNum == 5 || EnemyNum == 6)
        {
            CurrentEnemy = Enemy3;
        }


        float AngleRad = Mathf.Atan2(Object.transform.position.y - transform.position.y,
            Object.transform.position.x - transform.position.x);

        
        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 90);


        
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Object.transform.position, step);

        
        if (Vector3.Distance(transform.position, Object.transform.position) < 0.001f)
        {
            Instantiate(Boom, Object.transform.position, Object.transform.rotation);
            Instantiate(CurrentEnemy, Object.transform.position, Object.transform.rotation);
            Destroy(Object);
        }

    }
}
