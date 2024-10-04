using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloud : MonoBehaviour
{
    public CounterScript counterScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void UpdateState()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = Random.Range(2,5);
    }
}
