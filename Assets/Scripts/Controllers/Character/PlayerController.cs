using System;
using Game.StateMachine.States;
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
        public FuelBar fuelBar;

        private Rigidbody rb;
        private Vector3 totalForce;
        private PlayerState playerState;
        private LevelState levelState;

        #region Monobehaviour Functions
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            levelState = FindObjectOfType<LevelState>();
            totalForce = Vector3.zero;
            playerState = PlayerState.STANDING;
        }

        private void FixedUpdate()
        {
            // bu kuşulun en üstte olmassı gerekli
            if (transform.position.y <= -1)
            {
                playerState = PlayerState.FALLING;
                levelState.GameOver(false);
            }

            else if (playerState == PlayerState.MOVING)
            {
                Move();
                fuelBar.BurnFuel();
            }

            else if(playerState == PlayerState.STANDING)
            {
                fuelBar.RefillFuel();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("platform"))
            {
                Stand();
            }

            else if (collision.gameObject.CompareTag("finishLine"))
            {
                Stand();
                levelState.GameOver(true);
            }
        }
        #endregion

        internal void IsMoving(bool isMoving)
        {
            if (isMoving)
                playerState = PlayerState.MOVING;

            else
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
                rb.AddForce(force, ForceMode.Impulse);
                if(!particleEffect.isPlaying)
                    particleEffect.Play();
            }

        }

        private void StopMove()
        {
            // Debug.Log("Stop");
            totalForce = Vector3.zero;
            particleEffect.Stop();
        }

        private void Stand()
        {
            // force yüzünden devrilip düşmesin diye
            rb.velocity = Vector3.zero;
            playerState = PlayerState.STANDING;
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


