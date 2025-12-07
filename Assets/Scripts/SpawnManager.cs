using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _enemy;
    private GameObject[] _enemies;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private float _spawnRate = 8f;
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
            GameObject enemy = Instantiate(_enemy, _startPoint.position, Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
