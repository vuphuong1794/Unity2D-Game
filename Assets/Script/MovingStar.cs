using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStar : MonoBehaviour
{
    public SpriteRenderer star;
    public float movingSpeed;
    public float maxMovingSpeed;
    public float DeadZone = -90f;
    public CounterScript counterScript;
    public float timerIncreaseSpeed;
    public float MaxTimerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float defScale = Random.Range(0.02f, 0.1f);
        star.sortingOrder = 0;
        movingSpeed = 5+defScale*10;
        maxMovingSpeed = 80;
        timerIncreaseSpeed = 0;
        MaxTimerSpeed = 1;
        gameObject.transform.localScale = new Vector3(defScale, defScale, defScale);
        counterScript=GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!counterScript.GameIsOver)
        {
            moving(movingSpeed);
            if (timerIncreaseSpeed < MaxTimerSpeed)
            {
                timerIncreaseSpeed += Time.deltaTime;
            }
            else
            {
                movingSpeed += 0.1f;
                timerIncreaseSpeed = 0;
            }                     
        }
        DeleteColl();

    }
    void moving(float movingSpeed)
    {
        transform.position += Vector3.left * movingSpeed * Time.deltaTime;
    }

    void DeleteColl()
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
