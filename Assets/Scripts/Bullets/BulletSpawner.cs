using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class BulletSpawner : PlaceholderFactory<Bullet>
    {
        /*
        public Bullet SpawnBullet(Bullet prefab, Transform transform)
        {
            var bullet = Instantiate(prefab, transform);
            return bullet;
        }
        */
    }
}