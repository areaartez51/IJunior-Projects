using UnityEngine;

public class BulletSpawner : SpawnerBase<Bullet>
{
    public Bullet SpawnBullet(Vector3 position)
    {
        Bullet bullet = CreateNewPoolObject();

        bullet.transform.position = position;
        return bullet;
    }

    public void ResetSpawner()
    {
        ResetState();
    }

    protected override Bullet CreateNewPoolObject()
    {
        Bullet bullet = PoolObject.GetObject();
        bullet.Destroyer += OnPoolObjectRequestedReturn;
        return bullet;
    }

    protected override void OnPoolObjectRequestedReturn(IPoolableObject bullet)
    {
        bullet.Destroyer -= OnPoolObjectRequestedReturn;
        PoolObject.ReturnPoolObject((Bullet)bullet);
    }
}