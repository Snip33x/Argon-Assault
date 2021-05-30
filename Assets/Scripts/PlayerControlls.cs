using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// new INsys using UnityEngine.InputSystem;

public class PlayerControlls : MonoBehaviour
{
    [Header("General Setup Setting")]
    [Tooltip("How fast ship moves up and down based upon player input")] 
    [SerializeField] float controlSpeed = 2f;
    [Tooltip("Horizontal Range where the ship will be flying")] 
    [SerializeField] float xRange = 15f;
    [Tooltip("Vertical Range where the ship will be flying")] 
    [SerializeField] float yRange = 10f;
    
    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers;
    
    [Header("Screen posistion based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;
    
    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
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
        ProcessFiring();

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

    

    void ProcessFiring()
    {
        /*
         * taki input stosowaliśmy w Rakietowniku 
         * if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Shooting");
        }*/

        if(Input.GetButton("Fire1"))
        {
            SetLasersAvtive(true);
        }
        else
        {
            SetLasersAvtive(false);
        }
    }

    private void SetLasersAvtive(bool isActive)
    {
        // for each of the lasers that we have, turn them on (activate them)
        foreach (GameObject laser in lasers)
        {
            //laser.SetActive(true);  //property active is just saying if this gameobject is active or not, setactive changes status
            //var emission = ParticleSystem.emission;
            //laser.GetComponent<ParticleSystem>().emission.enabled = false;
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }


}
