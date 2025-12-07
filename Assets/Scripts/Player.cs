using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Manager _UIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform.tag == "AI")
            {
                Debug.Log("Enemy Hit");
                _UIManager.AddScore();
                hit.transform.gameObject.GetComponent<AI_Behaviour>().Death();
            }
        }
    }
}
