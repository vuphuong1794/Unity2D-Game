using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public float SpeedMoving;
    public SpriteRenderer EnemyRender;
    public GameObject Santa;
    public GameObject Bullet;
    public CounterScript CounterScript;
    public EnemySpawner EnemySpawner;
    public float timer, maxtimer;
    public Vector3 directionEnemy;
    // Start is called before the first frame update
    void Start()
    {
        Santa = GameObject.FindGameObjectWithTag("Player");
        timer = 0;
        maxtimer=3;
        SpeedMoving = 20;
        float defScale = 0.18f;
        transform.localScale = new Vector3(defScale,defScale,defScale);
        EnemyRender.flipX = true;
        CounterScript=GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
        EnemySpawner=GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        if (timer < maxtimer)
        {
            timer+=Time.deltaTime;
        }
        else
        {
            SpeedMoving = UnityEngine.Random.Range(10, 20);
            timer = 0;
        }
    }


    private void Moving()
    {         
        //directionEnemy = (Santa.transform.position - this.transform.position).normalized;
        //transform.position += directionEnemy*SpeedMoving*Time.deltaTime;

        //Phuong phap toi uu nhat
        transform.position=Vector2.MoveTowards(transform.position,Santa.transform.position,SpeedMoving*Time.deltaTime);
    }

    private void GetShot()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            EnemySpawner.EnemyCounter--;
            Destroy(gameObject);            
        }
    }

}
