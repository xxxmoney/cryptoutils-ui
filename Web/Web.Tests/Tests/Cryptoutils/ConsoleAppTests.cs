using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils;

namespace Web.Tests.Tests.Cryptoutils
{
    public class ConsoleAppTests
    {
        public static object[] ExecuteCommandAsyncSource = new object[]
        {
            new object[]
            {
                new string[] { "extgcd", "12", "8" }
            }
        };
        [Test]
        [TestCaseSource(nameof(ExecuteCommandAsyncSource))]
        public async Task ExecuteCommandAsync(string[] arguments)
        {
            // Arrange
            string executablePath = Path.Combine(Environment.CurrentDirectory, "cryptoutils.exe");
            var console = new ConsoleApp(executablePath);
            var timeout = TimeSpan.FromSeconds(5);

            // Act
            var result = await console.ExecuteAsync(timeout, arguments);

            // Assert
            Console.WriteLine(result);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.Not.Empty);
            });
        }

    }
}
