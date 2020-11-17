using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.AmberSyndrome.Ardyna
{

    public class EnemyStatus : MonoBehaviour, ICharacterStatus
    {
        [SerializeField] CharacterAnimationStateEnum characterAnimationStateEnum;

        public CharacterAnimationStateEnum CharacterAnimationStateEnum { get => characterAnimationStateEnum; set => characterAnimationStateEnum = value; }

        [SerializeField] private int hp;
        public int HP { get => hp; set => hp = value; }
    }
}