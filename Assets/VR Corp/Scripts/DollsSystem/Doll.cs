using System;
using UnityEngine;

namespace DollsSystem
{
    public class Doll : MonoBehaviour
    {
        public BodyAnchor playerBodyAnchor;
        private BodyAnchor _dollBodyAnchor;
        private Animator _animator;

        public float distance;

        public bool isMirror;

        private void Start()
        {
            _animator = GetComponent<Animator>();

            transform.position = playerBodyAnchor.transform.position + (Vector3.forward*distance);
            if (isMirror) transform.rotation *= Quaternion.Euler(0,180,0);

            Transform doll = Instantiate(playerBodyAnchor.transform, transform);
            doll.name = "DollAnchors";
            _dollBodyAnchor = doll.GetComponent<BodyAnchor>();
        }

        private void OnAnimatorIK (int layerIndex)
        {
            for (int i = 0; i < playerBodyAnchor.anchors.Length; i++)
            {
                _dollBodyAnchor.anchors[i].localPosition = playerBodyAnchor.anchors[i].localPosition;
                _dollBodyAnchor.anchors[i].localRotation = playerBodyAnchor.anchors[i].localRotation;
            }

            _animator.SetLookAtWeight(1);
            _animator.SetLookAtPosition(_dollBodyAnchor.head.position);

            _animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
            _animator.SetIKHintPosition(AvatarIKHint.LeftElbow, _dollBodyAnchor.leftElbow.position);
            
            _animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);
            _animator.SetIKHintPosition(AvatarIKHint.RightElbow, _dollBodyAnchor.rightElbow.position);
            
            _animator.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, 1);
            _animator.SetIKHintPosition(AvatarIKHint.LeftKnee, _dollBodyAnchor.leftKnee.position);
            
            _animator.SetIKHintPositionWeight(AvatarIKHint.RightKnee, 1);
            _animator.SetIKHintPosition(AvatarIKHint.RightKnee, _dollBodyAnchor.rightKnee.position);
            
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _dollBodyAnchor.leftHand.position);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _dollBodyAnchor.leftHand.rotation);
            
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, _dollBodyAnchor.rightHand.position);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _dollBodyAnchor.rightHand.rotation);
            
            _animator.SetBoneLocalRotation(HumanBodyBones.Spine, _dollBodyAnchor.body.localRotation);
        }
    }
}
