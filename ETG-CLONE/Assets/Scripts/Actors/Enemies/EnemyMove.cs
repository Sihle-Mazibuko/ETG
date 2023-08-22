using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#region Class Description
/*
 * 
 */
#endregion

public class EnemyMove : MonoBehaviour
{
    #region Fields

    #region Public Fields:

    public Transform target;
    public float targetStopDistance = 1.5f;
    public float followTime = 0.1f;
    public float aiUpdateTick = 1;
    public bool isActive;
    public LayerMask includeOnPlayerCheck;
    #endregion

    #region Private Fields:

    private NavMeshAgent _navMeshAgent;
    private GameObject _player;
    private Vector3 _target;
    
    private float _aiUpdate;
    private float _distanceToPlayer;
    private bool _chasePlayer;
    private bool _lookingForPlayer;
    
    private Vector3 _myPosition;
    //private Vector3 _playerPosition;
    #endregion

    #endregion

    #region References and Initialisations

    private void Start()
    {
        // Get references.
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent.stoppingDistance = _player.GetComponent<CharacterController>().bounds.extents.x + targetStopDistance;
    }
    #endregion

    #region Check for Player

    public void CheckForPlayer()
    {        
        RaycastHit hit;
        Ray ray = new Ray(_myPosition, _player.transform.position - _myPosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                _chasePlayer = true;

                if (_lookingForPlayer)
                {
                    StopCoroutine(FollowCountDown());
                    Debug.Log("Stoppin Coroutine");
                }
            }
            else
            {
                if (!_lookingForPlayer)
                {
                    StartCoroutine(FollowCountDown());
                }
            }
        }

    }
    #endregion

    #region Chase Player

    private void Update()
    {
        _myPosition = transform.position;
        
        if (isActive)
        {
            //CheckForPlayer();
            ChasePlayer();
        }
        if (_chasePlayer)
        {
            ChasePlayer();
        }
    }

    public void ChasePlayer()
    {
        _distanceToPlayer = Vector3.Distance(_player.transform.position, _myPosition);

        _aiUpdate += aiUpdateTick * Time.deltaTime;

        if (_aiUpdate > 1)
        {
            _target = target.position;
            _navMeshAgent.SetDestination(_target);
            _aiUpdate = 0;
        }
    }
    #endregion

    #region Co-routines

    IEnumerator FollowCountDown()
    {
        _lookingForPlayer = true;
        yield return new WaitForSeconds(followTime);

        _chasePlayer = false; 
        isActive = false;
        _lookingForPlayer = false;

        Debug.Log("Can't Find Them!");
    }
    #endregion
}
