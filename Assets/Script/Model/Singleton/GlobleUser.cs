using UnityEngine;
using System.Collections;
using protocol;
namespace MVVM
{
    public class GlobleUser:Singleton<GlobleUser>
    {
        #region Prop
        private string _userId;
        public string UserId
        {
            get { return _userId; }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
        }

        private bool _isLogin = false;
        public bool IsLogin
        {
            get { return _isLogin; }
        }

        private int _headIndex;
        public int HeadIndex
        {
            get { return _headIndex; }
        }

        public bool IsEnterMainMenu
        {
            get { return PlayerPrefs.HasKey(GlobalVars.PREF_USER_PASSWORD); }
        }

        public UserItem Self
        {
            get { return new UserItem { userName = _userName, userId = _userId, headIndex = _headIndex }; }
        }

        #endregion
        #region LifeCycle
        public override void Init()
        {
            MessageDispatcher.GetInstance().RegisterMessageHandler((uint)ENetworkMessage.GET_PERSONALINFO_RSP, OnGetPersonalInfoRsp);
            MessageDispatcher.GetInstance().RegisterMessageHandler((uint)ENetworkMessage.LOGIN_RSP, OnLoginRsp);
            MessageDispatcher.GetInstance().RegisterMessageHandler((uint)ENetworkMessage.PERSONALSETTINGS_RSP, OnPersonalSetRsp);
            MessageDispatcher.GetInstance().RegisterMessageHandler((uint)ENetworkMessage.LOGOUT_RSP, OnLogOutRsp);
            MessageDispatcher.GetInstance().RegisterMessageHandler((uint)EModelMessage.SOCKET_CONNECTED, TryLoginWithPref);
            MessageDispatcher.GetInstance().RegisterMessageHandler((uint)ENetworkMessage.OFFLINE_SYNC, OnOffLineSync);
            if (PlayerPrefs.HasKey(GlobalVars.PREF_USER_ID))
            {
                _userId = PlayerPrefs.GetString(GlobalVars.PREF_USER_ID);
            }
            LoadUserInfo();
        }
        #endregion
        #region Login
        
        #endregion
        #region MessageHandler
        
        #endregion
        #region LocalData
        public void LoadUserInfo()
        {
            UserItem userItem = IOTool.DeserializeFromString<UserItem>(PlayerPrefs.GetString(GlobalVars.PREF_USER_ITEM));
            _headIndex = userItem.headIndex;
            _userName = userItem.userName;
        }
        #endregion
    }
}
