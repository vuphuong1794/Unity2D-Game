using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject Star;
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
        for (int i = 0; i < 20; i++) {
            Instantiate(Star, new Vector3(Random.Range(-50,50), Random.Range(-10, 25), DefPosZ), transform.rotation);
        }
        
        DefPosX = transform.position.x;
        DefPosZ = transform.position.z;
        counterScript = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
        for (int i = 0; i < 30; i++)
        {
            Instantiate(Star, new Vector3(Random.Range(-52,52), Random.Range(-28, 28), DefPosZ), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!counterScript.GameIsOver)
        {           
            SpawnerStar();
        }

    }
    void SpawnerStar()
    {
        if (Timer < TimeSpawner)
        {
            Timer += Time.deltaTime;
        }
        else
        {
           Instantiate(Star, new Vector3(DefPosX, Random.Range(2, 33), DefPosZ), transform.rotation);
           Timer = 0;
        }
    }
    
}
