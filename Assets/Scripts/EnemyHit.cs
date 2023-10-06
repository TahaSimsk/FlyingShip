using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
        Debug.Log("Hit");
    }
}
