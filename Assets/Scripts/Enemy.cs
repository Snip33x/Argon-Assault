using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // we have only one object of type score in hierarchy  bad to use in update()    
        
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
        vfx.transform.parent = parent;
        //Invoke("hitVFX", 1f);
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints--;
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); //quaternion.identity to jest poprostu aktualna rotacja bez zmian tak jak pozycja
        vfx.transform.parent = parent;
        //Invoke("DestroyVFX", 1f);
        Destroy(this.gameObject);
    }
}

