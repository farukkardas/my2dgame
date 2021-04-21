using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryMe : MonoBehaviour
{
    public int lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
