using UnityEngine;

namespace Gameplay.Detail
{
    public class EnemyInput
    {
        private Collider collider;

        public void Initialize(Collider collider)
        {
            this.collider = collider;
        }

        public bool WasTouched()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
                return ProcessInput(Input.mousePosition);
#endif

#if UNITY_ANDROID
            if(Input.touchCount > 0)
            {
                foreach(Touch touch in Input.touches)
                    if (ProcessInput(touch.position))
                        return true;
                return false;
            }
#endif
            return false;
        }

        private bool ProcessInput(Vector2 screenPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit hit;
            return collider.Raycast(ray, out hit, 1000.0F);
        }
    }
}