using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    public GameObject Player;
    public float HeightAbovePlayer = 20.0f;
    public float SpaceBehindPlayer = 20.0f;

    private Vector3 CameraAngle = new Vector3(45.0f, 0.0f, 0.0f);
    private Vector3 CameraOffset = Vector3.zero;

    void Start()
    {
        transform.eulerAngles = CameraAngle;
        CameraOffset = new Vector3(0.0f, HeightAbovePlayer, -SpaceBehindPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Player.transform.position + CameraOffset;
        transform.position = newPosition;
    }
}