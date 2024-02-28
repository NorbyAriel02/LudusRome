using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestCosas : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawns;
    public float delay;
    public float timer;
    void Start()
    {
        delay = timer;
    }
    private void Update()
    {
        if(delay < 0) 
        {
            GameObject go = Instantiate(prefab, spawns[Random.Range(0, spawns.Length)]);
            go.name = StringHelper.GetName();
            delay = timer;
        }

        delay-= Time.deltaTime;
    }


}
