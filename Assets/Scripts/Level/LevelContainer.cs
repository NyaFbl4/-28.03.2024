using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    [Header("Границы уровня")]
    public Transform leftBorder;
    public Transform rightBorder;
    public Transform downBorder;
    public Transform topBorder;
    
    public GameObject background;
}
