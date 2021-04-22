using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public Animator coinAnimation;
    // Start is called before the first frame update
    void Start()
    {
        coinAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerManager>().GainMoney();
        Destroy(gameObject);
    }
}
