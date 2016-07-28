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
        private float shake = 0.1f;
        [SerializeField]
        private Animation anim;

        private Vector3 localPosition;
        private Quaternion localRotation;
        private Vector3 localScale;

        public override void Initialize(Transform transform)
        {
            base.Initialize(transform);
            Stop();
            SetUpInitialInfo(transform);
            AnimateIdle();
        }

        private void SetUpInitialInfo(Transform transform)
        {
            if (localScale == Vector3.zero)
                SaveInitialInfo(transform);
            else
                ApplyInitialInfo(transform);
        }

        private void ApplyInitialInfo(Transform transform)
        {
            transform.localPosition = localPosition;
            transform.localRotation = localRotation;
            transform.localScale = localScale;
        }

        private void SaveInitialInfo(Transform transform)
        {
            localPosition = transform.localPosition;
            localRotation = transform.localRotation;
            localScale = transform.localScale;
        }

        public void AnimateHit(Collider hit)
        {
            transform.DOKill();
            transform.DOShakePosition(1, shake).OnComplete(AnimateIdle);

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
            transform.DOShakePosition(30, shake/2, 1).OnComplete(AnimateIdle);
        }

        public void Fall()
        {
            transform.DOKill();
            anim.Play();
        }

        public override void Stop()
        {
            base.Stop();
            anim.Stop();
        }
    }
}