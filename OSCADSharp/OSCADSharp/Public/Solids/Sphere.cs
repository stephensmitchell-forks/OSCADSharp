﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Reflection;

namespace OSCADSharp
{
    /// <summary>
    /// A Sphere geometry
    /// </summary>
    public class Sphere : OSCADObject
    {
        #region Attributes
        /// <summary>
        /// This is the radius of the sphere
        /// </summary>
        public double Radius { get; set; } = 1;

        /// <summary>
        /// This is the diameter of the sphere
        /// </summary>
        public double Diameter {
            get { return this.Radius * 2; }
            set { this.Radius = value / 2; }
        }
        
        /// <summary>
        /// Minimum angle (in degrees) of each cylinder fragment.
        /// ($fa in OpenSCAD)
        /// </summary>
        public int? MinimumAngle { get; set; }

        /// <summary>
        /// Fragment size in mm
        /// ($fs in OpenSCAD)
        /// </summary>
        public int? MinimumFragmentSize { get; set; }

        /// <summary>
        /// Number of fragments in 360 degrees. Values of 3 or more override MinimumAngle and MinimumCircumferentialLength
        /// ($fn in OpenSCAD)
        /// </summary>
        public int? Resolution { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a sphere with the default initialization values
        /// </summary>
        public Sphere()
        {
        }

        /// <summary>
        /// Creates a sphere of the specified diameter
        /// </summary>
        /// <param name="diameter">Diameter of the sphere</param>
        public Sphere(double diameter)
        {
            this.Diameter = diameter;
        }

        /// <summary>
        /// Creates a sphere with one more more pre-bound properties
        /// </summary>
        /// <param name="diameter"></param>
        /// <param name="resolution"></param>
        /// <param name="minimumAngle"></param>
        /// <param name="minimumFragmentSize"></param>
        public Sphere(Variable diameter = null, Variable resolution = null, Variable minimumAngle = null, Variable minimumFragmentSize = null)
        {
            this.BindIfVariableNotNull("diameter", diameter);
            this.BindIfVariableNotNull("resolution", resolution);
            this.BindIfVariableNotNull("minimumangle", minimumAngle);
            this.BindIfVariableNotNull("minimumfragmentsize", minimumFragmentSize);
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Converts this object to an OpenSCAD script
        /// </summary>
        /// <returns>Script for this object</returns>
        public override string ToString()
        {
            var scriptBuilder = new SphereScriptBuilder(this.bindings, this);
            return scriptBuilder.GetScript();
        }

        /// <summary>
        /// Gets a copy of this object that is a new instance
        /// </summary>
        /// <returns></returns>
        public override OSCADObject Clone()
        {
            return new Sphere()
            {
                Name = this.Name,
                Resolution = this.Resolution,
                MinimumAngle = this.MinimumAngle,
                MinimumFragmentSize = this.MinimumFragmentSize,
                Radius = this.Radius,
                bindings = this.bindings.Clone()
            };
        }

        /// <summary>
        /// Gets the position of this object's center (origin) in
        /// world space
        /// </summary>
        /// <returns></returns>
        public override Vector3 Position()
        {
            return new Vector3();
        }

        /// <summary>
        /// Returns the approximate boundaries of this OpenSCAD object
        /// </summary>
        /// <returns></returns>
        public override Bounds Bounds()
        {
            return new Bounds(new Vector3(-this.Radius, -this.Radius, -this.Radius), 
                              new Vector3(this.Radius, this.Radius, this.Radius));
        }

        private SphereBindings bindings = new SphereBindings();
        /// <summary>
        /// Binds a a variable to a property on this object
        /// </summary>
        /// <param name="property">A string specifying the property such as "Diameter" or "Radius"</param>
        /// <param name="variable">The variable to bind the to.  This variable will appear in script output in lieu of the 
        /// literal value of the property</param>
        public override void Bind(string property, Variable variable)
        {
            this.bindings.Bind<Sphere>(this, property, variable);
        }
        #endregion
    }
}
