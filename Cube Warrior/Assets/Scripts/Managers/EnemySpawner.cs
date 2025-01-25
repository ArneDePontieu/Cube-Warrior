using System;
using System.Numerics;
using Character;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public enum Direction
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
}

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Character.Character player;

    [SerializeField] private int waveSize;
    [SerializeField] private float waveDelay;

    private Vector2 cameraWorldSize;

    private float waveTimer;
    private int counter;
    
    private void Awake()
    {
        float aspectRatio = (float) Screen.width / Screen.height;
        float height = Camera.main.orthographicSize * 2f;
        cameraWorldSize = new Vector2(aspectRatio * height, height);
    }

    private void Update()
    {
        waveTimer += Time.deltaTime;

        if (waveTimer < waveDelay)
        {
            return;
        }

        waveTimer -= waveDelay;

        for (int i = 0; i < waveSize; i++)
        {
            counter++;
            Enemy enemy = Instantiate(enemyPrefab,
                player.transform.position + GetSpawnLocation(), Quaternion.identity);
            enemy.name = $"Enemy {counter}";
            
            enemy.player = player;
        }
    }


    private Vector3 GetSpawnLocation()
    {
        Vector3 spawnLocation = player.transform.position;

        Direction direction = (Direction) Random.Range(0, 3);

        switch (direction)
        {
            case Direction.Up:
                spawnLocation.x += (Random.Range(0, cameraWorldSize.x) - cameraWorldSize.x / 2);
                spawnLocation.y += cameraWorldSize.y / 2f;
                break;
            case Direction.Right:
                spawnLocation.y += (Random.Range(0, cameraWorldSize.y) - cameraWorldSize.y / 2);
                spawnLocation.x += cameraWorldSize.x / 2f;
                break;
            case Direction.Down:
                spawnLocation.x += (Random.Range(0, cameraWorldSize.x) - cameraWorldSize.x / 2);
                spawnLocation.y += -cameraWorldSize.y / 2f;
                break;
            case Direction.Left:
                spawnLocation.y += (Random.Range(0, cameraWorldSize.y) - cameraWorldSize.y / 2);
                spawnLocation.x += cameraWorldSize.x / 2f;
                break;
        }

        return spawnLocation;
    }
}