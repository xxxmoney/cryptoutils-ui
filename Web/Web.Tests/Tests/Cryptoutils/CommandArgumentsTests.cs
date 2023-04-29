using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils.Commands;

namespace Web.Tests.Tests.Cryptoutils
{
    public class CommandArgumentsTests
    {
        public static object[] EllipticCurveNormalSumSource = new object[]
        {
            new object[]
            {
                13,
                21,
                41,
                new Point(26, 31),
                new Point(3, 28),
                "ec \"GF(p)\" sum 13 21 41 26 31 3 28"
            }
        };
        [Test]
        [TestCaseSource(nameof(EllipticCurveNormalSumSource))]
        public void EllipticCurveNormalSum(long curveA, long curveB, long curvePrime, Point firstPoint, Point secondPoint, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.EllipticCurve.Normal.SumCommand(curveA, curveB, curvePrime, firstPoint, secondPoint);

            // Act
            string result = command.ToString();

            // Assert
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo(expected));
        }

        public static object[] EllipticCurveNormalAlignsonSource = new object[]
        {
            new object[]
            {
                13,
                21,
                41,
                new Point(26, 31),
                "ec \"GF(p)\" alignson 13 21 41 26 31"
            }
        };
        [Test]
        [TestCaseSource(nameof(EllipticCurveNormalAlignsonSource))]
        public void EllipticCurveNormalAlignson(long curveA, long curveB, long curvePrime, Point point, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.EllipticCurve.Normal.AlignsonCommand(curveA, curveB, curvePrime, point);

            // Act
            string result = command.ToString();

            // Assert
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(12, 8, "extgcd 12 8")]
        public void ExtendedGreatestCommonDivisor(long number, long prime, string expected)
        {
            // Arrange
            var command = new ExtendedGreatestCommonDivisorCommand(number, prime);

            // Act
            string result = command.ToString();

            // Assert
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
