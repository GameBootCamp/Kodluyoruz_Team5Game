using System;
using UnityEngine;

namespace Game.Controllers.Character
{
    public class PlayerController : MonoBehaviour
    {
        public float forwardForce;
        public float upForce;
        public Vector3 maxForceLimit;
        public float maxYPosLimit;
        public ParticleSystem particleEffect;

        private Rigidbody rb;
        private Vector3 totalForce;
        private bool isMoving;
        private bool isFalling;

        #region Monobehaviour Functions
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            totalForce = Vector3.zero;
            isMoving = false;
            isFalling = false;
        }

        private void FixedUpdate()
        {
            if(isMoving)
            {
                Move();
            }

            else if(transform.position.y <= -1)
            {
                isFalling = true;
                particleEffect.Stop();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("platform"))
            {
                // force yüzünden devrilip düşmesin diye
                rb.velocity = Vector3.zero;
            }
        }
        #endregion

        internal void IsMoving(bool isMoving)
        {
            this.isMoving = isMoving;

            if(!isMoving)
            {
                StopMove();
            }
        }

        private void Move()
        {
            if (transform.position.y > maxYPosLimit)
                return;

            Vector3 force = transform.forward * forwardForce + transform.up * upForce;
            if(!IsExceedForceLimit(force))
            {
                totalForce += force;
                // Debug.Log(totalForce);
                rb.AddForce(force / rb.mass, ForceMode.Impulse);
                particleEffect.Play();
            }
        }

        private void StopMove()
        {
            Debug.Log("Stop");
            totalForce = Vector3.zero;
            particleEffect.Stop();
        }

        private bool IsExceedForceLimit(Vector3 force)
        {
            Vector3 tempTotalForce = totalForce + force;
            if (tempTotalForce.magnitude > maxForceLimit.magnitude)
                return true;
            return false;
        }

    }
}


