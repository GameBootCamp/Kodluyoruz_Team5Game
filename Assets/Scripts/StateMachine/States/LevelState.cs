using Game.Managers;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class PlayState : MonoBehaviour, IState
    {
        public CharacterMovement character;

        private InputManager inputManager;


        private void OnEnable()
        {
            GameManager.Instance.SetState(this);
            inputManager = InputManager.Instance;
        }

        public void Enter()
        {
            inputManager.OnHold += OnHold;
        }

        public void Exit()
        {
            inputManager.OnHold -= OnHold;
        }

        private void OnHold()
        {
            character.Fly();
        }

    }
}
