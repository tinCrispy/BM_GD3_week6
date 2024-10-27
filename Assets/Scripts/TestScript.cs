using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(30, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnMouseDown()
    {

        Quaternion.Euler(transform.rotation.x, 60, transform.rotation.z);
    }
}
