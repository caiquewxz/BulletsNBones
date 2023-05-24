using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private int remainingEnemies;

    private void OnDestroy()
    {
        remainingEnemies++;
    }
}
