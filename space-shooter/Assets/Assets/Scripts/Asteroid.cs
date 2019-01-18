using System;
using System.Collections.Generic;
using UnityEngine;

public enum AsteroidSizeClass
{
    Small = 1,
    Medium = 2,
    Large = 3
}

public class Asteroid : MonoBehaviour
{

    public AsteroidSizeClass Size = AsteroidSizeClass.Large;
    public float ScaleFactor = 0.3f;
    private static readonly Dictionary<AsteroidSizeClass, float> _SpeedCoef = new Dictionary<AsteroidSizeClass, float>()
    {
        { AsteroidSizeClass.Large, 0.5f },
        { AsteroidSizeClass.Medium, 1f},
        { AsteroidSizeClass.Small, 1.5f}
    };

    public float SpeedCoef
    {
        get
        {
            return _SpeedCoef[Size];
        }
    }

    /// <summary>
    /// Sets the size of this asteroid based on the size of its parent.
    /// </summary>
    /// <param name="i_oParentAsteroid">The parent asteroid that spawned this asteroid.</param>
    public void SetSizeFromParent(Asteroid i_oParentAsteroid)
    {
        if (i_oParentAsteroid.Size == AsteroidSizeClass.Small)
        {
            throw new ArgumentOutOfRangeException(nameof(i_oParentAsteroid), i_oParentAsteroid, "Cannot set the size of a new asteroid from a small parent asteroid.");
        }
        this.Size = i_oParentAsteroid.Size - 1;
        this.gameObject.transform.localScale -= Vector3.one * ScaleFactor;
    }
}
