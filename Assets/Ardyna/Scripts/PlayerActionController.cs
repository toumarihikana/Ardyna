using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.AmberSyndrome.Ardyna
{

    public class PlayerActionController : MonoBehaviour, PlayerActionControll.IPlayerActions
    {
        PlayerActionControll.PlayerActions input;

        [SerializeField] MovePlayer move;
        Vector2 direction;

        void Awake()
        {
            // インプットを生成して、自身をコールバックとして登録
            input = new PlayerActionControll.PlayerActions(new PlayerActionControll());
            input.SetCallbacks(this);
        }

        // インプットの有効・無効化
        void OnDestroy() => input.Disable();
        void OnEnable() => input.Enable();


        void OnDisable() => input.Disable();
        void Update() => move.MoveHorizontal(direction);


        public void OnMove(InputAction.CallbackContext context)
        {
            // 押しっぱなしの動作は、直接オブジェクトを動かすのではなく方向性のみを登録する
            direction = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}