using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    private readonly int MoveSpeedHash = Animator.StringToHash(Constants.MoveSpeed);
    private readonly int MoveBlendTreeHash = Animator.StringToHash(Constants.MoveBlendTree);
    private const float AnimationDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Velocity.y = Physics.gravity.y;

        stateMachine.Animator.CrossFadeInFixedTime(MoveBlendTreeHash, CrossFadeDuration);

        stateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;
    }

    public override void Tick()
    {
        CalculateMoveDirection();
        FaceMoveDirection();
        Move();

        stateMachine.Animator.SetFloat(MoveSpeedHash, stateMachine.InputReader.MoveComposite.sqrMagnitude > 0f ? 1f : 0f, AnimationDampTime, Time.deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.OnJumpPerformed -= SwitchToJumpState;
    }

    private void SwitchToJumpState()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
    }
}