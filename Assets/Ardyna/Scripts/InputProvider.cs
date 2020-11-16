using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.InputSystem;
using System;
namespace com.AmberSyndrome.Ardyna
{


    public class InputProvider : MonoBehaviour, PlayerActionControll.IPlayerActions
    {

        PlayerActionControll.PlayerActions input;

        [SerializeField]
        Vector2ReactiveProperty direction;


        [SerializeField] MovePlayer move;
        [SerializeField] PlayerAttack playerAttack;

        void Awake()
        {
            // インプットを生成して、自身をコールバックとして登録
            input = new PlayerActionControll.PlayerActions(new PlayerActionControll());
            input.SetCallbacks(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            direction
                .Subscribe(_ => move.MoveHorizontal(direction.Value));

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnMove(InputAction.CallbackContext context)
        {
            // 押しっぱなしの動作は、直接オブジェクトを動かすのではなく方向性のみを登録する
            direction.Value = context.ReadValue<Vector2>();
        }


        // インプットの有効・無効化
        void OnDestroy() => input.Disable();
        void OnEnable() => input.Enable();

        public void OnAttack(InputAction.CallbackContext context)
        {
            //マウスクリックのアクションではInputActionsのinteractionsをPress Onlyにしても複数Phase分呼ばれるのでPerformedのみ動作するようにしている
            //泥臭いやり方なイメージなので他に解決策がありそう
            if (context.performed)
            {
                playerAttack.Attack();
            }
        }
    }

}