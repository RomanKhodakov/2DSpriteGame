using UnityEngine;

namespace Test2DGame
{
    internal sealed class InputInitialization : IInitialization
    {
        private readonly IUserInputProxy<float> _pcInputHorizontal;
        private readonly IUserInputProxy<float> _pcInputVertical;
        private readonly IUserInputProxy<bool> _inputFire1;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _inputFire1 = new PCInputFireFirst();
        }

        public void Initialization()
        {
        }

        public (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical, IUserInputProxy<bool>
            inputFire1) GetInput()
        {
            (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical, IUserInputProxy<bool>
                inputFire1) result = (_pcInputHorizontal, _pcInputVertical, _inputFire1);
            return result;
        }
    }
}