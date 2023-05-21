using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputManger : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 move;
    public Vector2 Look;

    public bool Issprinting;
    void OnMove(InputValue value)
    {
        move =  value.Get<Vector2>();
    }
    void OnLook(InputValue value)
    {
        Look = value.Get<Vector2>();
    }

    void OnSprint(InputValue value)
    {
        Issprinting = value.isPressed;
    }
}
