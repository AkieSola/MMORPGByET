using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public enum DialogEventType
{
	Nothing = 0,
	ShiftToBattle = 1,
}

public class EventNode : Node
{
	[Input(ShowBackingValue.Never), LabelText("����ǰ��")]
	public string trigger;
	[ShowInInspector, LabelText("�¼�����")]
	public DialogEventType eventType;

	public override object GetValue(NodePort port)
	{
		return null;
	}
}
