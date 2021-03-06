﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSCADSharp.Utility;
using OSCADSharp.Spatial;
using OSCADSharp.Solids;

namespace OSCADSharp.UnitTests
{
    [TestClass]
    public class CubeTests
    {
        [TestMethod]
        public void Cube_LengthWidthHeightAffectSizeVector()
        {
            const double length = 10;
            const double width = 7;
            const double height = 9;

            var cube = new Cube(length, width, height);

            Assert.AreEqual(length, cube.Size.X);
            Assert.AreEqual(width, cube.Size.Y);
            Assert.AreEqual(height, cube.Size.Z);
        }

        [TestMethod]
        public void Cube_SizeAppearsInOutput()
        {
            var cube = new Cube(new Vector3(1.5, 5.5, 8.7));

            string script = cube.ToString();

            Assert.IsTrue(script.Contains(String.Format("size = [{0}, {1}, {2}]", 1.5, 5.5, 8.7)));
        }

        [TestMethod]
        public void Cube_CloneYieldsSameScript()
        {
            var cube = new Cube(new Vector3(1.5, 5.5, 8.7));

            var clone = cube.Clone();

            Assert.IsTrue(clone.IsSameAs(cube));
        }

        [TestMethod]
        public void Cube_ParameterlessCubeHasMethodCallInIt()
        {
            var cube = new Cube();

            string script = cube.ToString();

            Assert.IsTrue(script.StartsWith("cube("));
            Assert.IsTrue(script.TrimEnd().EndsWith(");"));
        }

        [TestMethod]
        public void Cube_InitialPositionForNonCenteredCubeIsHalfLengthWidthAndHeight()
        {
            var cube = new Cube(10, 10, 10);

            Assert.IsTrue(cube.Position() == new Vector3(5, 5, 5));
        }

        [TestMethod]
        public void Cube_InitialPositionIfCenteredIsOrigin()
        {
            var cube = new Cube(25, 25, 25, true);

            Assert.AreEqual(new Vector3(), cube.Position());
        }

        [TestMethod]
        public void Cube_PositionMovesWithCubeOnTranslate()
        {
            var cube = new Cube(50, 50, 50).Translate(10, 10, 0);

            Assert.AreEqual(new Vector3(35, 35, 25), cube.Position());
        }

        [TestMethod]
        public void Cube_PositionMovesWithCubeOnNegativeTranslate()
        {
            var cube = new Cube(50, 50, 50, true).Translate(-5, 0, -15);

            Assert.AreEqual(new Vector3(-5, 0, -15), cube.Position());
        }

        [TestMethod]
        public void Cube_BoundsAreInExpectedPositionNotCentered()
        {
            var obj = new Cube(5, 5, 20, false);

            Assert.AreEqual(new Vector3(5, 5, 20), obj.Bounds().TopRight);
            Assert.AreEqual(new Vector3(), obj.Bounds().BottomLeft);
        }

        [TestMethod]
        public void Cube_BoundsAreInExpectedPositionCentered()
        {
            var obj = new Cube(5, 5, 20, true);

            Assert.AreEqual(new Vector3(2.5, 2.5, 10), obj.Bounds().TopRight);
            Assert.AreEqual(new Vector3(-2.5, -2.5, -10), obj.Bounds().BottomLeft);
        }

        [TestMethod]
        public void Cube_LengthWidthHeightAppearsInScriptOutput()
        {
            var cube = new Cube(15, 5, 12);

            string script = cube.ToString();

            Assert.IsTrue(script.Contains("size = [15, 5, 12]"));
        }
    }
}
