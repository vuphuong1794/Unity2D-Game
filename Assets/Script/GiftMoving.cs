using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMoving : MonoBehaviour
{
    public Rigidbody2D giftBody;

    public float speedGift=50f;
    public CounterScript counterScript;
    public SpriteRenderer GiftRenderer;
    // Start is called before the first frame update
    void Start()
    {
        float defScale = 0.3f;
        this.transform.localScale = new Vector3(defScale, defScale, defScale);
        giftBody.gravityScale = 4;

        GiftRenderer =GetComponent<SpriteRenderer>();
        GiftRenderer = gameObject.GetComponent<SpriteRenderer>();
        GiftRenderer.color = new Color(Random.Range(0.5f,1), Random.Range(0.5f, 1), Random.Range(0.5f, 1));

        counterScript = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<CounterScript>();
        ShootGift();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -55)
        {
            Destroy(gameObject);
        }
    }

    void ShootGift()
    {
        //Lay vi tri cua chuot trong the gioi 2d
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Tinh toan huong tu vi tri hien tai den vi tri chuot
        Vector2 mouseDirection = (mouseWorldPosition - (Vector2)transform.position).normalized;
        //Dat van toc cho RigidBody2D de di chuyen doi tuong theo huong chuot voi toc do da dinh
        giftBody.velocity= mouseDirection * speedGift;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="HeadChimney")
        {
            Debug.Log("Touching");
            counterScript.addScore(2);
            Destroy(gameObject);
        }
    }
}
