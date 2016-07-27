using UnityEngine;
using System;

namespace UI.Detail
{
    [Serializable]
    public class ColorPerArea
    {
        [SerializeField]
        private Color color;
        [SerializeField]
        private float max;
        [SerializeField]
        private float min;

        public Color Color
        {
            get { return color; }
        }

        public bool IsInArea(float percent)
        {
            return percent >= min && percent <= max; 
        }
    }
}