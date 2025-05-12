using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        CursorHide();
    }

    void Update()
    {
        // Si presionas Escape, desbloquea y muestra el cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CursorShow();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CursorHide();
        }  
    }

    public void CursorShow()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CursorHide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
