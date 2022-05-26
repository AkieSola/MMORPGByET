using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public static class NodeTool
{
    /// <summary>
    /// ��ȡ�˿����ӵ��ֵ
    /// </summary>
    /// <param name="node"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static Node GetNodeByField(this Node node, string fieldName)
    {
        if (!node.HasPort(fieldName))
        {
            Debug.LogWarning("������ " + fieldName + " �˿ڣ�");
            return null;
        }

        var port = node.GetPort(fieldName);
        if (!port.IsConnected)
        {
            Debug.LogWarning(fieldName + "�˿�δ���ӣ�");
            return null;
        }
        return port.Connection.node;
    } 
    /// <summary>
    /// ��ȡ�˿����Ե�ֵ
    /// </summary>
    /// <param name="node"></param>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public static object GetValuesByField(this Node node,string fieldName)
    {
        return node.GetType().GetField(fieldName).GetValue(node);
    }
}
