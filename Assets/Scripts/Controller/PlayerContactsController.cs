using UnityEngine;

namespace Test2DGame
{
    internal class PlayerContactsController: IFixedExecute
    {
        private const float CollisionThreshold = 0.7f;

        private readonly ContactPoint2D[] _contacts = new ContactPoint2D[4];
        private readonly Collider2D _collider;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContacts { get; private set; }
        public bool HasRightContacts { get; private set; }

        public PlayerContactsController(Collider2D collider)
        {
            _collider = collider;
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            IsGrounded = false;
            HasLeftContacts = false;
            HasRightContacts = false;

            var contactCount = _collider.GetContacts(_contacts);

            for (var i = 0; i < contactCount; i++)
            {
                var normal = _contacts[i].normal;
                var rigidbody = _contacts[i].rigidbody;

                if (normal.y > CollisionThreshold)
                    IsGrounded = true;

                if (normal.x > CollisionThreshold && rigidbody != null)
                    HasLeftContacts = true;

                if (normal.x < -CollisionThreshold && rigidbody != null)
                    HasRightContacts = true;
            }
        }
    }
}