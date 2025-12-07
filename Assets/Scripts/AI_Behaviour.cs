using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behaviour : MonoBehaviour
{
    private enum AIStates
    {
        Run,
        Hide,
        Death
    }
    [SerializeField] private AIStates _currentState;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _checkpoints;
    [SerializeField] private int _currentCheckPoint = 0;
    private bool _isHiding = false;

    // Start is called before the first frame update
    void Start()
    {
        _checkpoints = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _checkpoints[_currentCheckPoint].transform.position;
        switch (_currentState)
        {
            case AIStates.Run:
                _agent.destination = _checkpoints[_currentCheckPoint].transform.position;
                break;
            case AIStates.Hide:
                if (_isHiding == true)
                {
                    _isHiding = false;
                    StartCoroutine(HideRoutine(Random.Range(3, 7)));
                }
                break;
            case AIStates.Death:
                _agent.isStopped = true;
                gameObject.GetComponent<Collider>().enabled = false;
                Destroy(this.gameObject, 3f);
                break;
        }
    }

    public void NextCheckPoint()
    {
        _currentCheckPoint++;
    }

    public void Hide()
    {
        _currentState = AIStates.Hide;
        _isHiding = true;
    }

    IEnumerator HideRoutine(float hideTime)
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(hideTime);
        _agent.isStopped = false;
        _currentState = AIStates.Run;
    }

    public void Death()
    {
        _currentState = AIStates.Death;
    }
}
