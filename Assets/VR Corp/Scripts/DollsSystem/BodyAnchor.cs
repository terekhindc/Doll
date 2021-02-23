using System;
using UnityEngine;

namespace DollsSystem
{
    public class BodyAnchor : MonoBehaviour
    {
        public Transform head;
        public Transform body;
        public Transform rightElbow;
        public Transform leftElbow;
        public Transform rightHand;
        public Transform leftHand;
        public Transform rightKnee;
        public Transform leftKnee;

        [HideInInspector]public Transform[] anchors;
        public bool isVisible;

        private void Awake()
        {
            anchors = new Transform [8]
            {
                head, body, rightElbow, leftElbow, rightHand, leftHand, rightKnee, leftKnee
            };

            if (!isVisible)
            {
                foreach (Transform anchor in anchors)
                {
                    anchor.GetComponent<MeshRenderer>().enabled = false;
                }
            } 
        }
    }


    public enum Anchors : int
    {
        Head = 0,
        Body = 1,
        RightElbow = 2,
        LeftElbow = 3,
        RightHand = 4,
        LeftHand = 5,
        RightKnee = 6,
        LeftKnee = 7
    }
}
