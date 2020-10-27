using System;
using Game.Controllers.Character;
using Game.Managers;
using TMPro;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class LevelState : MonoBehaviour, IState
    {
        public PlayerController player;
        public TextMeshProUGUI startToTapText; 

        private InputManager inputManager;
        private bool isLevelStarted;

        private void OnEnable()
        {
            GameManager.Instance.SetState(this);
            isLevelStarted = false;
        }

        public void Enter()
        {
            inputManager = InputManager.Instance;
            inputManager.OnTap += OnTap;
            inputManager.OnHold += OnHold;
            inputManager.OnRelease += OnRelease;
        }

        public void Exit()
        {
            inputManager.OnHold -= OnHold;
            inputManager.OnRelease -= OnRelease;
        }


        private void OnTap()
        {
            if(!isLevelStarted)
            {
                inputManager.OnTap -= OnTap;
                isLevelStarted = true;
                startToTapText.gameObject.SetActive(false);
            }
        }


        private void OnHold()
        {
            if(isLevelStarted)
                player.IsMoving(true);
        }

        private void OnRelease()
        {
            if(isLevelStarted)
                player.IsMoving(false);
        }

        internal void GameOver(bool isWin)
        {
            // todo
            Debug.Log("Game over: does player won?" + isWin);
        }
    }
}
