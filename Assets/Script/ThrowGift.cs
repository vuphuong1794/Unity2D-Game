using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGift : MonoBehaviour
{
    public GameObject[] Gift;
    public void ThrowingGift()
    {
        Instantiate(Gift[Random.Range(0,Gift.Length)], gameObject.transform.position, gameObject.transform.rotation);
    }
}
