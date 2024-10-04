using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public CounterScript counterScript;
    // Start is called before the first frame update
    //phuong 
    void Start()
    {
        counterScript = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent <CounterScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            counterScript.GameOver();
        }
    }
}
