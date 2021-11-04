using UnityEngine;

namespace Test2DGame
{
    [CreateAssetMenu(fileName = "LiftsReferences", menuName = "Data/LiftsReferences")]
    internal sealed class LiftsReferences : ScriptableObject
    {
        [SerializeField] private LiftView[] _commonLiftsViews;
        [SerializeField] private LiftView _finalLiftView;
        [SerializeField] private Transform _rootTransform;

        public LiftView[] CommonLiftsViews => _commonLiftsViews;
        public LiftView FinalLiftView => _finalLiftView;
        public Transform RootTransform => _rootTransform;
    }
}