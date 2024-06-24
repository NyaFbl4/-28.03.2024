using UnityEngine;

public class EnemyTransformContainer : MonoBehaviour
{
    [Header("Трасформы спавна для Enemy")]
    [SerializeField] public Transform container;
    [SerializeField] public Transform worldTransform;
        
    [Header("Трансформы позиций для Enemy")]
    [SerializeField] public Transform[] spawn;
    [SerializeField] public Transform[] attack;
}