using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    public PlayerRunState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.SetVelocityX(playerData.runtVelocity * xInput);

        player.CheckIfShouldFlip(xInput);

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        if (!runInput && xInput != 0)
        {
            stateMachine.ChangeState(player.WalkState);
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
}
