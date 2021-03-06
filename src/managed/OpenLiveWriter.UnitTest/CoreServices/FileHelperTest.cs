// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NUnit.Framework;
using OpenLiveWriter.CoreServices;

namespace OpenLiveWriter.UnitTest
{
    [TestFixture]
    public class FileHelperTest
    {
        [Test]
        public void AnsiFileNameTest()
        {
            foreach (string fileName in FILENAMES)
            {
                string ansiName = FileHelper.GetValidAnsiFileName(fileName);
                Assert.IsTrue(FileHelper.IsValidFileName(ansiName));
                Assert.IsTrue(ContainsOnlyAnsi(ansiName));
                Assert.IsTrue(!ansiName.StartsWith("."));
                Assert.IsTrue(!ansiName.EndsWith("."));
            }
        }

        private static bool ContainsOnlyAnsi(string s)
        {
            foreach (char c in s)
                if (c > 128)
                    return false;
            return true;
        }

        private static readonly string[] FILENAMES = new string[]
            {
                "foo.txt",
                ".txt",
                "txt.",
                "foo",
                "售烟花爆.jpg",
                "copy of 售烟花爆.jpg",
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890.png"
    };

    }
}
