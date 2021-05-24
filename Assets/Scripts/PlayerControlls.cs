using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// new INsys using UnityEngine.InputSystem;

public class PlayerControlls : MonoBehaviour
{

    [SerializeField] float controlSpeed = 2f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 10f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow , yThrow;

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


        ProcessTranslation();
        ProcessRotation();

    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        

        float pitch =  pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = xThrow * controlRollFactor ;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // robienie zakresów w jakich będzie się poruszać statek 

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange + 7, yRange);  // statek zjeżdzał poniżej dolnej krawędzi ekranu , Rick przestawił kamerę do dołu - ja dodałem tu trójeczkę - oba sposoby działają

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
