using UnityEngine;

static class UserUtils
{
    static public Vector3 GetSpawnPosition(float radius)
    {
        Vector3 spawnPosition;

        float angle = Random.Range(0f, Mathf.PI * 2f);

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        spawnPosition = new Vector3(x, 0, z);

        return spawnPosition;
    }

    static public Vector3 GetSpawnPosition(float minRadius, float maxRadius)
    {
        Vector3 spawnPosition;

        float radius = Random.Range(minRadius, maxRadius);
        float angle = Random.Range(0f, Mathf.PI * 2f);

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        spawnPosition = new Vector3(x, 0, z);

        return spawnPosition;
    }

    static public bool IsReachedTarget(Vector3 targetPosition, Vector3 currentPosition, float distance)
    {
        Vector2 offset = new Vector2(targetPosition.x - currentPosition.x, targetPosition.z - currentPosition.z);

        return offset.sqrMagnitude <= distance * distance;
    }
}
