using System.Collections.Generic;
using UnityEngine;

namespace Test2DGame
{
    internal sealed class LiftController : IInitialization, ICleanup
    {
        private const float MotorSpeed = 1f;
        private const float MaxMotorTorque = 30f;
        private readonly LiftView _finalLiftView;
        private readonly List<LiftView> _commonLiftsViews;
        private readonly QuestController _questController;

        public LiftController(InteractiveObjectsInitialization ioInitialization, QuestController questController)
        {
            _finalLiftView = ioInitialization.GetFinalLiftView();
            _commonLiftsViews = ioInitialization.GetCommonLiftsViews();
            _questController = questController;
        }

        public void Initialization()
        {
            foreach (var liftView in _commonLiftsViews)
            {
                liftView.OnLevelObjectContact += OnCommonLiftContact;
                liftView.OnLevelObjectLeave += OnCommonLiftLeave;
            }

            _finalLiftView.OnLevelObjectContact += OnFinalLiftContact;
            _finalLiftView.OnLevelObjectLeave += OnFinalLiftLeave;
        }

        private void OnCommonLiftContact(SliderJoint2D sliderJoint)
        {
            sliderJoint.motor = new JointMotor2D() {motorSpeed = -MotorSpeed, maxMotorTorque = MaxMotorTorque};
        }

        private void OnCommonLiftLeave(SliderJoint2D sliderJoint)
        {
            sliderJoint.motor = new JointMotor2D() {motorSpeed = MotorSpeed, maxMotorTorque = MaxMotorTorque};
        }

        private void OnFinalLiftContact(SliderJoint2D sliderJoint)
        {
            if (_questController.IsAllQuestsStoriesDone())
                sliderJoint.motor = new JointMotor2D() {motorSpeed = -2 * MotorSpeed, maxMotorTorque = MaxMotorTorque};
        }

        private void OnFinalLiftLeave(SliderJoint2D sliderJoint)
        {
            if (_questController.IsAllQuestsStoriesDone())
                sliderJoint.motor = new JointMotor2D() {motorSpeed = 2 * MotorSpeed, maxMotorTorque = MaxMotorTorque};
        }

        public void Cleanup()
        {
            foreach (var liftView in _commonLiftsViews)
            {
                liftView.OnLevelObjectContact -= OnCommonLiftContact;
                liftView.OnLevelObjectLeave -= OnCommonLiftLeave;
            }

            _finalLiftView.OnLevelObjectContact -= OnFinalLiftContact;
            _finalLiftView.OnLevelObjectLeave -= OnFinalLiftLeave;
        }
    }
}