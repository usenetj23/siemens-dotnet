﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMC.Siemens.Common.PLC
{
    public abstract class Block : IParsableSource
    {
        protected abstract string DataHeader { get; }

        public BlockType Type { get; set; }
        public ProgramLanguage ProgramLanguage { get; set; }

        private int _Number;
        public int Number
        {
            get
            {
                return this._Number;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number", "Block Number cannot be negative");
                }
                this._Number = value;
            }
        }

        public string Name { get; set; }
        public string Version { get; set; }

        public ProjectFolder ParentFolder { get; set; }

        public Symbol Symbol
        {
            get
            {
                //if (ParentFolder != null)
                //{
                //    ISymbolTable tmp = ((IProgrammFolder)ParentFolder.ParentFolder).SymbolTable;
                //    if (tmp != null)
                //        return tmp.GetEntryFromOperand(BlockName);
                //}
                return null;
            }
        }


        public virtual string BlockName
        {
            get
            {
                return this.Type.ToString().Replace("S5_", "") + this.Number.ToString();
            }
        }

        public abstract IParsableSource ParseSource(TextReader reader);

    }
}
