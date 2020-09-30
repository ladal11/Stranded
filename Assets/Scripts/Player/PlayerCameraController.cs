using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

    [SerializeField] private float lookSensitivity = 5.0f;
    [SerializeField] private bool xAxisInverted = false;
    [SerializeField] private bool yAxisInverted = false;

    private float yAxisInversionValue;
    private float xAxisInversionValue;
    float trackedYRotation;

    private Vector3 cameraRotation;
    private GameObject player;



    private void Awake()
    {
        HideMouse();
    }

    private void Start()
    {
        yAxisInversionValue = (yAxisInverted) ? 1f : -1f;
        xAxisInversionValue = (xAxisInverted) ? -1f : 1f;
        trackedYRotation = 0f;
        player = transform.parent.gameObject;
    }

    private void LateUpdate()
    {
        Look();
    }

    private void Look()
    {
        float xAxisRotation = xAxisInversionValue * Input.GetAxisRaw("Mouse X") * lookSensitivity;
        float yAxisRotation = yAxisInversionValue * Input.GetAxisRaw("Mouse Y") * lookSensitivity;

        if ((trackedYRotation + yAxisRotation) < 90f && (trackedYRotation + yAxisRotation) > -90f)
        {
            transform.Rotate(new Vector3(yAxisRotation, 0f, 0f));
            trackedYRotation += yAxisRotation;
        }

        player.transform.Rotate(new Vector3(0f, xAxisRotation, 0f));

    }

    //private void OnGUI()
    //{
    //    GUI.Box(new Rect(Screen.width / 2f - 5f, Screen.height / 2f - 5f, 10f, 10f), "");
    //}

    private void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
