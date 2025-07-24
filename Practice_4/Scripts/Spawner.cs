using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(List<Cube> cubes)
    {
        foreach (var cube in cubes)
            Instantiate(cube);
    }
}