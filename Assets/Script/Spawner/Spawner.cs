using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Collumn;
    public float TimeSpawner;
    public float Timer;
    public float DefPosX, DefPosZ;
    public CounterScript counterScript;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0; TimeSpawner=5;
        transform.position = new Vector3(70, 11, -1f);
        DefPosX = transform.position.x;
        DefPosZ = transform.position.z;
        counterScript = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
        SpawnerCollumn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!counterScript.GameIsOver)
        {
            SpawnerCollumn();
        }

    }
    void SpawnerCollumn()
    {
        if (Timer < TimeSpawner)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Instantiate(Collumn, new Vector3(DefPosX, Random.Range(-7f, 32f),DefPosZ),transform.rotation);
            Timer = 0;
        }
    }
    
}
