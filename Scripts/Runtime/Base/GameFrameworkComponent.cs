//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 游戏框架组件抽象类。
    /// </summary>
    public abstract class GameFrameworkComponent : MonoBehaviour
    {
        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected virtual void Awake()
        {
            GameEntry.RegisterComponent(this);
        }
    }

    public abstract class SingleGameFrameworkComponent<T> : GameFrameworkComponent where T : SingleGameFrameworkComponent<T> {
        
        private static T inst;

        protected override void Awake() {
            base.Awake();
            inst = GetComponent<T>();
        }
        
        public static T Inst() {
            if (inst) return inst;
            var parentObj = GameObject.Find("SingleGameFrameworkComponent");
            if (!parentObj) parentObj = new GameObject("SingleGameFrameworkComponent");
            return inst = parentObj.AddComponent<T>();
        }
    }
}
