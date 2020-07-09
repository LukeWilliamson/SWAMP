using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    // Abilities
	public static bool canDoubleJump = false;
	public static bool canFreeSwim = true;
	public static bool canScaleBackground = false;
    public static bool canMove = true;
    public static bool hasSword = false;

    // Player Stats
    public static int maxPlayerHealth = 4;
	public static int playerHealth = 4;
    public static float playerStrength = 1;
    public static int playerMoney = 0;

    // Money Counter
    public static bool[] moneyCollected = new bool[100];

    // Boss Counter
    public static bool beatRatBoss = false;

    // Curent Door
    public static int globalDoorID = 10000;
	public static float doorOffset;
    
    // Current Workbench
    public static int globalWorkbenchID = 0;
    public static string currentWorkbenchScene = "Tutorial";

    // Audio Manager
    public static float masterVolume = 1;
	public static float musicVolume = 1;
	public static float soundVolume = 1;

    // Game States
    public static bool isPaused = false;
    public static bool respawning = false;
    public static int tutorialState = 0;
}
