using Game.Managers;
using Game.StateMachine;
using UnityEngine.SceneManagement;

namespace Game.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private IState currentState;
        private InputManager inputManager;
        private SceneType currentScene;

        private void Start()
        {
            inputManager = InputManager.Instance;
        }


        #region STATE MACHINE
        public void SetState(IState nextState)
        {
            if (currentState == nextState) return;
            if (currentState != null) currentState.Exit();

            currentState = nextState;
            nextState.Enter();
        }

        internal IState GetCurrentState()
        {
            return currentState;
        }

        #endregion


        internal void LoadScene(SceneType sceneToLoad)
        {
            currentScene = sceneToLoad;
            SceneManager.LoadScene((int)sceneToLoad);
        }

        #region Getters

        public SceneType GetCurrentScene()
        {
            return currentScene;
        }

        #endregion

    }
}
