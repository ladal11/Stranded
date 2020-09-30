using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    int treeHealth = 10;

    public void Damage(int damage)
    {
        treeHealth -= damage;
        if (treeHealth <= 0)
        {
            Destroy(gameObject, 0.5f);
            SpawnLoot();
        }
    }

    private void SpawnLoot()
    {

    }


}

