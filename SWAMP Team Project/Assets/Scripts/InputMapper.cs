using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMapper : MonoBehaviour 
{
	public Button leftButton;
	public Button rightButton;
	public Button upButton;
	public Button downButton;
	public Button jumpButton;
	public Button attackButton;
	public Button dashButton;
	public Button crouchButton;

	KeyCode defaultLeft = KeyCode.A;
	KeyCode defaultRight = KeyCode.D;
	KeyCode defaultUp = KeyCode.W;
	KeyCode defaultDown = KeyCode.S;
	KeyCode defaultJump = KeyCode.Space;
	KeyCode defaultAttack = KeyCode.E;
	KeyCode defaultDash = KeyCode.LeftShift;
	KeyCode defaultCrouch = KeyCode.LeftControl;

	bool listeningLeft;
	bool listeningRight;
	bool listeningUp;
	bool listeningDown;
	bool listeningJump;
	bool listeningAttack;
	bool listeningDash;
	bool listeningCrouch;

	void Start ()
	{
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;
	}

	public void RestoreToDefaults () 
	{
		InputManager.left = defaultLeft;
		InputManager.right = defaultRight;
		InputManager.up = defaultUp;
		InputManager.down = defaultDown;
		InputManager.jump = defaultJump;
		InputManager.attack = defaultAttack;
		InputManager.dash = defaultDash;
		InputManager.crouch = defaultCrouch;
	}

	public void ChangeLeft ()
	{
		listeningLeft = true;
		leftButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";

		listeningRight = false;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;

		listeningUp = false;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;

		listeningDown = false;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;

		listeningJump = false;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;

		listeningAttack = false;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;

		listeningDash = false;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;

		listeningCrouch = false;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;

	}

	public void ChangeRight ()
	{
		listeningLeft = false;
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;

		listeningRight = true;
		rightButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";

		listeningUp = false;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;

		listeningDown = false;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;

		listeningJump = false;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;

		listeningAttack = false;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;

		listeningDash = false;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;

		listeningCrouch = false;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;

	}

	public void ChangeUp ()
	{
		listeningLeft = false;
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;

		listeningRight = false;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;

		listeningUp = true;
		upButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";

		listeningDown = false;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;

		listeningJump = false;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;

		listeningAttack = false;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;

		listeningDash = false;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;

		listeningCrouch = false;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;

	}

	public void ChangeDown ()
	{
		listeningLeft = false;
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;

		listeningRight = false;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;

		listeningUp = false;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;

		listeningDown = true;
		downButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";

		listeningJump = false;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;

		listeningAttack = false;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;

		listeningDash = false;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;

		listeningCrouch = false;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;

	}

	public void ChangeJump ()
	{
		listeningLeft = false;
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;

		listeningRight = false;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;
			
		listeningUp = false;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;
			
		listeningDown = false;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;

		listeningJump = true;
		jumpButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";
			
		listeningAttack = false;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;
			
		listeningDash = false;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;
			
		listeningCrouch = false;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;

	}

	public void ChangeAttack ()
	{
		listeningLeft = false;
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;

		listeningRight = false;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;

		listeningUp = false;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;

		listeningDown = false;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;

		listeningJump = false;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;

		listeningAttack = true;
		attackButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";

		listeningDash = false;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;

		listeningCrouch = false;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;

	}

	public void ChangeDash ()
	{
		listeningLeft = false;
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;

		listeningRight = false;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;

		listeningUp = false;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;

		listeningDown = false;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;

		listeningJump = false;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;

		listeningAttack = false;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;

		listeningDash = true;
		dashButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";

		listeningCrouch = false;
		crouchButton.GetComponentInChildren<Text>().text = "" + InputManager.crouch;

	}

	public void ChangeCrouch ()
	{
		listeningLeft = false;
		leftButton.GetComponentInChildren<Text>().text = "" + InputManager.left;

		listeningRight = false;
		rightButton.GetComponentInChildren<Text>().text = "" + InputManager.right;

		listeningUp = false;
		upButton.GetComponentInChildren<Text>().text = "" + InputManager.up;

		listeningDown = false;
		downButton.GetComponentInChildren<Text>().text = "" + InputManager.down;

		listeningJump = false;
		jumpButton.GetComponentInChildren<Text>().text = "" + InputManager.jump;

		listeningAttack = false;
		attackButton.GetComponentInChildren<Text>().text = "" + InputManager.attack;

		listeningDash = false;
		dashButton.GetComponentInChildren<Text>().text = "" + InputManager.dash;

		listeningCrouch = true;
		crouchButton.GetComponentInChildren<Text>().text = "<- Press Any Key ->";

	}

	void Update ()
	{
		if(listeningLeft && Input.anyKeyDown)
		{
			listeningLeft = false;
			InputManager.left = GetInput();
			leftButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}

		if(listeningRight && Input.anyKeyDown)
		{
			listeningRight = false;
			InputManager.right = GetInput();
			rightButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}

		if(listeningUp && Input.anyKeyDown)
		{
			listeningUp = false;
			InputManager.up = GetInput();
			upButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}

		if(listeningDown && Input.anyKeyDown)
		{
			listeningDown = false;
			InputManager.down = GetInput();
			downButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}

		if(listeningJump && Input.anyKeyDown)
		{
			listeningJump = false;
			InputManager.jump = GetInput();
			jumpButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}

		if(listeningAttack && Input.anyKeyDown)
		{
			listeningAttack = false;
			InputManager.attack = GetInput();
			attackButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}

		if(listeningDash && Input.anyKeyDown)
		{
			listeningDash = false;
			InputManager.dash = GetInput();
			dashButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}

		if(listeningCrouch && Input.anyKeyDown)
		{
			listeningCrouch = false;
			InputManager.crouch = GetInput();
			crouchButton.GetComponentInChildren<Text>().text = "" + GetInput();
		}
	}

	KeyCode GetInput ()
	{
		#region Keyboard Inputs
		if(Input.GetKeyDown(KeyCode.Backspace))
		{
			return KeyCode.Backspace;
		}

		else if(Input.GetKeyDown(KeyCode.Delete))
		{
			return KeyCode.Delete;
		}

		else if(Input.GetKeyDown(KeyCode.Tab))
		{
			return KeyCode.Tab;
		}

		else if(Input.GetKeyDown(KeyCode.Clear))
		{
			return KeyCode.Clear;
		}

		else if(Input.GetKeyDown(KeyCode.Return))
		{
			return KeyCode.Return;
		}

		else if(Input.GetKeyDown(KeyCode.Pause))
		{
			return KeyCode.Pause;
		}

		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			return KeyCode.Escape;
		}

		else if(Input.GetKeyDown(KeyCode.Space))
		{
			return KeyCode.Space;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad0))
		{
			return KeyCode.Keypad0;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad1))
		{
			return KeyCode.Keypad1;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad2))
		{
			return KeyCode.Keypad2;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad3))
		{
			return KeyCode.Keypad3;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad4))
		{
			return KeyCode.Keypad4;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad5))
		{
			return KeyCode.Keypad5;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad6))
		{
			return KeyCode.Keypad6;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad7))
		{
			return KeyCode.Keypad7;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad8))
		{
			return KeyCode.Keypad8;
		}

		else if(Input.GetKeyDown(KeyCode.Keypad9))
		{
			return KeyCode.Keypad9;
		}

		else if(Input.GetKeyDown(KeyCode.KeypadPeriod))
		{
			return KeyCode.KeypadPeriod;
		}

		else if(Input.GetKeyDown(KeyCode.KeypadDivide))
		{
			return KeyCode.KeypadDivide;
		}

		else if(Input.GetKeyDown(KeyCode.KeypadMultiply))
		{
			return KeyCode.KeypadMultiply;
		}

		else if(Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			return KeyCode.KeypadMinus;
		}

		else if(Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			return KeyCode.KeypadPlus;
		}

		else if(Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			return KeyCode.KeypadEnter;
		}

		else if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			return KeyCode.UpArrow;
		}

		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			return KeyCode.DownArrow;
		}

		else if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			return KeyCode.RightArrow;
		}

		else if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			return KeyCode.LeftArrow;
		}

		else if(Input.GetKeyDown(KeyCode.Insert))
		{
			return KeyCode.Insert;
		}

		else if(Input.GetKeyDown(KeyCode.Home))
		{
			return KeyCode.Home;
		}

		else if(Input.GetKeyDown(KeyCode.End))
		{
			return KeyCode.End;
		}

		else if(Input.GetKeyDown(KeyCode.PageUp))
		{
			return KeyCode.PageUp;
		}

		else if(Input.GetKeyDown(KeyCode.PageDown))
		{
			return KeyCode.PageDown;
		}

		else if(Input.GetKeyDown(KeyCode.F1))
		{
			return KeyCode.F1;
		}

		else if(Input.GetKeyDown(KeyCode.F2))
		{
			return KeyCode.F2;
		}

		else if(Input.GetKeyDown(KeyCode.F3))
		{
			return KeyCode.F3;
		}

		else if(Input.GetKeyDown(KeyCode.F4))
		{
			return KeyCode.F4;
		}

		else if(Input.GetKeyDown(KeyCode.F5))
		{
			return KeyCode.F5;
		}

		else if(Input.GetKeyDown(KeyCode.F6))
		{
			return KeyCode.F6;
		}

		else if(Input.GetKeyDown(KeyCode.F7))
		{
			return KeyCode.F7;
		}

		else if(Input.GetKeyDown(KeyCode.F8))
		{
			return KeyCode.F8;
		}

		else if(Input.GetKeyDown(KeyCode.F9))
		{
			return KeyCode.F9;
		}

		else if(Input.GetKeyDown(KeyCode.F10))
		{
			return KeyCode.F10;
		}

		else if(Input.GetKeyDown(KeyCode.F11))
		{
			return KeyCode.F11;
		}

		else if(Input.GetKeyDown(KeyCode.F12))
		{
			return KeyCode.F12;
		}

		else if(Input.GetKeyDown(KeyCode.F13))
		{
			return KeyCode.F13;
		}

		else if(Input.GetKeyDown(KeyCode.F14))
		{
			return KeyCode.F14;
		}

		else if(Input.GetKeyDown(KeyCode.F15))
		{
			return KeyCode.F15;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha0))
		{
			return KeyCode.Alpha0;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			return KeyCode.Alpha1;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			return KeyCode.Alpha2;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			return KeyCode.Alpha3;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			return KeyCode.Alpha4;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			return KeyCode.Alpha5;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha6))
		{
			return KeyCode.Alpha6;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			return KeyCode.Alpha7;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha8))
		{
			return KeyCode.Alpha8;
		}

		else if(Input.GetKeyDown(KeyCode.Alpha9))
		{
			return KeyCode.Alpha9;
		}

		else if(Input.GetKeyDown(KeyCode.Exclaim))
		{
			return KeyCode.Exclaim;
		}

		else if(Input.GetKeyDown(KeyCode.DoubleQuote))
		{
			return KeyCode.DoubleQuote;
		}

		else if(Input.GetKeyDown(KeyCode.Hash))
		{
			return KeyCode.Hash;
		}

		else if(Input.GetKeyDown(KeyCode.Dollar))
		{
			return KeyCode.Dollar;
		}

		/*else if(Input.GetKeyDown(KeyCode.Percent))
		{
			return KeyCode.Percent;
		}*/

		else if(Input.GetKeyDown(KeyCode.Ampersand))
		{
			return KeyCode.Ampersand;
		}

		else if(Input.GetKeyDown(KeyCode.Quote))
		{
			return KeyCode.Quote;
		}

		else if(Input.GetKeyDown(KeyCode.LeftParen))
		{
			return KeyCode.LeftParen;
		}

		else if(Input.GetKeyDown(KeyCode.RightParen))
		{
			return KeyCode.RightParen;
		}

		else if(Input.GetKeyDown(KeyCode.Asterisk))
		{
			return KeyCode.Asterisk;
		}

		else if(Input.GetKeyDown(KeyCode.Plus))
		{
			return KeyCode.Plus;
		}

		else if(Input.GetKeyDown(KeyCode.Comma))
		{
			return KeyCode.Comma;
		}

		else if(Input.GetKeyDown(KeyCode.Minus))
		{
			return KeyCode.Minus;
		}

		else if(Input.GetKeyDown(KeyCode.Period))
		{
			return KeyCode.Period;
		}

		else if(Input.GetKeyDown(KeyCode.Slash))
		{
			return KeyCode.Slash;
		}

		else if(Input.GetKeyDown(KeyCode.Colon))
		{
			return KeyCode.Colon;
		}

		else if(Input.GetKeyDown(KeyCode.Semicolon))
		{
			return KeyCode.Semicolon;
		}

		else if(Input.GetKeyDown(KeyCode.Less))
		{
			return KeyCode.Less;
		}

		else if(Input.GetKeyDown(KeyCode.Equals))
		{
			return KeyCode.Equals;
		}

		else if(Input.GetKeyDown(KeyCode.Greater))
		{
			return KeyCode.Greater;
		}

		else if(Input.GetKeyDown(KeyCode.Question))
		{
			return KeyCode.Question;
		}

		else if(Input.GetKeyDown(KeyCode.At))
		{
			return KeyCode.At;
		}

		else if(Input.GetKeyDown(KeyCode.LeftBracket))
		{
			return KeyCode.LeftBracket;
		}

		else if(Input.GetKeyDown(KeyCode.Backslash))
		{
			return KeyCode.Backslash;
		}

		else if(Input.GetKeyDown(KeyCode.RightBracket))
		{
			return KeyCode.RightBracket;
		}

		else if(Input.GetKeyDown(KeyCode.Caret))
		{
			return KeyCode.Caret;
		}

		else if(Input.GetKeyDown(KeyCode.Underscore))
		{
			return KeyCode.Underscore;
		}

		else if(Input.GetKeyDown(KeyCode.BackQuote))
		{
			return KeyCode.BackQuote;
		}

		else if(Input.GetKeyDown(KeyCode.A))
		{
			return KeyCode.A;
		}

		else if(Input.GetKeyDown(KeyCode.B))
		{
			return KeyCode.B;
		}

		else if(Input.GetKeyDown(KeyCode.C))
		{
			return KeyCode.C;
		}

		else if(Input.GetKeyDown(KeyCode.D))
		{
			return KeyCode.D;
		}

		else if(Input.GetKeyDown(KeyCode.E))
		{
			return KeyCode.E;
		}

		else if(Input.GetKeyDown(KeyCode.F))
		{
			return KeyCode.F;
		}

		else if(Input.GetKeyDown(KeyCode.G))
		{
			return KeyCode.G;
		}

		else if(Input.GetKeyDown(KeyCode.H))
		{
			return KeyCode.H;
		}

		else if(Input.GetKeyDown(KeyCode.I))
		{
			return KeyCode.I;
		}

		else if(Input.GetKeyDown(KeyCode.J))
		{
			return KeyCode.J;
		}

		else if(Input.GetKeyDown(KeyCode.K))
		{
			return KeyCode.K;
		}

		else if(Input.GetKeyDown(KeyCode.L))
		{
			return KeyCode.L;
		}

		else if(Input.GetKeyDown(KeyCode.M))
		{
			return KeyCode.M;
		}

		else if(Input.GetKeyDown(KeyCode.N))
		{
			return KeyCode.N;
		}

		else if(Input.GetKeyDown(KeyCode.O))
		{
			return KeyCode.O;
		}

		else if(Input.GetKeyDown(KeyCode.P))
		{
			return KeyCode.P;
		}

		else if(Input.GetKeyDown(KeyCode.Q))
		{
			return KeyCode.Q;
		}

		else if(Input.GetKeyDown(KeyCode.R))
		{
			return KeyCode.R;
		}

		else if(Input.GetKeyDown(KeyCode.S))
		{
			return KeyCode.S;
		}

		else if(Input.GetKeyDown(KeyCode.T))
		{
			return KeyCode.T;
		}

		else if(Input.GetKeyDown(KeyCode.U))
		{
			return KeyCode.U;
		}

		else if(Input.GetKeyDown(KeyCode.V))
		{
			return KeyCode.V;
		}

		else if(Input.GetKeyDown(KeyCode.W))
		{
			return KeyCode.W;
		}
		else if(Input.GetKeyDown(KeyCode.X))
		{
			return KeyCode.X;
		}

		else if(Input.GetKeyDown(KeyCode.Y))
		{
			return KeyCode.Y;
		}

		else if(Input.GetKeyDown(KeyCode.Z))
		{
			return KeyCode.Z;
		}

		/*else if(Input.GetKeyDown(KeyCode.LeftCurlyBracket))
		{
			return KeyCode.LeftCurlyBracket;
		}*/

		/*else if(Input.GetKeyDown(KeyCode.Pipe))
		{
			return KeyCode.Pipe;
		}*/

		/*else if(Input.GetKeyDown(KeyCode.RightCurlyBracket))
		{
			return KeyCode.RightCurlyBracket;
		}*/

		/*else if(Input.GetKeyDown(KeyCode.Tilde))
		{
			return KeyCode.Tilde;
		}*/

		else if(Input.GetKeyDown(KeyCode.Numlock))
		{
			return KeyCode.Numlock;
		}

		else if(Input.GetKeyDown(KeyCode.CapsLock))
		{
			return KeyCode.CapsLock;
		}

		else if(Input.GetKeyDown(KeyCode.ScrollLock))
		{
			return KeyCode.ScrollLock;
		}

		else if(Input.GetKeyDown(KeyCode.RightShift))
		{
			return KeyCode.RightShift;
		}

		else if(Input.GetKeyDown(KeyCode.LeftShift))
		{
			return KeyCode.LeftShift;
		}

		else if(Input.GetKeyDown(KeyCode.RightControl))
		{
			return KeyCode.RightControl;
		}

		else if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			return KeyCode.LeftControl;
		}

		else if(Input.GetKeyDown(KeyCode.RightAlt))
		{
			return KeyCode.RightAlt;
		}

		else if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			return KeyCode.LeftAlt;
		}

		else if(Input.GetKeyDown(KeyCode.LeftCommand))
		{
			return KeyCode.LeftCommand;
		}

		else if(Input.GetKeyDown(KeyCode.LeftApple))
		{
			return KeyCode.LeftApple;
		}

		else if(Input.GetKeyDown(KeyCode.LeftWindows))
		{
			return KeyCode.LeftWindows;
		}

		else if(Input.GetKeyDown(KeyCode.RightCommand))
		{
			return KeyCode.RightCommand;
		}

		else if(Input.GetKeyDown(KeyCode.RightApple))
		{
			return KeyCode.RightApple;
		}

		else if(Input.GetKeyDown(KeyCode.RightWindows))
		{
			return KeyCode.RightWindows;
		}

		else if(Input.GetKeyDown(KeyCode.AltGr))
		{
			return KeyCode.AltGr;
		}

		else if(Input.GetKeyDown(KeyCode.Help))
		{
			return KeyCode.Help;
		}

		else if(Input.GetKeyDown(KeyCode.Print))
		{
			return KeyCode.Print;
		}

		else if(Input.GetKeyDown(KeyCode.SysReq))
		{
			return KeyCode.SysReq;
		}

		else if(Input.GetKeyDown(KeyCode.Break))
		{
			return KeyCode.Break;
		}

		else if(Input.GetKeyDown(KeyCode.Menu))
		{
			return KeyCode.Menu;
		}
		#endregion

		#region Mouse Inputs
		else if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			return KeyCode.Mouse0;
		}

		else if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			return KeyCode.Mouse1;
		}

		else if(Input.GetKeyDown(KeyCode.Mouse2))
		{
			return KeyCode.Mouse2;
		}

		else if(Input.GetKeyDown(KeyCode.Mouse3))
		{
			return KeyCode.Mouse3;
		}

		else if(Input.GetKeyDown(KeyCode.Mouse4))
		{
			return KeyCode.Mouse4;
		}

		else if(Input.GetKeyDown(KeyCode.Mouse5))
		{
			return KeyCode.Mouse5;
		}

		else if(Input.GetKeyDown(KeyCode.Mouse6))
		{
			return KeyCode.Mouse6;
		}
		#endregion

		#region Jostick Inputs
		#region All Joysticks
		else if(Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			return KeyCode.JoystickButton0;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton1))
		{
			return KeyCode.JoystickButton1;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton2))
		{
			return KeyCode.JoystickButton2;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton3))
		{
			return KeyCode.JoystickButton3;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton4))
		{
			return KeyCode.JoystickButton4;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			return KeyCode.JoystickButton5;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton6))
		{
			return KeyCode.JoystickButton6;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton7))
		{
			return KeyCode.JoystickButton7;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton8))
		{
			return KeyCode.JoystickButton8;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton9))
		{
			return KeyCode.JoystickButton9;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton10))
		{
			return KeyCode.JoystickButton10;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton11))
		{
			return KeyCode.JoystickButton11;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton12))
		{
			return KeyCode.JoystickButton12;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton13))
		{
			return KeyCode.JoystickButton13;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton14))
		{
			return KeyCode.JoystickButton14;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton15))
		{
			return KeyCode.JoystickButton15;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton16))
		{
			return KeyCode.JoystickButton16;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton17))
		{
			return KeyCode.JoystickButton17;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton18))
		{
			return KeyCode.JoystickButton18;
		}

		else if(Input.GetKeyDown(KeyCode.JoystickButton19))
		{
			return KeyCode.JoystickButton19;
		}
		#endregion
		#endregion

		return KeyCode.None;
	}
}