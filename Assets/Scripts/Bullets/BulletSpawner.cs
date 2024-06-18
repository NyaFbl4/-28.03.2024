using UnityEngine;

namespace ShootEmUp
{
    public class BulletSpawner : MonoBehaviour
    {
        public Bullet SpawnBullet(Bullet prefab, Transform transform)
        {
            var bullet = Instantiate(prefab, transform);
            return bullet;
        }
    }
}