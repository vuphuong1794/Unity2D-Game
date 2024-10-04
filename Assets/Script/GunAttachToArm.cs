using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttachToArm : MonoBehaviour
{
    public GameObject RightHand;
    public GameObject[] Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        float defScale=0.25f;
        this.transform.localScale= new Vector3(defScale, defScale, defScale);
        this.transform.position=RightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = RightHand.transform.position;
    }
    public void Shooting()
    {
        Instantiate(Bullet[Random.Range(0, Bullet.Length)], gameObject.transform.position, gameObject.transform.rotation);
    }
}
