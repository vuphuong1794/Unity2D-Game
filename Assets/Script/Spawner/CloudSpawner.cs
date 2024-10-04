using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] Cloud;
    public float TimeSpawner;
    public float Timer;
    public float DefPosX, DefPosZ;
    public CounterScript counterScript;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localRotation= Quaternion.identity;
        Timer = 0; TimeSpawner=1;
        transform.position = new Vector3(70, 11, -1f);
        for (int i = 0; i < Cloud.Length; i++) {
            Instantiate(Cloud[Random.Range(0, Cloud.Length)], new Vector3(Random.Range(-50,50), Random.Range(-25, 25), DefPosZ), transform.rotation);
        }
        
        DefPosX = transform.position.x;
        DefPosZ = transform.position.z;
        counterScript = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
        SpawnerCloud();
    }

    // Update is called once per frame
    void Update()
    {
        if (!counterScript.GameIsOver)
        {
            SpawnerCloud();
        }

    }
    void SpawnerCloud()
    {
        if (Timer < TimeSpawner)
        {
            Timer += Time.deltaTime;
        }
        else
        {
           Instantiate(Cloud[Random.Range(0,Cloud.Length)], new Vector3(DefPosX, Random.Range(-10, 33), DefPosZ), transform.rotation);
           Timer = 0;
        }
    }
    
}
