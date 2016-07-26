using UnityEngine;
using Gameplay;

namespace UI.Detail
{ 
    public class UIObjectActivatorByGameState : MonoBehaviour
    {
        [SerializeField]
        private GameState stateToBeEnable;
        [SerializeField]
        private GameObject objectToAffect;

        public void Update()
        {
            if (GameControllerAcess.Access.State == stateToBeEnable)
                objectToAffect.SetActive(true);
            else
                objectToAffect.SetActive(false);
        }
    }
}