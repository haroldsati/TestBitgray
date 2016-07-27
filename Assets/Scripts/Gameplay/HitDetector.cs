using UnityEngine;
using System;
using System.Collections.Generic;

namespace Gameplay.Detail
{
    public enum HitPosition
    {
        Rigth = 0,
        Left = 1,
        Back = 2
    }

    [Serializable]
    public class HitDetector
    {
        [SerializeField]
        private List<Collider> rigth;
        [SerializeField]
        private List<Collider> left;
        [SerializeField]
        private List<Collider> back;

        public HitPosition DetectPosition(Collider collider)
        {
            if (rigth.Find(c => c == collider) != null)
                return HitPosition.Rigth;
            if (left.Find(c => c == collider) != null)
                return HitPosition.Left;
            return HitPosition.Back;
        }
    }
}