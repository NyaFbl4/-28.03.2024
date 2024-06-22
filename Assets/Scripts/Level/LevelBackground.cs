using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBackground : IInitializable, IFixedTickable
    {
        private float startPositionY;

        private float endPositionY;

        private float movingSpeedY;

        private float positionX;

        private float positionZ;

        private Transform _myTransform;

        private GameObject _tr;

        private Params _params;

        public LevelBackground(GameObject transform, Params parametrs)
        {
            _tr = transform;
            _params = parametrs;
        }

        public void Initialize()
        {
            this.startPositionY = this._params.m_startPositionY;
            this.endPositionY = this._params.m_endPositionY;
            this.movingSpeedY = this._params.m_movingSpeedY;
            this._myTransform = _tr.transform;
            var position = this._myTransform.position;
            this.positionX = position.x;
            this.positionZ = position.z;
        }

        public void FixedTick()
        {
            if (this._myTransform.position.y <= this.endPositionY)
            {
                this._myTransform.position = new Vector3(
                    this.positionX,
                    this.startPositionY,
                    this.positionZ
                );
            }

            this._myTransform.position -= new Vector3(
                this.positionX,
                this.movingSpeedY * Time.fixedDeltaTime,
                this.positionZ
            );
        }
    }
    
    
    [Serializable]
    public sealed class Params
    {
        [SerializeField]
        public float m_startPositionY;

        [SerializeField]
        public float m_endPositionY;

        [SerializeField]
        public float m_movingSpeedY;
    }
}