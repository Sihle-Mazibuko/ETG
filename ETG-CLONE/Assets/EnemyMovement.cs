using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public float speed = 1.0f;

    public GameObject Player;

    public Vector2 WalkPosition;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PLAYER");
        WalkPosition = new Vector3(Player.transform.localPosition.x + Random.Range(1, 6), Player.transform.localPosition.y + Random.Range(1, 6), 0);
        //WalkPosition = new Vector2(Random.Range(2, 5), Random.Range(2, 5));
        StartCoroutine(Walking());
    }

    

    // Update is called once per frame
    void Update()
    {
        

        transform.position = Vector3.MoveTowards(transform.position, WalkPosition, speed * Time.deltaTime);
    }

    public IEnumerator Walking()
    {
        yield return new WaitForSeconds(2f);
        WalkPosition = new Vector3(Player.transform.localPosition.x + Random.Range(1, 6), Player.transform.localPosition.y + Random.Range(1, 6), 0);
        StartCoroutine(Walking());
    }
}
