using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float xValue = Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
       transform.Translate(xValue, 0f, -5f * Time.deltaTime);
    }
}
