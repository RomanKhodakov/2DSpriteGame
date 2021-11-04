using UnityEngine;

namespace Test2DGame
{
    internal class AreaEffectorView : MonoBehaviour
    {
        [SerializeField] private AreaEffector2D _areaEffector;
        private PlayerView _levelObject;

        private void OnTriggerExit2D(Collider2D collider)
        {
            _levelObject = collider.gameObject.GetComponent<PlayerView>();

            if (_levelObject != null)
                _areaEffector.forceMagnitude *= -1;
        }
    }
}