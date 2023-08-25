using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float timer = 1.0f;

    public float RandomRange;

    public GameObject Player;

    public Vector2 WalkPosition;
    public Vector2 PlayerPosition;

    public bool Chase;
    public bool first;
    public float Range;
    
    public Vector2 Move;
    public LookAtPlayer play;
    public KinShoot shot;

    public bool Close;
    public float Distance;
    public float TriggerDistance;
    private float distanceX;
    private float distanceY;




    private void Start()
    {
        Player = GameObject.Find("Player");
        PlayerPosition = Player.transform.position;
        WalkPosition = new Vector3(PlayerPosition.x + Random.Range(-RandomRange, RandomRange), PlayerPosition.y + Random.Range(-RandomRange, RandomRange), 0);
        //WalkPosition = new Vector2(Random.Range(2, 5), Random.Range(2, 5));
        StartCoroutine(Walking());
        
        
        first = false;
    }
    
    private void Update()
    {
        PlayerPosition = Player.transform.position;
        if (gameObject.name == "Bullet Kin(Clone)" || gameObject.name == "Bandana Kin(Clone)")
        {
            transform.position = Vector3.MoveTowards(transform.position, WalkPosition, speed * Time.deltaTime);
            PlayerPosition = Player.transform.position;
        }
       

        if (Chase == true && gameObject.name == "Shotgun Kin(Clone)")
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        else if (gameObject.name == "Shotgun Kin(Clone)")
        {
           
            transform.position = Vector3.MoveTowards(transform.position, WalkPosition, speed * Time.deltaTime);
            

        }

        //Distance = Vector3.Distance(transform.position, Player.transform.position);
        Debug.DrawLine(transform.position, Player.transform.position, Color.green);
        Vector2 delta = transform.position - Player.transform.position;
        distanceX = delta.x;
        distanceY = delta.y;

        Distance = delta.magnitude;

        if (Distance <= TriggerDistance)
        {
            Close = true;
        }
        else
        {
            Close = false;
        }

        if (Close == true && first == false)
        {

            Chase = true;
            first = true;
            play.player = true;
            StartCoroutine(shot.ShotShoot());
        }

    }

   

    public IEnumerator Walking()
    {
        yield return new WaitForSeconds(timer);
        WalkPosition = new Vector2(PlayerPosition.x + Random.Range(-RandomRange, RandomRange), PlayerPosition.y + Random.Range(-RandomRange, RandomRange));
        StartCoroutine(Walking());
    }

    //public IEnumerator Walk()
    //{
    //    yield return new WaitForSeconds(time);
    //    Move = new Vector2(transform.position.x + Random.Range(-Range, Range), transform.position.y + Random.Range(-Range, Range));
    //    StartCoroutine(Walk());
    //}
}
