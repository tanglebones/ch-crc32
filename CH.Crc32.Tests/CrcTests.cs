using System.Text;
using NUnit.Framework;

namespace CH.Crc32.Tests
{
    [TestFixture]
    public class CrcTests
    {
        [Test]
        public void ShortSequencesTest()
        {
            Assert.That(Crc.Crc32(new byte[] {}), Is.EqualTo(0x00000000u));
            Assert.That(Crc.Crc32(new byte[] {0x00}), Is.EqualTo(0xd202ef8du));
            Assert.That(Crc.Crc32(new byte[] {0x55}), Is.EqualTo(0xc9034af6u));
            Assert.That(Crc.Crc32(new byte[] {0xFF}), Is.EqualTo(0xff000000u));
            Assert.That(Crc.Crc32(new byte[] {1,2,3,4}), Is.EqualTo(0xb63cfbcdu));
        }

        [TestCase("ABC", 0xa3830348u)]
        [TestCase("The quick brown fox jumps over the lazy dog", 0x414FA339u)]
        [TestCase("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG", 0x4c32b6b9u)]
        public void StringChecksumTests(string str, uint expectedCrc32)
        {
            var data = Encoding.ASCII.GetBytes(str);
            Assert.That(Crc.Crc32(data), Is.EqualTo(expectedCrc32));
        }
    }
}
