using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Boundaries 
{
    public float xMin, xMax, zMin, zMax;
    public Boundaries(float _xMin, float _xMax, float _zMin, float _zMax)
    {
        xMax = _xMax;
        xMin = _xMin;
        zMax = _zMax;
        zMin = _zMin;
    }
}
