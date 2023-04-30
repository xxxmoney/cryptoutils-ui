using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils;
using Web.Cryptoutils.Commands;
using Web.Cryptoutils.Models;

namespace Web.Tests.Tests.Cryptoutils
{
    public class CommandsTests
    {
        public static IConsoleApp ConsoleApp = Web.Cryptoutils.ConsoleApp
            .GetBuilder()
            .WithDefaultExecutablePath()
            .Build();

        /// <summary>
        /// Tests command with assertion and printing against expected arguments.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static async Task TestCommand(Command command, string expected)
        {
            // Act
            string result = command.ToString();

            // Assert
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine(await command.ExecuteAsync(ConsoleApp));

            Assert.That(result, Is.EqualTo(expected));
        }

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
        public async Task EllipticCurveNormalSum(long curveA, long curveB, long curvePrime, Point firstPoint, Point secondPoint, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.EllipticCurve.Normal.SumCommand(curveA, curveB, curvePrime, firstPoint, secondPoint);

            await TestCommand(command, expected);
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
        public async Task EllipticCurveNormalAlignson(long curveA, long curveB, long curvePrime, Point point, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.EllipticCurve.Normal.AlignsonCommand(curveA, curveB, curvePrime, point);

            await TestCommand(command, expected);
        }

        public static object[] EllipticCurveAdvancedSumSource = new object[]
        {
            new object[]
            {
                "g^3",
                "g^2",
                "010",
                "1011",
                3,
                new CustomPoint("g^5", "g^6"),
                new CustomPoint("g^5", "g^5"),
                "ec \"GF(2^n)\" sum g^3 g^2 010 1011 3 g^5 g^6 g^5 g^5"
            }
        };
        [Test]
        [TestCaseSource(nameof(EllipticCurveAdvancedSumSource))]
        public async Task EllipticCurveAdvancedSum(string curveA_G, string curveB_G, string polynomialBinary, string irreduciblePolynomialBinary, long n, CustomPoint firstPoint, CustomPoint secondPoint, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.EllipticCurve.Advanced.SumCommand(curveA_G, curveB_G, polynomialBinary, irreduciblePolynomialBinary, n, firstPoint, secondPoint);

            await TestCommand(command, expected);
        }

        public static object[] EllipticCurveAdvancedMultiplySource = new object[]
        {
            new object[]
            {
                "g^3",
                "g^2",
                "010",
                "1011",
                3,
                new CustomPoint("g^5", "g^6"),
                4,
                "ec \"GF(2^n)\" multiply g^3 g^2 010 1011 3 g^5 g^6 4"
            }
        };
        [Test]
        [TestCaseSource(nameof(EllipticCurveAdvancedMultiplySource))]
        public async Task EllipticCurveAdvancedMultiply(string curveA_G, string curveB_G, string polynomialBinary, string irreduciblePolynomialBinary, long n, CustomPoint point, long scalar, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.EllipticCurve.Advanced.MultiplyCommand(curveA_G, curveB_G, polynomialBinary, irreduciblePolynomialBinary, n, point, scalar);

            await TestCommand(command, expected);
        }

        public static object[] EllipticCurveAdvancedAlignsonSource = new object[]
        {
            new object[]
            {
                "g^3",
                "g^2",
                "010",
                "1011",
                3,
                new CustomPoint("g^5", "g^6"),
                "ec \"GF(2^n)\" alignson g^3 g^2 010 1011 3 g^5 g^6"
            }
        };
        [Test]
        [TestCaseSource(nameof(EllipticCurveAdvancedAlignsonSource))]
        public async Task EllipticCurveAdvancedAlignson(string curveA_G, string curveB_G, string polynomialBinary, string irreduciblePolynomialBinary, long n, CustomPoint point, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.EllipticCurve.Advanced.AlignsonCommand(curveA_G, curveB_G, polynomialBinary, irreduciblePolynomialBinary, n, point);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(607, 555, 7, 4, 10, "elgamal enc 607 555 7 4 10")]
        public async Task ElGamalEncryption(long p, long z, long b, long k, long m, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.ElGamal.EncryptionCommand(p, z, b, k, m);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(157, 141, 211, 17, "elgamal dec 157 141 211 17")]
        public async Task ElGamalDecryption(long c, long d, long p, long a, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.ElGamal.DecryptionCommand(c, d, p, a);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(12, 8, "extgcd 12 8")]
        public async Task ExtendedGreatestCommonDivisor(long number, long prime, string expected)
        {
            // Arrange
            var command = new ExtendedGreatestCommonDivisorCommand(number, prime);

            await TestCommand(command, expected);
        }

        public static object[] IsGeneratorNormalSource = new object[]
        {
            new object[]
            {
                7,
                new long[] { 3 },
                "isgenerator \"GF(p)\" 7 3"
            }
        };
        [Test]
        [TestCaseSource(nameof(IsGeneratorNormalSource))]
        public async Task IsGeneratorNormal(long p, long[] numbers, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.IsGenerator.NormalCommand(p, numbers);
            
            await TestCommand(command, expected);
        }

        public static object[] IsGeneratorAdvancedSource = new object[]
        {
            new object[]
            {
                "1011",
                3,
                new string[] { "010" },
                "isgenerator \"GF(2^n)\" 1011 3 010"
            }
        };
        [Test]
        [TestCaseSource(nameof(IsGeneratorAdvancedSource))]
        public async Task IsGeneratorAdvanced(string irreduciblePolynomialBinary, long n, string[] polynomialsBinary, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.IsGenerator.AdvancedCommand(irreduciblePolynomialBinary, n, polynomialsBinary);

            await TestCommand(command, expected);
        }

        public static object[] LehmanPeraltPrimalityTestSource = new object[]
        {
            new object[]
            {
                7,
                new long[] { 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71 },
                "lhperalt 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71"
            }
        };
        [Test]
        [TestCaseSource(nameof(LehmanPeraltPrimalityTestSource))]
        public async Task LehmanPeraltPrimalityTest(long examinedNumber, long[] numbers, string expected)
        {
            // Arrange
            var command = new LehmanPeraltPrimalityTestCommand(examinedNumber, numbers);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(2, 3, 5, "modexp 2 3 5")]
        public async Task ModularExponantiation(long number, long power, long prime, string expected)
        {
            // Arrange
            var command = new ModularExponentiationCommand(number, power, prime);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(442931, 2, "rhoalgo 442931 2")]
        public async Task PollardRhoAlgorithm(long number, long seed, string expected)
        {
            // Arrange
            var command = new PollardRhoAlgorithmCommand(number, seed);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(10, 23701, 1015, "rsa enc 10 23701 1015")]
        public async Task RsaEncryption(long m, long n, long e, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.Rsa.EncryptionCommand(m, n, e);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(4754, 23701, 20903, "rsa dec 4754 23701 20903")]
        public async Task RsaDecryption(long m, long n, long d, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.Rsa.DecryptionCommand(m, n, d);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(23701, 1015, "rsa derivePrivKeyFromMod 23701 1015")]
        public async Task RsaDerivePrivateKeyFromModule(long n, long e, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.Rsa.DerivePrivateKeyFromModuleCommand(n, e);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(137, 173, 1015, "rsa deriveKeysFromPubExp 137 173 1015")]
        public async Task RsaDeriveKeysFromPublicExponent(long p, long q, long e, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.Rsa.DeriveKeysFromPublicExponent(p, q, e);

            await TestCommand(command, expected);
        }

        [Test]
        [TestCase(137, 173, 20903, "rsa deriveKeysFromPrivExp 137 173 20903")]
        public async Task RsaDeriveKeysFromPrivateExponent(long p, long q, long d, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.Rsa.DeriveKeysFromPrivateExponent(p, q, d);

            await TestCommand(command, expected);
        }

        public static object[] ShamirProtocolGetSubjectsSource = new object[]
        {
            new object[]
            {
                13,
                2,
                3,
                10,
                new Point[] { new Point(4, 8) },
                "shamir_protocol getSubjects 13 2 3 10 4 8"
            }
        };
        [Test]
        [TestCaseSource(nameof(ShamirProtocolGetSubjectsSource))]
        public async Task ShamirProtocolGetSubjects(long p, long K, long N, long S, Point[] points, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.Shamir.GetSubjectsCommand(p, K, N, S, points);

            await TestCommand(command, expected);
        }

        public static object[] ShamirProtocolReconstructionSource = new object[]
        {
            new object[]
            {
                13,
                2,
                new Point[] { new Point(11, 11), new Point(1, 3) },
                "shamir_protocol reconstruction 13 2 11 11 1 3"
            }
        };
        [Test]
        [TestCaseSource(nameof(ShamirProtocolReconstructionSource))]
        public async Task ShamirProtocolReconstruction(long p, long K, Point[] points, string expected)
        {
            // Arrange
            var command = new Web.Cryptoutils.Commands.Shamir.ReconstructionCommand(p, K, points);

            await TestCommand(command, expected);
        }

    }
}
