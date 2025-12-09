using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Manager _UIManager;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private float _fireRate = 1f;
    private float _cooldown;
    [SerializeField] private AudioSource _audio;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > _cooldown)
        {
            _cooldown = Time.time + _fireRate;
            _audio.Play();
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,Mathf.Infinity, 1<<7 | 1<<6))
        {
            if (hit.transform.gameObject.layer == 7)
            {
                Debug.Log("Enemy Hit");
                _UIManager.AddScore();
                _spawnManager.EnemyDefeated();
                hit.transform.gameObject.GetComponent<AI_Behaviour>().Death();
            }
            else if(hit.transform.gameObject.layer == 6)
            {
                hit.transform.gameObject.GetComponent<Barriers>().Damage();
                hit.transform.gameObject.GetComponent<Barriers>().WallShot();
            }
        }
    }
}
