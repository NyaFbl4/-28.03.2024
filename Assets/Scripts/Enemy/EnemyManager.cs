using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyManager :  ITickable
    {
        private EnemyPool _enemyPool;
        private BulletSystem _bulletSystem;
        
        private readonly HashSet<GameObject> m_activeEnemies = new();
        private float _timer = 0;
        
        public EnemyManager(EnemyPool enemyPool, BulletSystem bulletSystem)
        {
            this._enemyPool = enemyPool;
            this._bulletSystem = bulletSystem;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_enemyPool.enemyPool.Count != 0)
            {
                if (_timer >= 1)
                {
                    var enemy = this._enemyPool.SpawnEnemy();
                    if (enemy != null)
                    {
                        if (this.m_activeEnemies.Add(enemy))
                        {
                            enemy.GetComponent<HitPointsComponent>().hpEmpty += this.OnDestroyed;
                            enemy.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
                        }    
                    }

                    _timer = 0;
                }
            }
        }


        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= this.OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;

                _enemyPool.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int) PhysicsLayer.ENEMY,
                color = Color.red,
                damage = 1,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}