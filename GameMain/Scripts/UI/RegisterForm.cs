using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class RegisterForm : UGuiForm
    {
        [SerializeField]
        Text RegisterTitle;
        [SerializeField]
        InputField AccountInput;
        [SerializeField]
        Text AccountTitle;
        [SerializeField]
        InputField PasswordInput;
        [SerializeField]
        Text PasswordTitle;
        [SerializeField]
        Button ReturnLoginButton;
        [SerializeField]
        Button RegisterButton;

        private ProcedureLogin m_ProcedureLogin;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

             m_ProcedureLogin = (ProcedureLogin)userData;

            RegisterTitle.text = "ע  ��";
            AccountTitle.text = "�˺�";
            PasswordTitle.text = "����";
            AccountInput.text = "��������ע����˺�...";
            PasswordInput.text = "��������ע�������...";
            ReturnLoginButton.GetComponentInChildren<Text>().text = "���ص�¼";
            RegisterButton.GetComponentInChildren<Text>().text = "ȷ��ע��";
            ReturnLoginButton.onClick.AddListener(OnReturnLoginBtnClicked);
            RegisterButton.onClick.AddListener(OnRegisterBtnClicked);
        }

        private void OnReturnLoginBtnClicked() 
        {
            GameEntry.UI.OpenUIForm(UIFormId.LoginForm, m_ProcedureLogin);
            this.Close();
        }

        private void OnRegisterBtnClicked()
        {
            if(AccountInput.text == "��������ע����˺�...") 
            {
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "������Ҫע����˺�"
                });
            }
            else if(PasswordInput.text == "��������ע�������...") 
            {
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "��������������"
                });
            }
            else if(m_ProcedureLogin.accountDic.ContainsKey(AccountInput.text))
            {
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "���˺��ѱ�ע��"
                });
            }
            else 
            {
                m_ProcedureLogin.accountDic.Add(AccountInput.text, PasswordInput.text);
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Message = "ע��ɹ�!",
                    OnClickConfirm = (o) => 
                    {
                        GameEntry.UI.OpenUIForm(UIFormId.LoginForm, m_ProcedureLogin);
                        GameEntry.UI.CloseUIForm(this);
                    }
                });
            }
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            ReturnLoginButton.onClick.RemoveAllListeners();
            RegisterButton.onClick.RemoveAllListeners();
            base.OnClose(isShutdown, userData);
        }
    }
}
