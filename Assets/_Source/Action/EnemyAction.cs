using _Source.Controller;
using UnityEngine.Playables;

namespace _Source.Action
{
    public enum EnemyActionType { Shoot, Shield }

    public class EnemyAction : PlayableBehaviour
    {
        public EnemyActionType ActionType;
        public EnemyController Enemy;
        private bool _hasExecuted = false;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            Enemy = playerData as EnemyController;
            if (ActionType == EnemyActionType.Shoot && !_hasExecuted)
            {
                Enemy.Shoot();
                _hasExecuted = true;
            }
            if (ActionType == EnemyActionType.Shield)
            {
                Enemy.SetShield(true);
            }
        }
        
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            _hasExecuted = false; 
        }
        
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (ActionType == EnemyActionType.Shield)
            {
                Enemy.SetShield(false);
            }
        }
    }
}