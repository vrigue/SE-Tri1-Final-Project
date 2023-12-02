using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collectible")]
public class Collectible : ScriptableObject
{
    public int pointValue;

    public int getPointValue() 
    {
        return pointValue;
    }
}