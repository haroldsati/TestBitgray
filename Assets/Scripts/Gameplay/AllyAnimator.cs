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
        [SerializeField]
        private Animation anim;

        private Vector3 localPosition;
        private Quaternion localRotation;
        private Vector3 localScale;

        public override void Initialize(Transform transform)
        {
            base.Initialize(transform);
            if(localScale == Vector3.zero)
            {
                localPosition = transform.localPosition;
                localRotation = transform.localRotation;
                localScale = transform.localScale;
            }
            else
            {
                transform.localPosition = localPosition;
                transform.localRotation = localRotation;
                transform.localScale = localScale;
            }

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
            transform.DOKill();
            transform.DOShakePosition(30, 0.5f, 1).OnComplete(AnimateIdle);
        }

        public void Fall()
        {
            transform.DOKill();
            anim.Play();
        }
    }
}