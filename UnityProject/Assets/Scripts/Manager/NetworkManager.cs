using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

namespace LuaGame
{
    public class NetworkManager : MonoBehaviour {

        private static NetworkManager _instance = null;
        public static NetworkManager TouchInstance(ref GameObject go)
        {
            _instance = go.GetComponent<NetworkManager>();
            if (null == _instance)
            {
                _instance = go.AddComponent<NetworkManager>();
            }
            return _instance;
        }
        public static NetworkManager Instance
        {
            get { return _instance; }
        }


        private SocketClient socket;
        static Queue<KeyValuePair<int, ByteBuffer>> sEvents = new Queue<KeyValuePair<int, ByteBuffer>>();

        SocketClient SocketClient {
            get { 
                if (socket == null)
                    socket = new SocketClient();
                return socket;                    
            }
        }

        void Awake() {
            DontDestroyOnLoad(gameObject);
            SocketClient.OnRegister();
        }

        void OnDestroy()
        {
            SocketClient.OnRemove();
            Debug.Log("~NetworkManager was destroy");
        }
        /// <summary>
        /// SendConnect
        /// </summary>
        public void SendConnect(string ip,int port) {
            SocketClient.ConnectServer(ip, port);
        }

        /// <summary>
        /// SendMessage
        /// </summary>
        public void SendMessage(ByteBuffer buffer) {
            SocketClient.SendMessage(buffer);
        }

        public bool IsConnected
        {
            get
            {
                return socket != null && socket.IsConnected;
            }
        }

        public static void AddEvent(int _event, ByteBuffer data)
        {
            sEvents.Enqueue(new KeyValuePair<int, ByteBuffer>(_event, data));
        }

        /// <summary>
        /// 交给Command，这里不想关心发给谁。
        /// </summary>
        void Update()
        {
            if (sEvents.Count > 0)
            {
                while (sEvents.Count > 0)
                {
                    KeyValuePair<int, ByteBuffer> _event = sEvents.Dequeue();
                    LuaState l = LuaScriptMgr.Instance.lua;
                    LuaFunction func = l.GetFunction("OnReceiveMessage");
                    if (null != func)
                    {
                        func.Call(_event.Key, _event.Value);
                        func.Dispose();
                    }
                }
            }
        }

        public void ConnectToServer(string host,int port,ByteBuffer login_msg)
        {
            SocketClient.ConnectToServer(host, port, login_msg.ToBytes());
            login_msg.Close();
        }
    }
}