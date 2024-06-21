using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBounds
    {
        //[SerializeField]
        private Transform _leftBorder;

        //[SerializeField]
        private Transform _rightBorder;

        //[SerializeField]
        private Transform _downBorder;

        //[SerializeField]
        private Transform _topBorder;

        public LevelBounds(Transform leftBorder, Transform rightBorder,
                           Transform downBorder, Transform topBorder)
        {
            _leftBorder = leftBorder;
            _rightBorder = rightBorder;
            _downBorder = downBorder;
            _topBorder = topBorder;
        }
        
        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > this._leftBorder.position.x
                   && positionX < this._rightBorder.position.x
                   && positionY > this._downBorder.position.y
                   && positionY < this._topBorder.position.y;
        }
    }
}