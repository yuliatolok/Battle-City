using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class MazeGenerator : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] GameObject prefab;
    [SerializeField] int amount;
    float cellSize = 0.525f;
    bool[,] maze;
    int count = 0;

    private void Start()
    {
        maze = new bool[width, height];
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = false;
            }
        GenerateCells();
        GenerateWalls();
        WallEnable();

    }

    private void GenerateWalls()
    {
        for (int i = 0; i < height; i++)
        {
            maze[0, i] = true;
            maze[width - 1, i] = true;
        }
        for (int i = 0; i < width; i++)
        {
            maze[i, 0] = true;
            maze[i, height - 1] = true;
        }

    }

    private void GenerateCells()
    {
        for (int i = 0; count < amount; i++)
        {

            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            if (!maze[x, y])
            {
                maze[x, y] = true;
                
                count++;
            }

        }
    }
    void WallEnable()
    {
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                if (maze[x, y])
                {
                    GameObject cell = Instantiate(prefab, new Vector2(x * cellSize - 6.2f, y * cellSize - 4.5f), Quaternion.identity, transform);

                }
            }

    }




}
