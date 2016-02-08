﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp.Scripting
{

    /// <summary>
    /// A statement that has multiple child nodes, whose ToString output
    /// is more or less just an aggregate of the children
    /// </summary>
    internal class BlockStatementObject : OSCADObject
    {
        private string outerStatement;
        private IEnumerable<OSCADObject> children;

        internal BlockStatementObject(string outerStatement, IEnumerable<OSCADObject> children)
        {
            this.outerStatement = outerStatement;
            this.children = children;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in this.children)
            {
                sb.Append(child.ToString());
            }

            var formatter = new BlockFormatter(this.outerStatement, sb.ToString());
            return formatter.ToString();
        }

        public override OSCADObject Clone()
        {
            List<OSCADObject> childClones = new List<OSCADObject>();
            foreach (var child in this.children)
            {
                childClones.Add(child.Clone());
            }

            return new BlockStatementObject(this.outerStatement, childClones);
        }
    }
}