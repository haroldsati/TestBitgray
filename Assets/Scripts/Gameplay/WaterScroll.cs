using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class WaterScroll : MonoBehaviour
    {
        [SerializeField]
        private float scrollSpeed = 0.1f;
        [SerializeField]
        private MeshRenderer myRenderer;

        private float offset = 0;

        private void Update()
        {
            offset += Time.deltaTime * scrollSpeed;
            myRenderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }
}