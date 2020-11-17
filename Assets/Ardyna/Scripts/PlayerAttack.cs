using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.AmberSyndrome.Ardyna
{
    public class PlayerAttack : MonoBehaviour,IMessageReciever
    {
        [SerializeField] PlayerStatus playerStatus;

        [SerializeField] private Animator playerAnimator;

        [SerializeField] GameObject punchEfectPrefab;
        [SerializeField] GameObject punchEfectRoot;

        GameObject generatedPunchEfectPrefab;

        public void OnRecieve()
        {
            //Debug.Log("OnRecieve");
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

        public void PunchEffectGenerator()
        {

            generatedPunchEfectPrefab = Instantiate(punchEfectPrefab, punchEfectRoot.transform);
            Destroy(generatedPunchEfectPrefab, 2.0f);
        }

    }

}