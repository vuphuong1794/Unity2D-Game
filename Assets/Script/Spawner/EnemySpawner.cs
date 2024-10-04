using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject OrcArcher;
    public float timer, maxTime;
    public int EnemyCounter, MaxEnemyOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        maxTime=3;
        MaxEnemyOnScreen = 10;
        EnemyCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime && EnemyCounter<MaxEnemyOnScreen)
        {
            Instantiate(OrcArcher,new Vector3(transform.position.x,Random.Range(-30,30),transform.position.z),transform.rotation);
            timer = 0;
            EnemyCounter++;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
