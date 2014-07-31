

using MDocWriter.Application.Templates;

namespace MDocWriter.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TemplateTests
    {
        [TestMethod]
        public void ReadStylesTest()
        {
            var reader =
                new TemplateReader(
                    @"C:\Users\Sunny\Documents\GitHub\mdocwriter\MDocWriter.WinFormMain\bin\Debug\templates",
                    Template.TemplateFileSearchPattern);
            var templateContent = reader.GetTemplateContent(reader.Templates.First());
            var image = reader.GetPreviewImage(reader.Templates.First());
        }
    }
}
