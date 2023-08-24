using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    #region Fields

    public GameObject Doors;

    private GameObject _player;
    public GameObject _virtualCam;
    public GameObject Cam;
    public GameObject Enemy;

    public float RangeX;
    public float RangeY;
    public Vector2 EnemySpawn;
    public int SpawnAmount1;
    public int SpawnAmount2;
    public int SpawnAmount3;
    public int SpawnAmount4;
    public int RoundNumber;
    public int CurrentRound;
    

    public bool CombatStart;
    public bool CanFight;
    public bool CanSpawn;

    #endregion

    #region OnCollision

    private void Start()
    {
        
        // Get references.
        _player = GameObject.FindGameObjectWithTag("Player");
        Doors.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player  )
        {
            _virtualCam.SetActive(true);
           
            if (CanFight == true)
            {
                if (CombatStart == false)
                {

                    StartCoroutine(Door());


                }
                CombatStart = true;
                EnemySpawn = new Vector2(Cam.transform.position.x + Random.Range(-RangeX, RangeX), Cam.transform.position.y + Random.Range(-RangeY, RangeY));
                StartCoroutine(Spawn());
                CurrentRound = 1;
               
            }
            
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player /*&& CanFight == false*/)
        {
            _virtualCam.SetActive(false);
           

        }
    }

    

    private void Update()
    {
        if(CurrentRound == 2 && GameObject.FindGameObjectWithTag("Enemy") == null && CanSpawn == true)
        {
            StartCoroutine(Spawn2());
            CanSpawn = false;
        }

        if (CurrentRound == 3 && GameObject.FindGameObjectWithTag("Enemy") == null && CanSpawn == true)
        {
            StartCoroutine(Spawn3());
            CanSpawn = false;
        }

        if (CurrentRound == 4 && GameObject.FindGameObjectWithTag("Enemy") == null && CanSpawn == true)
        {
            StartCoroutine(Spawn4());
            CanSpawn = false;
        }
        //if(CurrentRound == RoundNumber && GameObject.FindGameObjectWithTag("Enemy") == null)
        //{
        //    CanFight = false;
        //}

        

    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(CloseDoor());
        //Doors.SetActive(true);
        if (SpawnAmount1 > 0 && CurrentRound == 1)
        {
            EnemySpawn = new Vector2(Cam.transform.position.x + Random.Range(-RangeX, RangeX), Cam.transform.position.y + Random.Range(-RangeY, RangeY));
            Instantiate(Enemy, EnemySpawn, transform.rotation);
            StartCoroutine(Spawn());
            
            SpawnAmount1 -= 1;
        }
       
        else if (CurrentRound < RoundNumber)
        {
            CurrentRound += 1;
            CanSpawn = true;
        }
        else
        {
            CanFight = false;
        }
    }

    public IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(1);
        
        //StartCoroutine(CloseDoor());
        if (SpawnAmount2 > 0 && CurrentRound == 2)
        {
            EnemySpawn = new Vector2(Cam.transform.position.x + Random.Range(-RangeX, RangeX), Cam.transform.position.y + Random.Range(-RangeY, RangeY));
            Instantiate(Enemy, EnemySpawn, transform.rotation);
            StartCoroutine(Spawn2());
            
            SpawnAmount2 -= 1;
        }
        
        else if (CurrentRound < RoundNumber)
        {
            CurrentRound += 1;
            CanSpawn = true;
        }
        else
        {
            CanFight = false;
        }
    }

    public IEnumerator Spawn3()
    {
        yield return new WaitForSeconds(1);
        //StartCoroutine(CloseDoor());
        if (SpawnAmount3 > 0 && CurrentRound == 3)
        {
            EnemySpawn = new Vector2(Cam.transform.position.x + Random.Range(-RangeX, RangeX), Cam.transform.position.y + Random.Range(-RangeY, RangeY));
            Instantiate(Enemy, EnemySpawn, transform.rotation);
            StartCoroutine(Spawn3());
            
            SpawnAmount3 -= 1;
        }
        
        else if (CurrentRound < RoundNumber)
        {
            CurrentRound += 1;
            CanSpawn = true;
        }
        else
        {
            CanFight = false;
        }
    }

    public IEnumerator Spawn4()
    {
        yield return new WaitForSeconds(1);
        //StartCoroutine(CloseDoor());
        if (SpawnAmount4 > 0 && CurrentRound == 4)
        {
            EnemySpawn = new Vector2(Cam.transform.position.x + Random.Range(-RangeX, RangeX), Cam.transform.position.y + Random.Range(-RangeY, RangeY));
            Instantiate(Enemy, EnemySpawn, transform.rotation);
            StartCoroutine(Spawn4());
            
            SpawnAmount4 -= 1;
        }
        else
        {
            CanFight = false;
        }


    }
    public IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Knock");
        StartCoroutine(Closed());
      


    }

    public IEnumerator Door()
    {
        yield return new WaitForSeconds(0.5f);
        
            Doors.SetActive(true);

       


    }

    public IEnumerator Closed()
    {
        yield return new WaitForSeconds(1f);

        if (CurrentRound == RoundNumber && GameObject.FindGameObjectWithTag("Enemy") == null && CanFight == false)
        {
            Doors.SetActive(false);

        }
        else
        {
            StartCoroutine(CloseDoor());
        }



    }


    #endregion
}
