using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    public bool Chase;
    public bool first;
    public GameObject Player;
    public float speed = 1f;
    public float Range;
    public float time;
    public Vector2 Move;
    public LookAtPlayer play;
    public KinShoot shot;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        StartCoroutine(Walk());
        first = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Chase == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Move, speed * Time.deltaTime);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Player" && first == false)
        {
            Chase = true;
            first = true;
            play.player = true;
            StartCoroutine(shot.ShotShoot());
        }
    }

    public IEnumerator Walk()
    {
        yield return new WaitForSeconds(time);
        Move = new Vector2(transform.position.x + Random.Range(-Range, Range), transform.position.y + Random.Range(-Range, Range));
        StartCoroutine(Walk());
    }
}
