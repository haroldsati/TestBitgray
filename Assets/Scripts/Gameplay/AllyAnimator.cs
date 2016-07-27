using UnityEngine;
using System;
using DG.Tweening;

namespace Gameplay.Detail
{
    [Serializable]
    public class AllyAnimator : CharacterAnimator
    {
        [SerializeField]
        private HitDetector hitDetector;

        public override void Initialize(Transform transform)
        {
            base.Initialize(transform);
            AnimateIdle();
        }

        public void AnimateHit(Collider hit)
        {
            transform.DOKill();
            transform.DOShakePosition(1).OnComplete(AnimateIdle);

            switch (hitDetector.DetectPosition(hit))
            {
                case HitPosition.Back:
                    transform.DOShakeRotation(1, new Vector3(30, 0, 0));
                    break;
                case HitPosition.Rigth:
                    transform.DOShakeRotation(1, new Vector3(0, 0, 30));
                    break;
                case HitPosition.Left:
                    transform.DOShakeRotation(1, new Vector3(0, 0, -30));
                    break;
            }
        }

        private void AnimateIdle()
        {
            transform.DOShakePosition(30, 0.5f, 1).OnComplete(AnimateIdle);
        }
    }
}