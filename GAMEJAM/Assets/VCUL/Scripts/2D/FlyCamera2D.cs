using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera2D : MonoBehaviour
{
    [Header("Camera")]
    [Tooltip("Multiplier for camera sensitivity.")]
    [Range(0f, 300)]
    public float sensitivity = 90f;
    [Tooltip("Multiplier for normal camera movement.")]
    [Range(0f, 20f)]
    public float normalMoveSpeed = 10f;
    [Tooltip("Multiplier for slower camera movement.")]
    [Range(0f, 5f)]
    public float slowMoveSpeed = 0.25f;
    [Tooltip("Multiplier for faster camera movement.")]
    [Range(0f, 40f)]
    public float fastMoveSpeed = 3f;
    [Tooltip("Relative offset to the original position.")]
    public Vector3 offset;
    [Tooltip("Movement limits on the X-axis. X represents the lowest and Y the highest value.")]
    public Vector2 moveLimitsX;
    [Tooltip("Movement limits on the Y-axis. X represents the lowest and Y the highest value.")]
    public Vector2 moveLimitsY;

    private Vector3 position;

}
