using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerialColor{
    public float r;
    public float g;
    public float b;
    public float a;

    public SerialColor(float iR, float iG, float iB, float iA)
    {
        r = iR;
        g = iG;
        b = iB;
        a = iA;
    }

    public SerialColor()
    {
        r = 255f;
        g = 255f;
        b = 255f;
        a = 255f;
    }

    public static SerialColor ColorToSColor(Color uColor)
    {
        return new SerialColor(uColor.r, uColor.g, uColor.b, uColor.a);
    }

    public Color ToUColor()
    {
        return new Color(this.r, this.g, this.b, this.a);
    }
}

