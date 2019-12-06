using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    //refernce to the fire particles
    public GameObject fireParticlesPrefab;

    //over ride is used to exspand on the attck in the tower class
    protected override void AttackEnemy()
    {
        //call the tower class attack enemy
        base.AttackEnemy();
        //spawn new fire particles
        GameObject particles = (GameObject)Instantiate(fireParticlesPrefab,transform.position + new Vector3(0, .5f),fireParticlesPrefab.transform.rotation);
        // Scale fire particle radius with the aggro radius aka change the range
        particles.transform.localScale *= aggroRadius / 10f;

        //damage all enemies in the attack radius 
        foreach (Enemy enemy in EnemyManager.Instance.GetEnemiesInRange(transform.position, aggroRadius))
        {
            enemy.TakeDamage(attackPower);
        }
    }
}
