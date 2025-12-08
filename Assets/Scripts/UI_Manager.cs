using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] Text _enemyText;
    [SerializeField] Text _enemyLostText;
    [SerializeField] Text _enemyDefeatedText;
    private int _scoreNumber = 0;
    private int _enemyLeft = 0;
    private int _enemyDefeated = 0;
    private int _enemyLost = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = _scoreNumber.ToString();
        _enemyText.text = _enemyLeft.ToString();
        _enemyDefeatedText.text = _enemyDefeated.ToString() + "/" + 40;
        _enemyLostText.text = _enemyLost.ToString() + "/" + 40;
    }

    public void AddScore()
    {
        _scoreNumber += 50;
    }

    public void EnemiesLeft( int enemies)
    {
        _enemyLeft = enemies;
    }

    public void EnemiesLost(int enemies)
    {
        _enemyLost = enemies;
    }

    public void EnemiesDefeated(int enemies)
    {
        _enemyDefeated = enemies;
    }
}
