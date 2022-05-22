using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class UseForm : UGuiForm
    {
        [SerializeField]
        Button YesBtn;
        [SerializeField]
        Button NoBtn;
        [SerializeField]
        Text InfoText;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            Item item = userData as Item;

            YesBtn.GetComponentInChildren<Text>().text = "��";
            NoBtn.GetComponentInChildren<Text>().text = "��";
            NoBtn.onClick.AddListener(() => { GameEntry.UI.CloseUIForm(this); });

            if (item != null) 
            {
                switch (item.dRItem.Type) 
                {
                    case 1:
                        InfoText.text = "�Ƿ�ʹ�õ��ߣ�";
                        break;
                    case 2:
                        InfoText.text = "�Ƿ����װ����";
                        break;
                }
            } 
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            YesBtn.onClick.RemoveAllListeners();
            NoBtn.onClick.RemoveAllListeners();
            base.OnClose(isShutdown, userData);
        }
    }
}
