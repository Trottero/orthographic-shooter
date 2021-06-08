using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Behaviours
{
    public class MakeTransparantWhenBlocking : MonoBehaviour
    {
        private Collider _sourceCollider;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_sourceCollider != null)
            {
                // Check if the collider is still in the way.
                
            }
        }

        public void FadeOut(Collider collider)
        {
            _sourceCollider = collider;

            // Collider is the source of this event. We store it
            var renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (var meshRenderer in renderers)
            {
                var color = meshRenderer.material.color;
                color.a = 0.3f;
                meshRenderer.material.color = color;
            }
        }
    }
}
