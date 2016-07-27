using UnityEngine;

namespace Gameplay.Detail
{
    public class CharacterAnimator
    {
        protected Transform transform;

        public virtual void Initialize(Transform transform)
        {
            this.transform = transform;
        }
    }
}