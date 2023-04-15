using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerGroundedState
{
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.AdjustCollider(playerData.standingColliderSize, playerData.standingColliderOffset);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityX(playerData.walkVelocity * xInput);

        player.CheckIfShouldFlip(xInput);

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        if (xInput != 0 && runInput)
        {
            stateMachine.ChangeState(player.RunState);
        }

        if (crouchInput)
        {
            stateMachine.ChangeState(player.CrouchIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    // TODO: make player go to crouch walik from crouch idle to make code look cleaner.it doesnt look that ugly anyway.
}
