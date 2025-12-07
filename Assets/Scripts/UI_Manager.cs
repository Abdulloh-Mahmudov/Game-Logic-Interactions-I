using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    private int _scoreNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = _scoreNumber.ToString();
    }

    public void AddScore()
    {
        _scoreNumber += 50;
    }
}
