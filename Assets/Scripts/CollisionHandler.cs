using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + "--Collided with--" + other.gameObject.name);  //this is not necessary but makes code clear
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name}  **Triggered by** {other.gameObject.name}");  //klusia
    }

}
