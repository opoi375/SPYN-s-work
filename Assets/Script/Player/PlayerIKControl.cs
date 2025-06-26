using System;
using UnityEngine;

namespace Script.Player
{
    public class PlayerIKControl:MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private Transform leftHand;
        [SerializeField]
        private Transform rightHand;

        private void Awake()
        {
            Init();
        }
        
        public void Init()
        {
            if (!animator)
            {
                animator = GetComponentInChildren<Animator>();
            }

            if (!leftHand)
            {
                leftHand = GameObject.Find("L_Hand_IK").transform;
            }

            if (!rightHand)
            {
                rightHand = GameObject.Find("R_Hand_IK").transform;
            }
        }

        private void OnAnimatorIK(int layerIndex)
        {
            //设置IK位置
            IKControl(AvatarIKGoal.LeftHand, leftHand);
            IKControl(AvatarIKGoal.RightHand, rightHand);
            
        }

        private void IKControl(AvatarIKGoal goal,Transform target)
        {
            animator.SetIKPositionWeight(goal, 1.0f);
            animator.SetIKPosition(goal, target.position);
        }
        private void OnDestroy()
        {
            Clear();
        }

        public void Clear()
        {
            animator = null;
            leftHand = null;
            rightHand = null;
        }
    }
}