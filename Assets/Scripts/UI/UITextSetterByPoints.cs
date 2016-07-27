using UnityEngine;
using System.Collections;
using Gameplay;

namespace UI.Detail
{
    public class UITextSetterByPoints : UITextSetter
    {
        private void Update()
        {
            string points = GameControllerAcess.Access.Points.ToString();
            UpdateText("Points: "+ points);
        }
    }
}
