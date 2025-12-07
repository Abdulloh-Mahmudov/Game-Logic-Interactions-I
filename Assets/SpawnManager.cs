using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _enemy;
    private GameObject[] _enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummoningRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SummoningRoutine()
    {
        while (true)
        {
            Instantiate(_enemy, _startPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
