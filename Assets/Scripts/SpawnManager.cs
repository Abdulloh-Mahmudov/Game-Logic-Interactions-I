using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private float _spawnRate = 8f;
    [SerializeField] private UI_Manager _uiManager;
    [SerializeField] private int _totalEnemyNumber = 40;
    [SerializeField] private GameManager _gameManager;
    private int _enemiesRemaining;
    private int _enemiesDefeated;
    private int _enemiesLost;
    private int _enemiesSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SummoningRoutine());
        _gameManager.EnemyRatio(_enemiesDefeated, _enemiesLost, _enemiesRemaining, _enemiesSpawned, _totalEnemyNumber);
    }

    // Update is called once per frame
    void Update()
    {
        _enemiesRemaining = _enemyContainer.transform.childCount;
        _uiManager.EnemiesLeft(_enemiesRemaining);
        _uiManager.EnemiesDefeated(_enemiesDefeated);
        _uiManager.EnemiesLost(_enemiesLost);
        _uiManager.EnemyTotal(_totalEnemyNumber);
        _gameManager.EnemyRatio(_enemiesDefeated, _enemiesLost, _enemiesRemaining,_enemiesSpawned ,_totalEnemyNumber);
    }

    IEnumerator SummoningRoutine()
    {
        while (_enemiesSpawned < _totalEnemyNumber)
        {
            GameObject enemy = Instantiate(_enemy, _startPoint.position, Quaternion.identity);
            _enemiesSpawned++;
            enemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnRate);
        }
        
    }
    public void EnemyDefeated()
    {
        _enemiesDefeated++;
    }
    public void EnemyLost()
    {
        _enemiesLost++;
    }

    
}
