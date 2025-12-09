using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    private float _durability = 5;
    [SerializeField] private bool _isTrigger;
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AI" && _isTrigger == true)
        {
            float chance = Random.Range(0, 2);
            if (chance != 0)
            {
                other.GetComponent<AI_Behaviour>().Hide();
            }
        }
    }
    public void Damage()
    {
        if (_isTrigger == false)
        {
            _durability--;
            if (_durability <= 0)
            {
                StartCoroutine(DestroyedRoutine());
            }
        }
    }

    IEnumerator DestroyedRoutine()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(10f);
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        transform.GetChild(0).GetComponent<Collider>().enabled = true;
        _durability = 5;
    }

    public void WallShot()
    {
        _audio.Play();
    }
}
