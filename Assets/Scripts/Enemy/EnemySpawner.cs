﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner attributes")]
    [SerializeField]
    private Direction directionToSpawn = Direction.RIGHT;
    [SerializeField]
    private bool enabledForSpecialMode = true;

    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    public void SetDirectionToSpawn(Direction newDir)
    {
        this.directionToSpawn = newDir;
    }

    public void Spawn(GameObject prefabToSpawn)
    {
        GameObject spawned = Instantiate(prefabToSpawn, transform.position, prefabToSpawn.transform.rotation);
        EnemyMovement enemySpawned = spawned.GetComponent<EnemyMovement>();

        enemySpawned.SetDirection(directionToSpawn);

        // Change speed according to level.
        int difficulty = gm.GetDifficulty();
        enemySpawned.SetSpeed(difficulty > 1 ? enemySpawned.GetSpeed() : enemySpawned.GetSpeed() + difficulty);
    }

    public void SetEnabledForSpecialMode(bool enable)
    {
        enabledForSpecialMode = enable;
    }
}