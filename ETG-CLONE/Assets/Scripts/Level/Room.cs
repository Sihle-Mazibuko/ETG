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
    public int SpawnAmount;

    public bool CombatStart;
    public bool CanFight;

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
            if(CanFight == true)
            {
                CombatStart = true;
                EnemySpawn = new Vector2(Cam.transform.position.x + Random.Range(-RangeX, RangeX), Cam.transform.position.y + Random.Range(-RangeY, RangeY));
                StartCoroutine(Spawn());
            }
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            _virtualCam.SetActive(false);
            Doors.SetActive(true);
            

        }
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1);
        EnemySpawn = new Vector2(Cam.transform.position.x + Random.Range(-RangeX, RangeX), Cam.transform.position.y + Random.Range(-RangeY, RangeY));
        Instantiate(Enemy, EnemySpawn, transform.rotation);
        if(SpawnAmount >0)
        {
            StartCoroutine(Spawn());
            SpawnAmount -= 1;
        }
    }
    #endregion
}
