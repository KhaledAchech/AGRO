using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnXandZ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(8f,0f,8f) * Time.deltaTime);
    }
}
