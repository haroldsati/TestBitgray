using UnityEngine;
using UnityEngine.UI;
using Gameplay;
using System.Collections.Generic;

namespace UI.Detail
{
    public class UIAllyHealth : MonoBehaviour
    {
        [SerializeField]
        private List<ColorPerArea> colors;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private float HealthPercent
        {
            get { return GameControllerAcess.Access.AllyHealth; }
        }

        private void Update()
        {
            image.fillAmount = HealthPercent;
            image.color = ChooseColor();
        }

        private Color ChooseColor()
        {
            ColorPerArea color = colors.Find(c => c.IsInArea(HealthPercent));
            return color.Color;
        }
    }
}