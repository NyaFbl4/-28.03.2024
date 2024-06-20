using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletSystem : IFixedTickable
    {
        //[SerializeField]
        private int initialCount;
        
        //[SerializeField] 
        private  Transform container;
        //[SerializeField] 
        private  Bullet prefab;
        //[SerializeField] 
        private  Transform worldTransform;
        //[SerializeField] 
        private  LevelBounds levelBounds;
        private  BulletSpawner _bulletSpawner;
        //private readonly DiContainer _diContainer;

        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();

        
        //[Inject]
        public BulletSystem(Transform container, Transform worldTransform, int initialCount,
            /*Bullet bulletPrefab,*/ LevelBounds levelBounds, BulletSpawner bulletSpawner)
        {
            this.container = container;
            //this.prefab = bulletPrefab;
            this.worldTransform = worldTransform;
            this.levelBounds = levelBounds;
            this._bulletSpawner = bulletSpawner;
            this.initialCount = initialCount;

            for (var i = 0; i < this.initialCount; i++)
            {
                //var bullet = Instantiate(this.prefab, this.container);
                //var bullet = _diContainer.InstantiatePrefab(prefab, container);
                var bullet = _bulletSpawner.Create();
                
                this.m_bulletPool.Enqueue(bullet);
            }
            
            Debug.Log("injected BulletSystem");
        }

        /*
        private void Awake()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = Instantiate(this.prefab, this.container);
                //var bullet = _diContainer.InstantiatePrefab(prefab, container);
                //var bullet = _bulletSpawner.SpawnBullet(prefab, container);
                
                this.m_bulletPool.Enqueue(bullet);
            }
        }
        */
        
        public void FixedTick()
        {
            this.m_cache.Clear();
            this.m_cache.AddRange(this.m_activeBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++)
            {
                var bullet = this.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    this.RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            if (this.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                //bullet = Instantiate(this.prefab, this.worldTransform);
                bullet = _bulletSpawner.Create();
            }

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
            
            if (this.m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            this.RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (this.m_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= this.OnBulletCollision;
                bullet.transform.SetParent(this.container);
                this.m_bulletPool.Enqueue(bullet);
            }
        }
        
        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}