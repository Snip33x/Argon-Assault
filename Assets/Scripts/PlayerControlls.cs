using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// new INsys using UnityEngine.InputSystem;

public class PlayerControlls : MonoBehaviour
{
    //new INsys [SerializeField] InputAction movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // to jest potrzebne jak używamy nowego input systemu
    //private void OnEnable()
    //{
    //    movement.Enable();
    //}

    //private void OnDisable()
    //{
    //    movement.Disable();
    //}

    // Update is called once per frame
    void Update()
    {
        //new INsys float horizontalThrow = movement.ReadValue<Vector2>().x;
        //new INsys float verticalThrow = movement.ReadValue<Vector2>().y;


        float xThrow = Input.GetAxis("Horizontal");
        Debug.Log("horizontal " + xThrow);

        float yThrow = Input.GetAxis("Vertical");
        Debug.Log("vertical " + yThrow);
    }
}
