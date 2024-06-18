using UnityEngine;

namespace ShootEmUp
{
    public class BulletSpawner : MonoBehaviour
    {
        public Bullet SpawnBullet(Bullet prefab, Transform transform)
        {
            Instantiate(prefab, transform);
            return prefab;
        }
        
        public GameObject CreateBullet()
        {
            return Instantiate(this.prefab, this.container);
        }
    }
}