using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    public static float leftSide = -6.0f;
    public static float rightSide = 6.0f;
    public float internalLeft;
    public float internalRight;

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}