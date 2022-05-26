using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

public class DialogueNode : Node
{
    [LabelText("˵����")] public string speaker;
    [PreviewField(Alignment = ObjectFieldAlignment.Left), LabelText("ͷ��")]
    public Sprite head;
    [TextArea, LabelText("˵������")] public List<string> contents;
    [Input(ShowBackingValue.Never), LabelText("��һ��")] public string pre;

    [LabelText("��һ����")] public NextType nextType;

    [ShowIf("nextType", NextType.Dialogue), Output, LabelText("��һ�ζԻ�")]
    public DialogueNode nextDialogue;
    [ShowIf("nextType", NextType.Branch), Output, LabelText("��һ�η�֧")]
    public BranchNode nextBranch;
    [ShowIf("nextType", NextType.Flag), Output, LabelText("��һ�α��")]
    public FlagNode nextFlag;
    [Output, LabelText("�����¼�")] public EventNode trigger;
    //��һ���ڵ�����
    public enum NextType
    {
        [LabelText("�Ի���")] Dialogue,
        [LabelText("��֧��")] Branch,
        [LabelText("��ǿ�")] Flag
    }
    //���������ִ����� �����ӽ�������ʱʹ��
    private Dictionary<NextType, string> singleDt = new Dictionary<NextType, string>(){
        {NextType.Dialogue, nameof(nextDialogue)},
        {NextType.Branch, nameof(nextBranch)},
        {NextType.Flag, nameof(nextFlag)}
    };

    protected override void Init()
    {
        base.Init();
    }

    public override object GetValue(NodePort port)
    {
        return null;
    }

    //��ֵ����ʱ ���༭���£�
    private void OnValidate()
    {
        //�л���һ�����͵�ѡ��ʱ �������ӵĽڵ��������
        foreach (var s in singleDt)
        {
            if (nextType != s.Key)
            {
                GetPort(s.Value).ClearConnections();
            }
        }
    }

    public override void OnCreateConnection(NodePort from, NodePort to)
    {
        //�޶����ӽڵ�����
        if (Outputs.Contains(from))
        {
            if (from.ValueType != to.node.GetType())
            {
                Debug.LogError("���ܽ�" + from.ValueType + "�˿����ӵ�" + to.node.GetType() + "�ڵ㣡");
                GetPort(from.fieldName).Disconnect(to);
            }
        }
    }
}
