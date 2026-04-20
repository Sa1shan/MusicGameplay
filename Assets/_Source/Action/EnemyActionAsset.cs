using UnityEngine;
using UnityEngine.Playables;

namespace _Source.Action
{
    public class EnemyActionAsset : PlayableAsset
    {
        public EnemyActionType ActionType;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<EnemyAction>.Create(graph);
            playable.GetBehaviour().ActionType = ActionType;
            return playable;
        }
    }
}