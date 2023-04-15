using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    public PlayerCrouchIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        if (crouchInput && xInput != 0)
        {
            stateMachine.ChangeState(player.CrouchWalkState);
        }
        else if (!crouchInput && xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (!crouchInput && xInput != 0 && !runInput)
        {
            stateMachine.ChangeState(player.WalkState);
        }
        else if (!crouchInput && xInput != 0 && runInput)
        {
            stateMachine.ChangeState(player.RunState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
