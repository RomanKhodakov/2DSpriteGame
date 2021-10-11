namespace Test2DGame
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
}