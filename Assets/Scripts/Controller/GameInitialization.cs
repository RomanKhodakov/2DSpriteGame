using System.Collections.Generic;
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
            var playerContactsController = new PlayerContactsController(playerInitialization.GetPlayerCollider());
            
            var enemyFactory = new EnemyFactory();
            var enemyInitialization = new EnemyInitialization(enemyFactory, playerInitialization.GetPlayerTransform());

            var gunFactory = new GunFactory();
            var gunInitialization = new GunInitialization(gunFactory);

            var bulletFactory = new BulletFactory(data.GunBulletData);
            var bulletEmitter = new BulletEmitter(bulletFactory, gunInitialization.GetGunTransform());

            var ioFactory = new InteractiveObjectsFactory();
            var ioInitialization = new InteractiveObjectsInitialization(ioFactory);
            var dangerZoneController = new DangerZoneController(enemyInitialization);

            controllers.Add(playerSpriteAnimator);
            controllers.Add(playerInitialization);
            controllers.Add(playerContactsController);
            controllers.Add(enemyInitialization);
            controllers.Add(gunInitialization);
            controllers.Add(dangerZoneController);

            controllers.Add(new ParallaxManager(camera.transform, data.Background.transform));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new CameraController(playerInitialization.GetPlayerTransform(), camera.transform));
            controllers.Add(new PlayerMoveController(inputInitialization.GetInput(), playerSpriteAnimator,
                playerInitialization, playerContactsController, data.PlayerData));

            controllers.Add(new CheckPointController(new List<CheckPointView>()
            {
                ioInitialization.GetCheckPoint()
            }));
            controllers.Add(new LiftController());

            controllers.Add(new GunPositionController(playerInitialization.GetPlayerTransform(),
                gunInitialization, enemyInitialization));
            controllers.Add(new GunShootProxy(new GunShootController(bulletEmitter), dangerZoneController));
            controllers.Add(new BulletSelfDestructionController(bulletFactory));
        }
    }
}