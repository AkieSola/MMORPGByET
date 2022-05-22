using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetPostprocessorTools : AssetPostprocessor
{
    /// <summary>
    /// ��Ƶ��Դ�������֮ǰ����
    /// </summary>
    private void OnPreprocessAudio()
    {
        AudioImporter _importer = (AudioImporter)assetImporter;
        _importer.preloadAudioData = true;
    }
    /// <summary>
    /// ��ģ�ͣ�.fbx��.mb�ļ��ȣ����붯��֮ǰ����
    /// </summary>
    private void OnPreprocessAnimation()
    {
        ModelImporter _importer = (ModelImporter)assetImporter;
    }
    /// <summary>
    /// ģ�͵���֮ǰ����
    /// </summary>
    private void OnPreprocessModel()
    {
        ModelImporter _importer = (ModelImporter)assetImporter;
    }

    /// <summary>
    /// ��Ƶ��Դ�������֮�����
    /// </summary>
    /// <param name="clip"></param>
    private void OnPostprocessAudio(AudioClip clip)
    {
        Debug.Log("������Ƶ��" + clip.name);
        AudioImporter _importer = (AudioImporter)assetImporter;
    }
    /// <summary>
    /// ģ�͵������֮�����
    /// </summary>
    /// <param name="g"></param>
    private void OnPostprocessModel(GameObject g)
    {
        Debug.Log("����ģ�ͣ�" + g.name);
    }
    /// <summary>
    /// ��������������֮�����
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="sprites"></param>
    private void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
    {
        Debug.Log("��������" + texture.name);
    }
    /// <summary>
    /// ���е���Դ�ĵ�����ɺ󶼻����
    /// </summary>
    /// <param name="importedAssets">������Դ·��</param>
    /// <param name="deletedAssets">ɾ����Դ·��</param>
    /// <param name="movedAssets">�ƶ���ԴĿ��·��</param>
    /// <param name="movedFromAssetPaths">�ƶ���ԴԴ·��</param>
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            Debug.Log("������Դ: " + str);
            if (str.EndsWith(".atlas"))
            {
                Debug.LogError("������������������������");
                if (File.Exists(str))
                {
                    File.Move(str, str + ".txt");
                    Debug.LogError("�޸ĳɹ�");
                }
            }
        }
        foreach (string str in deletedAssets)
        {
            Debug.Log("ɾ����Դ: " + str);
        }
        for (int i = 0; i < movedAssets.Length; i++)
        {
            Debug.Log("��:" + movedFromAssetPaths[i] + "���ƶ���Դ��:" + movedAssets[i]);
        }
    }
    /// <summary>
    /// �ú����������������֮�����
    /// </summary>
    /// <param name="texture"></param>
    private void OnPostprocessTexture(Texture2D texture)
    {
        Debug.Log("������ͼ��" + texture.name);
        Debug.Log("assetPath ��" + assetPath);
        TextureImporter textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
        if (textureImporter != null)
        {
            string AtlasName = new System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(assetPath)).Name;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Single;
            textureImporter.spritePackingTag = AtlasName;
            textureImporter.mipmapEnabled = false;
        }
    }
    /// <summary>
    /// �ú����������������֮ǰ����
    /// </summary>
    void OnPreprocessTexture()
    {

        //�Զ���������;
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;

        //�Զ����ô��tag;
        string dirName = System.IO.Path.GetDirectoryName(assetPath);
        Debug.Log("Import ---  " + dirName);
        string folderStr = System.IO.Path.GetFileName(dirName);
        Debug.Log("Set Packing Tag ---  " + folderStr);

        textureImporter.spritePackingTag = folderStr;
    }
}
