using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _checkpoints;
    [SerializeField] private int _currentCheckPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        _checkpoints = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _checkpoints[_currentCheckPoint].transform.position;
    }

    public void NextCheckPoint()
    {
        _currentCheckPoint++;
    }
}
