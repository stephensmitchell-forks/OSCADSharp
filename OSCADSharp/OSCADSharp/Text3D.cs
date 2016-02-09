﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp
{
    /// <summary>
    /// Create text using fonts installed on the local system or provided as separate font file.
    /// </summary>
    public class Text3D : OSCADObject
    {
        /// <summary>
        /// Text to display
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The generated text will have approximately an ascent of the given value (height above the baseline). Default is 10.
        /// Note that specific fonts will vary somewhat and may not fill the size specified exactly, usually slightly smaller.
        /// </summary>
        public uint Size { get; set; }

        /// <summary>
        /// The name of the font that should be used. This is not the name of the font file, 
        /// but the logical font name (internally handled by the fontconfig library). This can also include a style parameter, see below. 
        /// A list of installed fonts & styles can be obtained using the font list dialog (Help -> Font List).
        /// </summary>
        public string Font { get; set; }

        /// <summary>
        /// The horizontal alignment for the text. Possible values are "left", "center" and "right". Default is "left".
        /// </summary>
        /// TODO: Implement alignments
        public string HorizontalAlignment { get; set; }

        /// <summary>
        /// The vertical alignment for the text. Possible values are "top", "center", "baseline" and "bottom". Default is "baseline".
        /// </summary>
        /// TODO: Implement alignments
        // public string VerticalAlignment { get; set; }

        /// <summary>
        /// Factor to increase/decrease the character spacing. The default value of 1 will result in the normal spacing for the font, giving a value greater than 1 will cause the letters to be spaced further apart.
        /// </summary>
        public uint Spacing { get; set; }

        /// <summary>
        /// Direction of the text flow. Possible values are "ltr" (left-to-right), "rtl" (right-to-left), "ttb" (top-to-bottom) and "btt" (bottom-to-top). Default is "ltr".
        /// </summary>
        public string TextDirection { get; set; }

        /// <summary>
        /// The language of the text. Default is "en".
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Used for subdividing the curved path segments provided by freetype
        /// ($fn in OpenSCAD)
        /// </summary>
        public int Resolution { get; set; } = 0;

        public override OSCADObject Clone()
        {
            throw new NotImplementedException();
        }

        private void appendValueIfExists(string name, string value, StringBuilder sb)
        {
            if(!String.IsNullOrEmpty(value))
            {
                sb.Append(name);
                sb.Append("=");
                sb.Append(value);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("text(");
            sb.Append("\"");
            sb.Append(this.Text);
            sb.Append("\"");

            appendValueIfExists("font", this.Font, sb);
            sb.Append(");");

            return base.ToString();
        }
    }
}