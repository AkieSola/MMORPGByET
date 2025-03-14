﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2022-05-30 09:59:18.462
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
    /// Enemy表。
    /// </summary>
    public class DREnemy : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取Enemy编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取组id。
        /// </summary>
        public int GroupId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取姓名。
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取等级。
        /// </summary>
        public int Lv
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取掉落Id。
        /// </summary>
        public int DropId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取AIId。
        /// </summary>
        public int AIId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大生命。
        /// </summary>
        public int MaxHp
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大Sp。
        /// </summary>
        public int MaxSp
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取先攻。
        /// </summary>
        public int Priority
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击力。
        /// </summary>
        public int Atk
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取法术强度。
        /// </summary>
        public int SpellAtk
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击距离。
        /// </summary>
        public int AtkDistance
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取物抗。
        /// </summary>
        public int PhysicsDfs
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取魔抗。
        /// </summary>
        public int SpellDfs
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能1Id。
        /// </summary>
        public int Skill1Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能2Id。
        /// </summary>
        public int Skill2Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能3Id。
        /// </summary>
        public int Skill3Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能4Id。
        /// </summary>
        public int Skill4Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能5Id。
        /// </summary>
        public int Skill5Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能6Id。
        /// </summary>
        public int Skill6Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能7Id。
        /// </summary>
        public int Skill7Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取技能8Id。
        /// </summary>
        public int Skill8Id
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
            GroupId = int.Parse(columnStrings[index++]);
            Name = columnStrings[index++];
            Lv = int.Parse(columnStrings[index++]);
            DropId = int.Parse(columnStrings[index++]);
            AIId = int.Parse(columnStrings[index++]);
            MaxHp = int.Parse(columnStrings[index++]);
            MaxSp = int.Parse(columnStrings[index++]);
            Priority = int.Parse(columnStrings[index++]);
            Atk = int.Parse(columnStrings[index++]);
            SpellAtk = int.Parse(columnStrings[index++]);
            AtkDistance = int.Parse(columnStrings[index++]);
            PhysicsDfs = int.Parse(columnStrings[index++]);
            SpellDfs = int.Parse(columnStrings[index++]);
            Skill1Id = int.Parse(columnStrings[index++]);
            Skill2Id = int.Parse(columnStrings[index++]);
            Skill3Id = int.Parse(columnStrings[index++]);
            Skill4Id = int.Parse(columnStrings[index++]);
            Skill5Id = int.Parse(columnStrings[index++]);
            Skill6Id = int.Parse(columnStrings[index++]);
            Skill7Id = int.Parse(columnStrings[index++]);
            Skill8Id = int.Parse(columnStrings[index++]);

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
                    GroupId = binaryReader.Read7BitEncodedInt32();
                    Name = binaryReader.ReadString();
                    Lv = binaryReader.Read7BitEncodedInt32();
                    DropId = binaryReader.Read7BitEncodedInt32();
                    AIId = binaryReader.Read7BitEncodedInt32();
                    MaxHp = binaryReader.Read7BitEncodedInt32();
                    MaxSp = binaryReader.Read7BitEncodedInt32();
                    Priority = binaryReader.Read7BitEncodedInt32();
                    Atk = binaryReader.Read7BitEncodedInt32();
                    SpellAtk = binaryReader.Read7BitEncodedInt32();
                    AtkDistance = binaryReader.Read7BitEncodedInt32();
                    PhysicsDfs = binaryReader.Read7BitEncodedInt32();
                    SpellDfs = binaryReader.Read7BitEncodedInt32();
                    Skill1Id = binaryReader.Read7BitEncodedInt32();
                    Skill2Id = binaryReader.Read7BitEncodedInt32();
                    Skill3Id = binaryReader.Read7BitEncodedInt32();
                    Skill4Id = binaryReader.Read7BitEncodedInt32();
                    Skill5Id = binaryReader.Read7BitEncodedInt32();
                    Skill6Id = binaryReader.Read7BitEncodedInt32();
                    Skill7Id = binaryReader.Read7BitEncodedInt32();
                    Skill8Id = binaryReader.Read7BitEncodedInt32();
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
