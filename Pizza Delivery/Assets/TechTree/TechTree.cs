using System;

public class TechTree
{
	private int[] treePoints;
	private const int NUM_BRANCHES = 6;
	private const int WINGS_INDEX = 0;
	private const int SPEED_INDEX = 1;
	private const int SUPER_STR_INDEX = 2;
	private const int LASERS_INDEX = 3;
	private const int XRAY_VISION_INDEX = 4;
	private const int GUNS_INDEX = 5;

	public TechTree()
	{
		treePoints = new int[NUM_BRANCHES];
		for (int i = 0; i < NUM_BRANCHES; i++)
		{
			treePoints[i] = 0;
		}
	}

	private double CalculateCost(double x)
	{
		// e^(.5x) + y, where y is optional offset
		return Math.Exp(0.5 * x);
	}

	private int CalculateCost(int x)
	{
		double d_x = (double)x;
		return (int)(Math.Ceiling(Math.Exp(0.5 * d_x)));
	}

    public int WingPoints
    {
        get
        {
            return GetTreePoints(WINGS_INDEX);
        }
        set
        {
            SetTreePoints(WINGS_INDEX, value);
        }
    }

    public int SpeedPoints
    {
        get
        {
            return GetTreePoints(SPEED_INDEX);
        }
        set
        {
            SetTreePoints(WINGS_INDEX, value);
        }
    }

    public int SuperStrengthPoints
    {
        get
        {
            return GetTreePoints(SUPER_STR_INDEX);
        }
        set
        {
            SetTreePoints(SUPER_STR_INDEX, value);
        }
    }

    public int LaserPoints
    {
        get
        {
            return GetTreePoints(LASERS_INDEX);
        }
        set
        {
            SetTreePoints(LASERS_INDEX, value);
        }
    }
    
    public int XrayPoints
    {
        get
        {
            return GetTreePoints(XRAY_VISION_INDEX);
        }
        set
        {
            SetTreePoints(XRAY_VISION_INDEX, value);
        }
    }

    public int GunsPoints
    {
        get
        {
            return GetTreePoints(GUNS_INDEX);
        }
        set
        {
            SetTreePoints(GUNS_INDEX, value);
        }
    }

    private int GetTreePoints(int index)
	{
		return treePoints[index];
	}

    private void SetTreePoints(int index, int value)
    {
        treePoints[index] = value;
    }
}