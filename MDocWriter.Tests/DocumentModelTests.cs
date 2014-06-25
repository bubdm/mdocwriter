namespace MDocWriter.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using MDocWriter.Documents;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DocumentModelTests
    {
        [TestMethod]
        public void AddChildDocumentNodeEventTest()
        {
            var count = 0;
            var document = new Document();
            document.PropertyChanged += (s, e) => count++;
            document.AddDocumentNode("Overview");
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void AddChildDocumentNodeAndChangeNodePropertyEventTest()
        {
            var count = 0;
            var document = new Document();
            document.PropertyChanged += (s, e) => count++;
            var node = document.AddDocumentNode("Overview");
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
            var node = document.AddDocumentNode("Overview");
            var subNode = node.AddDocumentNode("Design");
            Assert.AreEqual(2, count);
            Assert.AreEqual(1, document.Children.Count());
            Assert.AreEqual(1, document.Children.First().Children.Count());
        }

        [TestMethod]
        public void VisitDocumentNodeTest()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            node1.AddDocumentNode("node11");
            node1.AddDocumentNode("node12");
            var node2 = document.AddDocumentNode("node2");
            var node21 = node2.AddDocumentNode("node21");
            var node211 = node21.AddDocumentNode("node211");
            node211.AddDocumentNode("node2111");
            document.AddDocumentResource("resource1.txt", string.Empty);
            document.AddDocumentResource("resource2.txt", string.Empty);
            document.AddDocumentResource("resource3.txt", string.Empty);
            var walker = new DocumentTestWalker();
            walker.VisitDocument(document);
            var names = walker.Names;
            Assert.AreEqual(11, names.Count());
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    internal class DocumentTestWalker : DocumentWalker
    {

        private readonly List<string> names = new List<string>();

        public IEnumerable<string> Names
        {
            get
            {
                return this.names;
            }
        }

        public override void Visit(Document document)
        {
            this.names.Add(document.Title);
        }

        public override void Visit(DocumentNode documentNode)
        {
            this.names.Add(documentNode.Name);
        }

        public override void Visit(DocumentResource documentResource)
        {
            this.names.Add(documentResource.FileName);
        }

    }
}
