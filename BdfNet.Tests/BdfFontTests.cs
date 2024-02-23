using System.Diagnostics;
using System.Reflection;

namespace BdfNet.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "BdfNet.Tests.Fonts.spleen-12x24.bdf";
            using var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new Exception($"Could not find resource '{resourceName}'");

            var font = BdfFont.Load(stream);

            var aChar = font.Characters[0x61];
            Debug.WriteLine("===========================================");
            Debug.WriteLine(aChar.DebugPrint());
            Debug.WriteLine("===========================================");
        }

        [Test]
        public void Load_UnifontBdf_ShouldLoadCorrectly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "BdfNet.Tests.Fonts.courR14.bdf";
            using var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new Exception($"Could not find resource '{resourceName}'");

            var font = BdfFont.Load(stream);

            Assert.That(font, Is.Not.Null);
            Assert.That(font.FontName, Is.EqualTo("-Adobe-Courier-Medium-R-Normal--20-140-100-100-M-110-ISO10646-1"));
            Assert.That(font.PointSize, Is.EqualTo(14));
            Assert.That(font.ResolutionX, Is.EqualTo(100));
            Assert.That(font.ResolutionY, Is.EqualTo(100));
            Assert.That(font.FontBoundingBox, Is.EqualTo(new int[] { 16, 26, -3, -7 }));
            Assert.That(font.Ascent, Is.EqualTo(13));
            Assert.That(font.Descent, Is.EqualTo(4));

            var aChar = font.Characters[0x61];
            Debug.WriteLine("===========================================");
            Debug.WriteLine(aChar.DebugPrint());
            Debug.WriteLine("===========================================");
        }
    }
}