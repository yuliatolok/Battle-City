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
WallEnable();

    }


    private void GenerateCells()
    { 
        for (int i = 0; count < amount; i++)
        {

            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            Debug.Log(x +' ' + y);
            if (!maze[x, y])
            {
                maze[x, y] = true;
                Debug.Log(maze[x, y]);
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
