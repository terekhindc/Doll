using System;
using UnityEngine;

namespace DollsSystem
{
    public class Player : MonoBehaviour
    {
        [HideInInspector] public BodyAnchor bodyAnchor;

        private void Awake()
        {
            bodyAnchor = GetComponent<BodyAnchor>();
        }
    }
}
