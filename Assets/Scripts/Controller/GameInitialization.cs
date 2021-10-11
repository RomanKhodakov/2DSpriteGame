using UnityEngine;

namespace Test2DGame
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var spriteAnimator = new SpriteAnimator(data.SpriteAnimations);

            controllers.Add(spriteAnimator);
            
            controllers.Add(new ParallaxManager(camera.transform, data.Background.transform));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new PlayerMoveController(inputInitialization.GetInput(), spriteAnimator,
                data.PlayerView.SpriteRenderer));
        }
    }
}