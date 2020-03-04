using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	public static bool canDoubleJump = false;
	public static bool canFreeSwim = true;
	public static bool canScaleBackground = false;
    public static bool canMove = true;
	public static int maxPlayerHealth = 3;
	public static int playerHealth = 3;
    public static float playerStrength = 1;

    // Curent Door
    public static int globalDoorID = 10000;
	public static float doorOffset;

	public static float masterVolume = 1;
	public static float musicVolume = 1;
	public static float soundVolume = 1;

}
