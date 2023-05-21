using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private PlayerInputManger Input;
    [SerializeField] private float MouseSensitivity = 10f;
    private float MouseX ;
    private float MouseY;

    [SerializeField] private float LookUpDown = 0f;

    [SerializeField] Transform PlayerBody;
    // Start is called before the first frame update
    void Start()
    {
        Input = GetComponentInParent<PlayerInputManger>();

    }

    // Update is called once per frame

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        MouseX = Input.Look.x * Time.deltaTime * MouseSensitivity;
        MouseY = Input.Look.y * Time.deltaTime * MouseSensitivity;
        LookUpDown -= MouseY;
        LookUpDown = Mathf.Clamp(LookUpDown,-30f,30f);
        transform.localRotation = Quaternion.Euler(LookUpDown,0f,0f);
        PlayerBody.Rotate(Vector3.up*MouseX);

    }
}
