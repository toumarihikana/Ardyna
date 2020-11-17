using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace com.AmberSyndrome.Ardyna
{

public class PlayerEffectProvider : MonoBehaviour
{
        [SerializeField] GameObject character;
        void PunchEffectCall()
        {
            // インターフェースを継承しているコンポーネントのメソッドを呼び出し
            ExecuteEvents.Execute<IMessageReciever>(
                target: character, // 呼び出す対象のオブジェクト
                eventData: null,  // イベントデータ（モジュール等の情報）
                functor: (reciever, eventData) => reciever.PunchEffectGenerator()); // 操作
        }
    }
}
