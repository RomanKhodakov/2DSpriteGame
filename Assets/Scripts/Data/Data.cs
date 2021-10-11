using System.IO;
using UnityEngine;


namespace Test2DGame
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    internal sealed class Data : ScriptableObject
    {
        [SerializeField] private string _spriteAnimationsDataPath;
        private PlayerView _player;
        private SpriteAnimationsConfig _spriteAnimations;
        private GameObject _background;

        public PlayerView PlayerView
        {
            get
            {
                if (_player == null)
                {
                    _player = Object.FindObjectOfType<PlayerView>();
                }

                return _player;
            }
        }
        public SpriteAnimationsConfig SpriteAnimations
        {
            get
            {
                if (_spriteAnimations == null)
                {
                    _spriteAnimations = Load<SpriteAnimationsConfig>("Data/" + _spriteAnimationsDataPath);
                }

                return _spriteAnimations;
            }
        }
        
        public GameObject Background
        {
            get
            {
                if (_background == null)
                {
                    var gameObject = Resources.Load<GameObject>("Background/GreenBackground");
                    _background = Object.Instantiate(gameObject);
                }

                return _background;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}