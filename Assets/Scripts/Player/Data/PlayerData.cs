using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{

    [Header("Check Variables")]
    public Vector2 groundCheckBoxSize;
    public LayerMask whatIsGround;

    [Space]
    [Header("General State")]
    public Vector2 standingColliderSize = new Vector2(0.29f, 0.61f);
    public Vector2 standingColliderOffset = new Vector2(-0.02f, 0.316f);

    [Space]
    [Header("Move State")]
    public float walkVelocity = 1.3f;
    public float runtVelocity = 2.5f;

    [Space]
    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Space]
    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Space]
    [Header("In Air State")]
    public float inAirVelocity = 3.5f;
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Space]
    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Space]
    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Space]
    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Space]
    [Header("Dash State")]
    public float dashCooldown = 0.5f;
    public float maxHoldTime = 1f;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 30f;
    public float drag = 10f;
    public float dashEndYMultiplier = 0.2f;
    public float distBetweenAfterImages = 0.5f;

    [Space]
    [Header("Crouch States")]
    public Vector2 crouchColliderSize = new Vector2(0.29f, 0.39f);
    public Vector2 crouchColliderOffset = new Vector2(-0.02f, 0.21f);
    public float crouchMovementVelocity = 5f;
    public float crouchColliderHeight = 0.8f;
    public float standColliderHeight = 1.6f;

}