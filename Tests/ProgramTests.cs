using System;
using System.IO;
using System.Threading.Tasks;
using CatFact.Models;
using CatFact.Services;
using Moq;
using Xunit;

namespace CatFact.Test
{
    public class ProgramTests
    {
        [Fact]
        public async Task RunWithService_PrintsMenuAndFact()
        {
            var mock = new Mock<IFactService>();
            mock.Setup(s => s.GetFactAsync()).ReturnsAsync(new Fact { Text = "mock", Length = 4 });

            using var input = new StringReader("1\n4\n");
            using var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            await Program.RunWithService(mock.Object);

            var txt = output.ToString();
            Assert.Contains("1) Peek current fact", txt);
            Assert.Contains("mock", txt);
        }
    }
}