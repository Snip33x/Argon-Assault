using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 100;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // we have only one object of type score in hierarchy  bad to use in update()    
        
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); //quaternion.identity to jest poprostu aktualna rotacja bez zmian tak jak pozycja
        vfx.transform.parent = parent;
        Invoke("DestroyVFX", 1f);
        Destroy(this.gameObject);
    }
}

