using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AI")
        {
            float chance = Random.Range(0, 2);
            if (chance != 0)
            {
                other.GetComponent<AI_Behaviour>().Hide();
            }
        }
    }
}
