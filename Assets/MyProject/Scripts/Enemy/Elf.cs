public class Elf : DefoultEnemy
{
    protected override void AgentBehavior()
    {
        if (_isDie)
        {
            return;
        }
        bool isMoving = false;
        isMoving = DefaultMovement.TryMoveAgent(this.transform.position, _playerTransform.position, _enemyAnimator, _distance, _agent, false);
        if (!isMoving)
        {
            Attack();
        }
    }
    protected override void Behavior()
    {
        if (_isDie)
        {
            return;
        }
        bool isMoving;
        isMoving = DefaultMovement.TryMove(this.transform.position, _playerTransform.position, _enemyRigidbody, _enemyAnimator, _distance, _enemyInfo.Speed, 0.5f);
        if (!isMoving)
        {
            Attack();
        }
    }
}
