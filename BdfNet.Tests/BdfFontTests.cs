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
            var resourceName = "BdfNet.Tests.Fonts.courR12.bdf";
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
            var resourceName = "BdfNet.Tests.Fonts.unifont-15.1.04.bdf";
            using var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new Exception($"Could not find resource '{resourceName}'");

            var font = BdfFont.Load(stream);

            Assert.That(font, Is.Not.Null);
            Assert.That(font.FontName, Is.EqualTo("-gnu-Unifont-Medium-R-Normal-Sans-16-160-75-75-c-80-iso10646-1"));
            Assert.That(font.PointSize, Is.EqualTo(16));
            Assert.That(font.ResolutionX, Is.EqualTo(75));
            Assert.That(font.ResolutionY, Is.EqualTo(75));
            Assert.That(font.FontBoundingBox, Is.EqualTo(new int[] { 16, 16, 0, -2 }));

            var aChar = font.Characters[0x61];
            Debug.WriteLine("===========================================");
            Debug.WriteLine(aChar.DebugPrint());
            Debug.WriteLine("===========================================");
        }
    }
}