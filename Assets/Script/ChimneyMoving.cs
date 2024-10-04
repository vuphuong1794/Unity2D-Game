using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyMoving : MonoBehaviour
{
    public float movingSpeed;
    public float maxMovingSpeed;
    public float DeadZone;
    public CounterScript counterScript;
    public float timerIncreaseSpeed;
    public float MaxTimerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float ObjectScale=1.7f;
        DeadZone = -90f;
        gameObject.transform.localScale = new Vector3(ObjectScale, ObjectScale, ObjectScale);

        movingSpeed = 40;
        maxMovingSpeed = 50;
        timerIncreaseSpeed = 0;
        MaxTimerSpeed = 1;
        counterScript = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
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
        DeleteChimney();
    }

    void moving(float movingSpeed)
    {
        transform.position += Vector3.left * movingSpeed * Time.deltaTime;
    }

    void DeleteChimney()
    {

        if (transform.position.x < DeadZone)
        {
            Destroy(gameObject);
        }
    }
}
