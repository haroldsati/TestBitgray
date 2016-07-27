using UnityEngine;
using DG.Tweening;

namespace Gameplay.Detail
{
    public class CharacterAnimator
    {
        protected Transform transform;

        public virtual void Initialize(Transform transform)
        {
            this.transform = transform;
        }

        public void Stop()
        {
            transform.DOKill();
        }
    }
}