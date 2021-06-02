using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;


    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx =  Instantiate(deathVFX, transform.position, Quaternion.identity); //quaternion.identity to jest poprostu aktualna rotacja bez zmian tak jak pozycja
        vfx.transform.parent = parent;
        Invoke("DestroyVFX", 1f);
        Destroy(this.gameObject);
    }
}

