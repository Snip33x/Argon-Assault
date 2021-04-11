using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = Input.GetAxis("Horizontal");
        Debug.Log("horizontal " + horizontalThrow);
        float verticalThrow = Input.GetAxis("Vertical");
        Debug.Log("vertical " +verticalThrow);
    }
}
