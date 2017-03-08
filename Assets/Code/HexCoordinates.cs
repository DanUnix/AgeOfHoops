using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    [SerializeField]
    private int x, z;

    public int X {

        //get; private set;
        get
        {
            return x;
        }

    }

    public int Y {
        get {
            return -X - Z;
        }
    }

    public int Z {

        //get; private set;
        get
        {
            return z;
        }
    }

    public HexCoordinates(int x, int z)
    {
        // X = x;
        // Z = z;
        this.x = x;
        this.z = z;
    }

    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z / 2, z);
    }

    public override string ToString()
    {
        return "(" +
            X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }
}