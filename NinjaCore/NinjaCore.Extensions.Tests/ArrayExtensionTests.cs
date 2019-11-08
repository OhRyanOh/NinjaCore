﻿using System.Text;
using FluentAssertions;
using Xunit;

namespace NinjaCore.Extensions.Tests
{
    /// <summary>
    /// Tests for <seealso cref="ArrayExtensions" /> class extension methods.
    /// </summary>
    public class ArrayExtensionTests
    {
        [Fact]
        [Trait("Category", "Mocked")]
        public void MockedTestForTryClear()
        {
            var valueBytes = Encoding.UTF8.GetBytes("0123456789");
            valueBytes.Should().BeOfType<byte[]>();
            valueBytes.Should().NotBeNullOrEmpty();

            var partialClearBytes = Encoding.UTF8.GetBytes("012345\0\089");
            partialClearBytes.Should().BeOfType<byte[]>();
            partialClearBytes.Should().NotBeNullOrEmpty();

            var fullClearBytes = Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0");
            fullClearBytes.Should().BeOfType<byte[]>();
            fullClearBytes.Should().NotBeNullOrEmpty();

            var isValid = valueBytes.TryClear(index: 6, length: 2);
            valueBytes.Should().BeEquivalentTo(partialClearBytes);
            isValid.Should().BeTrue();

            isValid = valueBytes.TryClear(index: 6, length: 2, clearAfterUse: true);
            valueBytes.Should().BeEquivalentTo(fullClearBytes);
            isValid.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Mocked")]
        public void MockedTestForTryValidateArrayBounds()
        {
            var valueBytes = Encoding.UTF8.GetBytes("0123456789");
            valueBytes.Should().BeOfType<byte[]>();
            valueBytes.Should().NotBeNullOrEmpty();

            var partialValidateBytes = Encoding.UTF8.GetBytes("0123456789");
            partialValidateBytes.Should().BeOfType<byte[]>();
            partialValidateBytes.Should().NotBeNullOrEmpty();

            var fullClearBytes = Encoding.UTF8.GetBytes("\0\0\0\0\0\0\0\0\0\0");
            fullClearBytes.Should().BeOfType<byte[]>();
            fullClearBytes.Should().NotBeNullOrEmpty();

            var isValid = valueBytes.TryValidateArrayBounds(out var intendedLength, index: 6, length: 2);
            valueBytes.Should().BeEquivalentTo(partialValidateBytes);
            isValid.Should().BeTrue();
            intendedLength.Should().Be(2);

            isValid = valueBytes.TryValidateArrayBounds(out intendedLength, index: 6, length: 2, clearAfterUse: true);
            valueBytes.Should().BeEquivalentTo(fullClearBytes);
            isValid.Should().BeTrue();
            intendedLength.Should().Be(2);
        }

        [Fact]
        [Trait("Category", "Mocked")]
        public void MockedTestForToByteArray()
        {
            var valueBytes = Encoding.UTF8.GetBytes("0123456789");
            valueBytes.Should().BeOfType<byte[]>();
            valueBytes.Should().NotBeNullOrEmpty();

            var partialValidateBytes = Encoding.UTF8.GetBytes("67");
            partialValidateBytes.Should().BeOfType<byte[]>();
            partialValidateBytes.Should().NotBeNullOrEmpty();

            var fullClearBytes = Encoding.UTF8.GetBytes("\0\0");
            fullClearBytes.Should().BeOfType<byte[]>();
            fullClearBytes.Should().NotBeNullOrEmpty();

            var byteArrayResult = valueBytes.ToByteArray(index: 6, length: 2);
            byteArrayResult.Should().BeOfType<byte[]>();
            byteArrayResult.Should().NotBeNullOrEmpty();
            byteArrayResult.Should().BeEquivalentTo(partialValidateBytes);

            byteArrayResult = valueBytes.ToByteArray(index: 6, length: 2, clearAfterUse: true);
            byteArrayResult.Should().BeOfType<byte[]>();
            byteArrayResult.Should().NotBeNullOrEmpty();
            byteArrayResult.Should().BeEquivalentTo(fullClearBytes);
        }

        [Fact]
        [Trait("Category", "Mocked")]
        public void MockedTestForToCharacterArray()
        {
            var valueBytes = Encoding.UTF8.GetBytes("0123456789");
            valueBytes.Should().BeOfType<byte[]>();
            valueBytes.Should().NotBeNullOrEmpty();

            var partialValidateBytes = Encoding.UTF8.GetBytes("67");
            var partialValidateChars = Encoding.UTF8.GetChars(partialValidateBytes);
            partialValidateBytes.Should().BeOfType<byte[]>();
            partialValidateBytes.Should().NotBeNullOrEmpty();
            partialValidateChars.Should().BeOfType<char[]>();
            partialValidateChars.Should().NotBeNullOrEmpty();

            var fullClearBytes = Encoding.UTF8.GetBytes("\0\0");
            var fullClearChars = Encoding.UTF8.GetChars(fullClearBytes);
            fullClearBytes.Should().BeOfType<byte[]>();
            fullClearBytes.Should().NotBeNullOrEmpty();
            fullClearChars.Should().BeOfType<char[]>();
            fullClearChars.Should().NotBeNullOrEmpty();

            var charArrayResult = valueBytes.ToCharacterArray(index: 6, length: 2);
            charArrayResult.Should().BeOfType<char[]>();
            charArrayResult.Should().NotBeNullOrEmpty();
            charArrayResult.Should().BeEquivalentTo(partialValidateChars);

            charArrayResult = valueBytes.ToCharacterArray(index: 6, length: 2, clearAfterUse: true);
            charArrayResult.Should().BeOfType<char[]>();
            charArrayResult.Should().NotBeNullOrEmpty();
            charArrayResult.Should().BeEquivalentTo(fullClearChars);
        }
    }
}
