using System;
using System.Linq;
using MDocWriter.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MDocWriter.Tests
{
    [TestClass]
    public class DocumentModelTests
    {
        [TestMethod]
        public void AddChildDocumentNodeEventTest()
        {
            var count = 0;
            var document = new Document();
            document.PropertyChanged += (s, e) => count++;
            document.AddChildDocumentNode("Overview");
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void AddChildDocumentNodeAndChangeNodePropertyEventTest()
        {
            var count = 0;
            var document = new Document();
            document.PropertyChanged += (s, e) => count++;
            var node = document.AddChildDocumentNode("Overview");
            node.Name = "Preface";
            Assert.AreEqual(2, count);
            Assert.AreEqual("Preface", document.Children.First().Name);
        }

        [TestMethod]
        public void AddDocumentResourceEventTest()
        {
            var count = 0;
            var document = new Document();
            document.PropertyChanged += (s, e) => count++;
            document.AddDocumentResource("logo.png", "xyz");
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void AddDocumentResourceAndChangeResourcePropertyEventTest()
        {
            var count = 0;
            var document = new Document();
            document.PropertyChanged += (s, e) => count++;
            var resource = document.AddDocumentResource("logo.png", "xyz");
            resource.FileName = "logo2.png";
            Assert.AreEqual(2, count);
            Assert.AreEqual("logo2.png", document.Resources.First().FileName);
        }

        [TestMethod]
        public void AddChildDocumentNodeAndAddSubNodeEventTest()
        {
            var count = 0;
            var document = new Document();
            document.PropertyChanged += (s, e) => count++;
            var node = document.AddChildDocumentNode("Overview");
            var subNode = node.AddChildDocumentNode("Design");
            Assert.AreEqual(2, count);
            Assert.AreEqual(1, document.Children.Count());
            Assert.AreEqual(1, document.Children.First().Children.Count());
        }
    }
}
