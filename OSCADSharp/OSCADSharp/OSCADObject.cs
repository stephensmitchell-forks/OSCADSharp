﻿using OSCADSharp.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCADSharp
{
    public abstract class OSCADObject
    {
        #region Transforms
        /// <summary>
        /// Applies Color and/or Opacity to this object
        /// </summary>
        /// <param name="colorName">The name of the color to apply</param>
        /// <param name="opacity">The opacity from 0.0 to 1.0</param>
        /// <returns>A colorized object</returns>
        public OSCADObject Color(string colorName, double opacity = 1.0)
        {
            return new ColoredObject(this, colorName, opacity);
        }        

        /// <summary>
        /// Mirrors the object about a plane, as specified by the normal
        /// </summary>
        /// <param name="normal">The normal vector of the plane intersecting the origin of the object,
        /// through which to mirror it.</param>
        /// <returns>A mirrored object</returns>
        public OSCADObject Mirror(Vector3 normal)
        {
            return new MirroredObject(this, normal);
        }

        /// <summary>
        /// Mirrors the object about a plane, as specified by the normal
        /// described by the x/y/z components provided
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>A mirrored object</returns>
        public OSCADObject Mirror(double x, double y, double z)
        {
            return this.Mirror(new Vector3(x, y, z));
        }

        /// <summary>
        /// Resizes to a specified set of X/Y/Z dimensions
        /// </summary>
        /// <param name="newsize">The X/Y/Z dimensions</param>
        /// <returns>A resized object</returns>
        public OSCADObject Resize(Vector3 newsize)
        {
            return new ResizedObject(this, newsize);
        }

        /// <summary>
        /// Resizes to a specified set of X/Y/Z dimensions
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>A resized object</returns>
        public OSCADObject Resize(double x, double y, double z)
        {
            return this.Resize(new Vector3(x, y, z));
        }

        /// <summary>
        /// Rotates about a specified X/Y/Z euler angle
        /// </summary>
        /// <param name="angle">The angle(s) to rotate</param>
        /// <returns>A rotated object</returns>
        public OSCADObject Rotate(Vector3 angle)
        {
            return new RotatedObject(this, angle);
        }

        /// <summary>
        /// Rotates about a specified X/Y/Z euler angle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>A rotated object</returns>
        public OSCADObject Rotate(double x, double y, double z)
        {
            return this.Rotate(new Vector3(x, y, z));
        }

        /// <summary>
        /// Rescales an object by an X/Y/Z scale factor
        /// </summary>
        /// <param name="scale">The scale to apply. For example 1, 2, 1 would yield 2x scale on the Y axis</param>
        /// <returns>A scaled object</returns>
        public OSCADObject Scale(Vector3 scale)
        {
            return new ScaledObject(this, scale);
        }

        /// <summary>
        /// Rescales an object by an X/Y/Z scale factor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>A scaled object</returns>
        public OSCADObject Scale(double x, double y, double z)
        {
            return this.Scale(new Vector3(x, y, z));
        }

        /// <summary>
        /// Translates an object by the specified amount
        /// </summary>
        /// <param name="translation">The vector upon which to translate (move object(s))</param>
        /// <returns>A translated object</returns>
        public OSCADObject Translate(Vector3 translation)
        {
            return new TranslatedObject(this, translation);
        }

        /// <summary>
        /// Translates an object by the specified amount
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>A translated object</returns>
        public OSCADObject Translate(double x, double y, double z)
        {
            return this.Translate(new Vector3(x, y, z));
        }
        #endregion
    }
}
