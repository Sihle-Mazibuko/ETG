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

    

    private void Start()
    {
        Player = GameObject.Find("Player ");
        WalkPosition = new Vector3(PlayerPosition.x + Random.Range(-RandomRange, RandomRange), PlayerPosition.y + Random.Range(-RandomRange, RandomRange), 0);
        //WalkPosition = new Vector2(Random.Range(2, 5), Random.Range(2, 5));
        StartCoroutine(Walking());
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, WalkPosition, speed * Time.deltaTime);
        PlayerPosition = Player.transform.position;
    }



    public IEnumerator Walking()
    {
        yield return new WaitForSeconds(timer);
        WalkPosition = new Vector3(PlayerPosition.x + Random.Range(-RandomRange, RandomRange), PlayerPosition.y + Random.Range(-RandomRange, RandomRange), 0);
        StartCoroutine(Walking());
    }
}
