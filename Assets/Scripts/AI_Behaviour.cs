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
    [SerializeField] private Animator _animator;
    [SerializeField] private AIStates _currentState;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] _checkpoints;
    [SerializeField] private int _currentCheckPoint = 0;
    private bool _startedHiding = false;
    private bool _isDead = false;
    [SerializeField] private float _speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        _checkpoints = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        _agent.destination = _checkpoints[_currentCheckPoint].transform.position;
        switch (_currentState)
        {
            case AIStates.Run:
                _agent.destination = _checkpoints[_currentCheckPoint].transform.position;
                _agent.speed = _speed;
                _animator.SetFloat("Speed", _agent.speed);
                _animator.SetBool("Hiding", false);
                break;
            case AIStates.Hide:
                _animator.SetBool("Hiding", true);
                if (_startedHiding == true)
                {
                    _startedHiding = false;
                    StartCoroutine(HideRoutine(Random.Range(3, 7)));
                }
                break;
            case AIStates.Death:
                _agent.speed = 0;
                _agent.isStopped = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                if (_isDead == false)
                {
                    _isDead = true;
                    _animator.SetTrigger("Death");
                    gameObject.GetComponent<Collider>().enabled = false;
                    Destroy(this.gameObject, 3f);
                }
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
        _startedHiding = true;
    }

    IEnumerator HideRoutine(float hideTime)
    {
        _agent.isStopped = true;
        _agent.speed = 0;
        transform.rotation = Quaternion.Euler(0f,-180f,0f);
        yield return new WaitForSeconds(hideTime);
        _agent.speed = _speed;
        _agent.isStopped = false;
        _currentState = AIStates.Run;
    }

    public void Death()
    {
        _currentState = AIStates.Death;
    }
}
