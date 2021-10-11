using UnityEngine;

namespace Test2DGame
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy<float> _horizontal;
        private readonly IUserInputProxy<float> _vertical;
        private readonly IUserInputProxy<bool> _mouseFire1;

        public InputController((IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical,
                IUserInputProxy<bool> mouseFire1) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _mouseFire1 = input.mouseFire1;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _mouseFire1.GetAxis();
        }
    }
}