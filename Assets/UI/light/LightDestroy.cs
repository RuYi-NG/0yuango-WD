using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDestroy : MonoBehaviour
{
    public GameObject twinkle;


    // Start is called before the first frame update
    void Start()
    {
        float time = 0.6f;
        Destroy(twinkle, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
