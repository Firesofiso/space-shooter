using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum AsteroidSizeClass
{
    Small = 1,
    Medium = 2,
    Large = 3
}

public class Asteroid : MonoBehaviour {

    public AsteroidSizeClass Size = AsteroidSizeClass.Large;

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
    }
}
