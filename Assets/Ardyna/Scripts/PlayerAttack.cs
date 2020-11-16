using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.AmberSyndrome.Ardyna
{
    public class PlayerAttack : MonoBehaviour,IMessageReciever
    {
        [SerializeField] PlayerStatus playerStatus;

        [SerializeField] private Animator playerAnimator;

        public void OnRecieve()
        {
            Debug.Log("OnRecieve");
            playerStatus.CharacterAnimationStateEnum = CharacterAnimationStateEnum.Waiting;
        }


        public void Attack()
        {
            if (playerStatus.CharacterAnimationStateEnum == CharacterAnimationStateEnum.Waiting)
            {
                playerStatus.CharacterAnimationStateEnum = CharacterAnimationStateEnum.Attacking;
                playerAnimator.SetTrigger("Attack");
            }

        }
    }

}