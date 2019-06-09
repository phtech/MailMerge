﻿using System.IO;
using System.Net;
using System.Reflection;
using NUnit.Framework;
using TestBase;
using Assert = TestBase.Assert;

namespace MailMerge.OoXml.Tests.NFRs
{
    public class MainShould
    {
        [TestCase("in.docx", "out.docx", "a=b", "aa=bb")]
        [TestCase("in.docx", "out.docx", "in2.docx", "out2.docx", "a=b", "aa=bb")]
        public void ParseArgs(params string[] args)
        {
            var(files,mergefields) = Program.ParseArgs.FromStringArray(args);

            files[0].Item1.Name.ShouldBe(args[0]);
            files[0].Item2.Name.ShouldBe(args[1]);
            mergefields["a"].ShouldNotBeNull().ShouldBe("b");
            mergefields["aa"].ShouldNotBeNull().ShouldBe("bb");
            
        }

        [Test]
        public void NotThrowIfThereIsNoAppSettingsJson()
        {
            if (!File.Exists("appsettings.json"))
            {
                var thereWasNoAppsettingsIn = "There was no appsettings in " + Directory.GetCurrentDirectory();
                NUnit.Framework.Assert.Inconclusive(thereWasNoAppsettingsIn);
            }
            System.IO.File.Delete("appsettings.json.bak");
            System.IO.File.Move("appSettings.json", "appsettings.json.bak");
            
            Program.Main("in.docx", "out.docx", "a=b");
            
            System.IO.File.Move("appsettings.json.bak","appsettings.json");
        }
    }
}
