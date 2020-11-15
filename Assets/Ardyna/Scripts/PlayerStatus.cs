using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.AmberSyndrome.Ardyna
{

    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] CharacterAnimationStateEnum characterAnimationStateEnum;

        internal CharacterAnimationStateEnum CharacterAnimationStateEnum { get => characterAnimationStateEnum; set => characterAnimationStateEnum = value; }
    }

}