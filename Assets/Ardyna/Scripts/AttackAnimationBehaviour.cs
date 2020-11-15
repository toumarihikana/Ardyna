using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace com.AmberSyndrome.Ardyna
{
    public class AttackAnimationBehaviour : StateMachineBehaviour
    {
        [SerializeField] GameObject playerAttack;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //初回だけplayerAttackを探す
            //(StateMachineBehaviourはSilializeFieldしてもヒエラルキーからアタッチできないため(Prefabならできる))
            if (playerAttack == null)
            {
                playerAttack = GameObject.FindGameObjectWithTag("Player");
            }
            // インターフェースを継承しているコンポーネントのメソッドを呼び出し
            ExecuteEvents.Execute<IMessageReciever>(
                target: playerAttack, // 呼び出す対象のオブジェクト
                eventData: null,  // イベントデータ（モジュール等の情報）
                functor: (reciever, eventData) => reciever.OnRecieve()); // 操作
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }

}