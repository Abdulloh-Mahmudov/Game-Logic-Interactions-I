using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private bool _isFinalPoint = false;
    [SerializeField] private SpawnManager _spawnManager;
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AI")
        {
            if(_isFinalPoint == false)
            {
                other.GetComponent<AI_Behaviour>().NextCheckPoint();
            }
            else
            {
                _audio.Play();
                Destroy(other.gameObject);
                _spawnManager.EnemyLost();
            }
        }
    }
}
