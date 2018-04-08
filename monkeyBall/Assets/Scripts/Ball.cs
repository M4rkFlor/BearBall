using System;
using UnityEngine;
using UnityEngine.Networking;
namespace UnityStandardAssets.Vehicles.Ball
{
	public class Ball : NetworkBehaviour
    {
        [SerializeField] private float m_MovePower = 10; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 25; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;


        private void Start()
        {
			if(!isLocalPlayer)
				return;
			
            m_Rigidbody = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }


        public void Move(Vector3 moveDirection, bool jump)
        {
			jump = false;
            // If using torque to rotate the ball...
			if (m_UseTorque /*&& Mathf.Abs(m_Rigidbody.velocity.y)<=0.05*/)
            {
                // ... add torque around the axis defined by the move direction.
				if (moveDirection == Vector3.zero) {
					m_Rigidbody.angularDrag = 10000000000000000000000.0f;
				} else {
					m_Rigidbody.angularDrag = .05f;
					m_Rigidbody.AddTorque (new Vector3 (moveDirection.z, 0, -moveDirection.x) * m_MovePower);
				}
            }
            else
            {
                // Otherwise add force in the move direction.
                m_Rigidbody.AddForce(moveDirection*m_MovePower);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
        }
    }
}
