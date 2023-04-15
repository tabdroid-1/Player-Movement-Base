using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchWalkState : PlayerGroundedState
{
    public PlayerCrouchWalkState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.AdjustCollider(playerData.crouchColliderSize, playerData.crouchColliderOffset);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityX(playerData.crouchMovementVelocity * xInput);

        player.CheckIfShouldFlip(xInput);

        if (xInput == 0 && crouchInput)
        {
            stateMachine.ChangeState(player.CrouchIdleState);
        }
        else if (xInput == 0 && !crouchInput)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        if (xInput != 0 && !crouchInput && !runInput)
        {
            stateMachine.ChangeState(player.WalkState);
        }
        else if (xInput != 0 && !crouchInput && runInput)
        {
            stateMachine.ChangeState(player.RunState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
