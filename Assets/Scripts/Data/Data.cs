using System.IO;
using UnityEngine;


namespace Test2DGame
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    internal sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _spriteAnimationsDataPath;
        [SerializeField] private string _GunBulletDataPath;
        private PlayerData _playerData;
        private SpriteAnimationsConfig _playerSpriteAnimations;
        private GunBulletData _gunBulletData;
        private GameObject _background;

        public PlayerData PlayerData
        {
            get
            {
                if (_playerData == null)
                {
                    _playerData = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _playerData;
            }
        }
        
        public SpriteAnimationsConfig PlayerSpriteAnimations
        {
            get
            {
                if (_playerSpriteAnimations == null)
                {
                    _playerSpriteAnimations = Load<SpriteAnimationsConfig>("Data/" + _spriteAnimationsDataPath);
                }

                return _playerSpriteAnimations;
            }
        }
        public GunBulletData GunBulletData
        {
            get
            {
                if (_gunBulletData == null)
                {
                    _gunBulletData = Load<GunBulletData>("Data/" + _GunBulletDataPath);
                }

                return _gunBulletData;
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