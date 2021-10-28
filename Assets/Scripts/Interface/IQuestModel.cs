using UnityEngine;


namespace Test2DGame
{
    internal interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}
