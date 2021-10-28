using UnityEngine;

namespace Test2DGame
{
    internal sealed class SwitchQuestModel : IQuestModel
    {
        public bool TryComplete(GameObject activator)
        {
            return activator.GetComponent<PlayerView>() != null;
        }
    }
}
