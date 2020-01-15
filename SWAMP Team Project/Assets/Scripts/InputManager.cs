using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
	public static KeyCode left = KeyCode.A;
	public static KeyCode right = KeyCode.D;
	public static KeyCode up = KeyCode.W;
	public static KeyCode down = KeyCode.S;
	public static KeyCode jump = KeyCode.Space;
	public static KeyCode attack = KeyCode.E;
	public static KeyCode dash = KeyCode.LeftShift;
	public static KeyCode crouch = KeyCode.LeftControl;

	// ------ Horizontal Inputs ------ //
	public static float PressHorizontal ()
	{
		if(Input.GetKeyDown(left))
		{
			return -1;
		}

		else if(Input.GetKeyDown(right))
		{
			return 1;
		}

		else if(Input.GetKeyDown(left) && Input.GetKeyDown(right))
		{
			return 0;
		}

		return 0;
	}

	public static float HoldHorizontal ()
	{
		if(Input.GetKey(left))
		{
			return -1;
		}

		else if(Input.GetKey(right))
		{
			return 1;
		}

		else if(Input.GetKey(left) && Input.GetKey(right))
		{
			return 0;
		}

		return 0;
	}

	// ------- Vertical Inputs ------- //
	public static float PressVertical ()
	{
		if(Input.GetKeyDown(up))
		{
			return 1;
		}

		else if(Input.GetKeyDown(down))
		{
			return -1;
		}

		else if(Input.GetKeyDown(up) && Input.GetKeyDown(down))
		{
			return 0;
		}

		return 0;
	}

	public static float HoldVertical ()
	{
		if(Input.GetKey(up))
		{
			return 1;
		}

		else if(Input.GetKey(down))
		{
			return -1;
		}

		else if(Input.GetKey(up) && Input.GetKey(down))
		{
			return 0;
		}

		return 0;
	}

	// --------- Jump Input --------- //
	public static bool PressJump ()
	{
		if(Input.GetKeyDown(jump))
		{
			return true;
		}

		return false;
	}

	public static bool HoldJump ()
	{
		if(Input.GetKey(jump))
		{
			return true;
		}

		return false;
	}

	public static bool ReleaseJump ()
	{
		if(Input.GetKeyUp(jump))
		{
			return true;
		}

		return false;
	}

	// -------- Attack Input -------- //
	public static bool PressAttack ()
	{
		if(Input.GetKeyDown(attack))
		{
			return true;
		}

		return false;
	}

	public static bool HoldAttack ()
	{
		if(Input.GetKey(attack))
		{
			return true;
		}

		return false;
	}

	// --------- Dash Input --------- //
	public static bool PressDash ()
	{
		if(Input.GetKeyDown(dash))
		{
			return true;
		}

		return false;
	}

	public static bool HoldDash ()
	{
		if(Input.GetKey(dash))
		{
			return true;
		}

		return false;
	}

	// -------- Crouch Input -------- //
	public static bool PressCrouch ()
	{
		if(Input.GetKeyDown(crouch))
		{
			return true;
		}

		return false;
	}

	public static bool HoldCrouch ()
	{
		if(Input.GetKey(crouch))
		{
			return true;
		}

		return false;
	}
}
