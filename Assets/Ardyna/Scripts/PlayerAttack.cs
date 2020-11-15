using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.AmberSyndrome.Ardyna
{
    public class PlayerAttack : MonoBehaviour,IMessageReciever
    {
        [SerializeField] PlayerStatus playerStatus;
        public void OnRecieve()
        {
            Debug.Log("OnRecieve");
            playerStatus.CharacterAnimationStateEnum = CharacterAnimationStateEnum.Waiting;
        }
    }

}