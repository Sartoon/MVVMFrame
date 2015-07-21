using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace MVVM
{

    public delegate void MessageHandler(uint iMessageType,object kParam);

    public class MessageArgs
    {
        public uint iMessageType;
        public object kParam;
    }

    public class MessageDispatcher :Singleton<MessageDispatcher>
    {
        //一个委托字典。
        Dictionary<uint, List<MessageHandler>> m_kMessageTable;
        //一个消息队列
        Queue<MessageArgs> _receiveMessageQueue;
        /// <summary>
        /// 进行单列的初始化
        /// </summary>
        public override void Init()
        {
            m_kMessageTable = new Dictionary<uint, List<MessageHandler>>();
            _receiveMessageQueue = new Queue<MessageArgs>();
            StartCoroutine(BeginHandleReceiveMessageQueue());
        }

        #region 消息分发
        /// <summary>
        /// 持续接收消息
        /// </summary>
        /// <returns></returns>
        private IEnumerator BeginHandleReceiveMessageQueue()
        {
            while (true)
            {
                yield return 0;
                lock (_receiveMessageQueue)
                {
                    while (_receiveMessageQueue.Count != 0)
                    {
                        MessageArgs args = _receiveMessageQueue.Dequeue();
                        DispatchMessage(args.iMessageType, args.kParam);
                    }
                }
            }
        }
        /// <summary>
        /// 分发消息，同步
        /// </summary>
        /// <param name="iMessageType">消息类型</param>
        /// <param name="kParam">附加参数</param>
        public void DispatchMessage(uint iMessageType, object kParam = null)
        {
            if (m_kMessageTable.ContainsKey(iMessageType))
            {
                List<MessageHandler> kHandlerLit = m_kMessageTable[iMessageType];
                for(int i=0;i<kHandlerLit.Count;i++)
                {
                    ((MessageHandler)kHandlerLit[i])(iMessageType,kParam);
                }
            }
        }

        /// <summary>
        /// 分发消息，异步，会在协程BeginHandleReceiveMessageQueue的下一次检查中进行真正的消息分发
        /// </summary>
        /// <param name="iMessageType">消息类型</param>
        /// <param name="kParam">附加参数</param>
        public void DispatchMessageAsync(uint iMessageType, object kParam = null)
        {
            lock (_receiveMessageQueue)
            {
                MessageArgs args = new MessageArgs()
                {
                    iMessageType = iMessageType,
                    kParam = kParam,
                };
                _receiveMessageQueue.Enqueue(args);
            }
        }

        #endregion

        #region 消息的注册与撤销
        public void RegisterMessageHandler(uint iMessageType, MessageHandler kHandler)
        {
            if (!m_kMessageTable.ContainsKey(iMessageType))
            {
                m_kMessageTable.Add(iMessageType, new List<MessageHandler>());
            }
            List<MessageHandler> khandlerList = m_kMessageTable[iMessageType];
            if (!khandlerList.Contains(kHandler))
            {
                khandlerList.Add(kHandler);
            }
        }

        public void UnRegisteMessageHandler(uint iMessageType, MessageHandler kHandler)
        {
            if (m_kMessageTable.ContainsKey(iMessageType))
            {
                List<MessageHandler> kHandlerList = m_kMessageTable[iMessageType];
                kHandlerList.Remove(kHandler);
            }
        } 
        #endregion
    }
}
