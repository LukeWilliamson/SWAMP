using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    BoxCollider2D col;
    public int buttonNum;
    public int type = 0;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        IsCursorInBounds();
    }

    void IsCursorInBounds()
    {
        if (col.bounds.max.x > Input.mousePosition.x &&
            col.bounds.min.x < Input.mousePosition.x &&
            col.bounds.max.y > Input.mousePosition.y &&
            col.bounds.min.y < Input.mousePosition.y)
        {
            if (type == 0)
            {
                FindObjectOfType<PauseMenu>().pauseButtonIndex = buttonNum;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Button>().onClick.Invoke();
                }
            }

            if (type == 1)
            {
                FindObjectOfType<PauseMenu>().optionsButtonIndex = buttonNum;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Button>().onClick.Invoke();
                }
            }

            if (type == 2)
            {
                FindObjectOfType<PauseMenu>().audioButtonIndex = buttonNum;

                if (Input.GetMouseButtonDown(0) && GetComponent<Button>())
                {
                    GetComponent<Button>().onClick.Invoke();
                }
            }

            if (type == 3 && !FindObjectOfType<InputMapper>().listening)
            {
                FindObjectOfType<PauseMenu>().inputButtonIndex = buttonNum;

                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Button>().onClick.Invoke();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    FindObjectOfType<InputMapper>().listening = true;
                }
            }
        }            
    }

}
