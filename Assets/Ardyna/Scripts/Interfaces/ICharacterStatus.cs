using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.AmberSyndrome.Ardyna
{
    public interface ICharacterStatus
    {
        CharacterAnimationStateEnum CharacterAnimationStateEnum { get; set; }

        int HP { get; set; }
    }
}

