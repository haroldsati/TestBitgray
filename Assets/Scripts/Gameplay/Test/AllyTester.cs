using UnityEngine;
using System.Collections;

namespace Gameplay.Detail
{
    public class AllyTester : MonoBehaviour
    {
        [SerializeField]
        private Ally ally;

        private void Start()
        {
            ally.Play(null);
        }
    }
}

