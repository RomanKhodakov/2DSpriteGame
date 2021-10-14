using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal class SpriteAnimator : IExecute, ICleanup
    {
        private readonly SpriteAnimationsConfig _config;
        private readonly Dictionary<SpriteRenderer, PlayerAnimation> _activeAnimations;

        public SpriteAnimator(SpriteAnimationsConfig config)
        {
            _activeAnimations = new Dictionary<SpriteRenderer, PlayerAnimation>();
            _config = config;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, Track track, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleeps = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new PlayerAnimation()
                {
                    Track = track,
                    Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimations.ContainsKey(spriteRenderer))
            {
                _activeAnimations.Remove(spriteRenderer);
            }
        }
        
        public void Execute(float deltaTime)
        {
            foreach (var animationKvp in _activeAnimations)
            {
                animationKvp.Value.Update();
                animationKvp.Key.sprite = animationKvp.Value.Sprites[(int) animationKvp.Value.Counter];
            }
        }
        
        public void Cleanup()
        {
            _activeAnimations.Clear();
        }

    }
}