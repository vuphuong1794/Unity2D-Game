using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    public SpriteRenderer bodyCloud;
    public float movingSpeed;
    public float maxMovingSpeed;
    public float DeadZone;
    public CounterScript counterScript;
    public float timerIncreaseSpeed;
    public float MaxTimerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float randScale = UnityEngine.Random.Range(1, 4);
        this.transform.localScale = new Vector3(randScale, randScale, randScale);  
        bodyCloud.sortingOrder = randScale < 2 ? 1 : 15;
        bodyCloud.flipX = UnityEngine.Random.Range(0, 2) == 1 ? true : false;
        
        movingSpeed = 5*bodyCloud.sortingOrder + UnityEngine.Random.Range(5,10);
        maxMovingSpeed = 80;
        timerIncreaseSpeed = 0;
        MaxTimerSpeed = 1;
        
        counterScript=GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
        
        DeadZone = -120f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!counterScript.GameIsOver)
        {
            moving(movingSpeed);                   
        }
        DeleteCloud();

    }
    void moving(float movingSpeed)
    {
        transform.position += Vector3.left * movingSpeed * Time.deltaTime;
    }

    void DeleteCloud()
    {

        if (transform.position.x < DeadZone)
        {
            Destroy(gameObject);
        }
    }

    public void Stopping()
    {
        movingSpeed = 0;
    }



}
