using System;
using Game.Controllers.Character;
using Game.Managers;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class LevelState : MonoBehaviour, IState
    {
        public PlayerController player;

        private InputManager inputManager;

        private void OnEnable()
        {
            GameManager.Instance.SetState(this);
        }

        public void Enter()
        {
            inputManager = InputManager.Instance;
            inputManager.OnHold += OnHold;
            inputManager.OnRelease += OnRelease;
        }

        public void Exit()
        {
            inputManager.OnHold -= OnHold;
            inputManager.OnRelease -= OnRelease;
        }

        private void OnHold()
        {
            player.IsMoving(true);
        }

        private void OnRelease()
        {
            player.IsMoving(false);
        }

        internal void GameOver(bool isWin)
        {
            // todo
            Debug.Log("Game over: does player won?" + isWin);
        }
    }
}
