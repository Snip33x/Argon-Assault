using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
        Debug.Log($"{name}I'm hit! by {other.gameObject.name}");
    }
}
