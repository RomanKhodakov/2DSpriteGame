using UnityEngine;

namespace Test2DGame
{
    internal sealed class LiftController : IInitialization, ICleanup
    {
        private const float MotorSpeed = 0.7f;
        private const float MaxMotorTorque = 30f;
        private readonly LiftView _liftView;

        public LiftController()
        {
            _liftView = Object.FindObjectOfType<LiftView>();
        }

        public void Initialization()
        {
            _liftView.OnLevelObjectContact += OnLevelObjectContact;
            _liftView.OnLevelObjectLeave += OnLevelObjectLeave;
        }

        private void OnLevelObjectContact(SliderJoint2D sliderJoint)
        {
            sliderJoint.motor = new JointMotor2D() {motorSpeed = -MotorSpeed, maxMotorTorque = MaxMotorTorque};
        }
        private void OnLevelObjectLeave(SliderJoint2D sliderJoint)
        {
            
            Debug.Log(3);
            sliderJoint.motor = new JointMotor2D() {motorSpeed = MotorSpeed, maxMotorTorque = MaxMotorTorque};
        }

        public void Cleanup()
        {
            _liftView.OnLevelObjectContact -= OnLevelObjectContact;
            _liftView.OnLevelObjectLeave -= OnLevelObjectLeave;
        }
    }
}