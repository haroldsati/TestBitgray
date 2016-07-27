using UnityEngine;
using DG.Tweening;

namespace Gameplay.Detail
{
    [System.Serializable]
    public class EnemyAnimator : CharacterAnimator
    {
        [SerializeField]
        private float velocity = 10;

        private Vector3 target;
        private Vector3 scale;
        private bool isPrepare = false;

        public void Initialize(Transform transform, Vector3 target)
        {
            base.Initialize(transform);
            this.target = target;
            isPrepare = true;
            transform.LookAt(target);
            AnimateScale(transform);
        }

        private void AnimateScale(Transform transform)
        {
            scale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(scale, 1).SetEase(Ease.Linear);
        }

        public void Update()
        {
            if(isPrepare)
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * velocity);
        }        
    }
}