﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2022-05-30 09:59:18.482
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    /// <summary>
    /// 消耗道具表。
    /// </summary>
    public class DRConsumeItem : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取道具id。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取消耗道具子id。
        /// </summary>
        public int SubId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取改变属性类型。
        /// </summary>
        public int PropType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取改变值。
        /// </summary>
        public int Value
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            SubId = int.Parse(columnStrings[index++]);
            PropType = int.Parse(columnStrings[index++]);
            Value = int.Parse(columnStrings[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    SubId = binaryReader.Read7BitEncodedInt32();
                    PropType = binaryReader.Read7BitEncodedInt32();
                    Value = binaryReader.Read7BitEncodedInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
