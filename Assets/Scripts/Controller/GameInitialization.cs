using UnityEngine;

namespace Test2DGame
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerSpriteAnimator = new SpriteAnimator(data.PlayerSpriteAnimations);
            var playerFactory = new PlayerFactory(data.PlayerData);
            var playerInitialization = new PlayerInitialization(playerFactory);

            var gunFactory = new GunFactory();
            var gunInitialization = new GunInitialization(gunFactory);

            var bulletFactory = new BulletFactory(data.GunBulletData);
            var bulletEmitter = new BulletEmitter(bulletFactory, gunInitialization.GetGunTransform());

            controllers.Add(playerSpriteAnimator);
            controllers.Add(playerInitialization);
            controllers.Add(gunInitialization);

            controllers.Add(new ParallaxManager(camera.transform, data.Background.transform));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new PlayerMoveController(inputInitialization.GetInput(), playerSpriteAnimator,
                playerInitialization));

            controllers.Add(new GunRotationController(playerInitialization.GetPlayerTransform(),
                gunInitialization.GetGunTransform()));
            controllers.Add(new GunShootController(bulletEmitter));
            controllers.Add(new BulletSelfDestructionController(bulletFactory));
        }
    }
}