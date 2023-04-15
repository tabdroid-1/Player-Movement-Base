using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchWalkState CrouchWalkState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }


    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D PlayerRB { get; private set; }
    public CapsuleCollider2D PlayerCollider { get; private set; }
    #endregion

    #region Check Variables
    [SerializeField] private Transform groundCheck;
    #endregion

    #region Other Variables
    [SerializeField] private PlayerData playerData;

    private Vector2 workspace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        WalkState = new PlayerWalkState(this, StateMachine, playerData, "walk");
        RunState = new PlayerRunState(this, StateMachine, playerData, "run");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        CrouchWalkState = new PlayerCrouchWalkState(this, StateMachine, playerData, "crouchWalk");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponentInChildren<PlayerInputHandler>();
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponentInChildren<CapsuleCollider2D>();

        StateMachine.Initialize(IdleState);

        FacingDirection = 1;
        // -------------------DELETE THIS AFTER USE-------------------

        Application.targetFrameRate = 60;

        // ^--^--^--^--^--^--^DELETE THIS AFTER USE^--^--^--^--^--^--^
    }

    private void Update()
    {

        CurrentVelocity = PlayerRB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    // for debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, playerData.groundCheckBoxSize);
    }
    // --------------
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Check Functions
    public void CheckIfShouldFlip(float xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, playerData.groundCheckBoxSize, 0f, playerData.whatIsGround);
    }
    #endregion

    #region Custom Functions
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        PlayerRB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        PlayerRB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void AdjustCollider(Vector2 size, Vector2 offset)
    {
        PlayerCollider.size = size;
        PlayerCollider.offset = offset;
    }

    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger(); 
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    #endregion
}
