using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // we have only one object of type score in hierarchy  bad to use in update()    
        AddRigidbody();
        parentGameObject = GameObject.FindWithTag("Spawn");  //wcześniej mieliśmy serializedField z parentGameObject do którego z poziomu Unity wrzucaliśmy obiekt SpawnAtRuntime, i dzięki temu tam wpadały klony, teraz znajdujemy poprostu to po tagu
        
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)  // mniejsze niż 1 jest lepsze niż == 0 bo jest odporniejsze na błędy
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity); //quaternion.identity to jest poprostu aktualna rotacja bez zmian tak jak pozycja
        vfx.transform.parent = parentGameObject.transform;  
        hitPoints--;
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); //quaternion.identity to jest poprostu aktualna rotacja bez zmian tak jak pozycja
        vfx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(scorePerHit);
        Destroy(this.gameObject);
    }
}

