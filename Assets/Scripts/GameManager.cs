using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _enemiesDefeated;
    private int _enemiesLost;
    private int _enemiesRemaining;
    private int _enemiesSpawned;
    private int _enemiesTotal;
    private bool _gameEnded = false;
    [SerializeField] UI_Manager _uiManager;
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (_enemiesRemaining <= 0 && _enemiesSpawned >= _enemiesTotal)
        {
            _gameEnded = true;
            _player.GetComponent<Player>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Restart();
            if (_enemiesDefeated > _enemiesLost)
            {
                _uiManager.GameEnd(true);
            }
            else
            {
                _uiManager.GameEnd(false);
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) && _gameEnded == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void EnemyRatio(int defeated, int lost, int remaining,int spawned ,int enemyTotal)
    {
        _enemiesDefeated = defeated;
        _enemiesLost = lost;
        _enemiesRemaining = remaining;
        _enemiesSpawned = spawned;
        _enemiesTotal = enemyTotal;
    }

    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
