using System;
using UnityEngine;

namespace Game.Managers
{

    public class InputManager : Singleton<InputManager>
    {
        public delegate void TapEvent();
        public delegate void HoldEvent();

        public TapEvent OnTap;
        public HoldEvent OnHold;

        private Touch touch;
        private Vector2 touchStartPosition, touchEndPosition;

        private void Update()
        {

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.Return)) // press enter key
            {
                Tap();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Hold();
            }
#endif


#if UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPosition = touch.position;
                }

                else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Hold();
                }

                else if (touch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = touch.position;

                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;

                    if (Mathf.Abs(x) <= 0 && Mathf.Abs(y) <= 0)
                    {
                        Tap();
                    }
                }
            }
#endif

        }

        private void Hold()
        {
            if (OnHold == null)
                return;

            Delegate[] calls = OnHold.GetInvocationList();
            foreach (Delegate call in calls)
            {
                ((HoldEvent)call).Invoke();
            }
        }

        private void Tap()
        {
            if (OnTap == null)
                return;

            Delegate[] calls = OnTap.GetInvocationList();
            foreach (Delegate call in calls)
            {
                ((TapEvent)call).Invoke();
            }
        }
    }
}

