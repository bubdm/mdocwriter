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

        [TestMethod]
        public void MoveDocumentNodeUp_Normal_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            node12.MoveUp();
            Assert.AreEqual(node12, node1.Children.First());
            Assert.AreEqual(node11, node1.Children.Last());
        }

        [TestMethod]
        public void MoveDocumentNodeUp_MoveTopNode_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            node11.MoveUp();
            Assert.AreEqual(node11, node1.Children.First());
            Assert.AreEqual(node12, node1.Children.Last());
        }

        [TestMethod]
        public void MoveDocumentNodeUp_MoveUpTwice_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node13.MoveUp();
            node13.MoveUp();
            Assert.AreEqual(node13, node1.Children.First());
            Assert.AreEqual(node12, node1.Children.Last());
        }

        [TestMethod]
        public void MoveDocumentNodeUp_EventFire_Test()
        {
            bool eventFired = false;

            var document = new Document();
            document.PropertyChanged += (s, e) => eventFired = true;
            var node1 = document.AddDocumentNode("node1");
            node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            node12.MoveUp();

            Assert.IsTrue(eventFired);
        }

        [TestMethod]
        public void MoveDocumentNodeDown_Normal_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node11.MoveDown();
            Assert.AreEqual(node12, node1.Children.First());
            Assert.AreEqual(node13, node1.Children.Last());
        }

        [TestMethod]
        public void MoveDocumentNodeDown_MoveBottomNode_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node13.MoveDown();
            Assert.AreEqual(node11, node1.Children.First());
            Assert.AreEqual(node13, node1.Children.Last());
        }

        [TestMethod]
        public void MoveDocumentNodeDown_MoveDownTwice_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node11.MoveDown();
            node11.MoveDown();
            Assert.AreEqual(node12, node1.Children.First());
            Assert.AreEqual(node11, node1.Children.Last());
        }

        [TestMethod]
        public void PromoteDocumentNode_Normal_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node12.Promote();
            Assert.AreEqual(2, document.Children.Count());
            Assert.AreEqual(2, node1.Children.Count());
            Assert.AreEqual(node1, document.Children.First());
            Assert.AreEqual(node12, document.Children.Last());
        }

        [TestMethod]
        public void PromoteDocumentNode_Twice_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node121 = node12.AddDocumentNode("node121");
            var node13 = node1.AddDocumentNode("node13");
            node121.Promote();
            Assert.AreEqual(4, node1.Children.Count());
            node121.Promote();
            Assert.AreEqual(2, document.Children.Count());
        }

        [TestMethod]
        public void PromoteDocumentNode_AlreadyTopLevel_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node121 = node12.AddDocumentNode("node121");
            var node13 = node1.AddDocumentNode("node13");
            node1.Promote();
            Assert.AreEqual(1, document.Children.Count());
        }

        [TestMethod]
        public void PromoteDocumentNode_FireEvent_Test()
        {
            var fired = false;
            var document = new Document();
            document.PropertyChanged += (s, e) => fired = true;
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node121 = node12.AddDocumentNode("node121");
            var node13 = node1.AddDocumentNode("node13");
            node121.Promote();
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void DegradeDocumentNode_Normal_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node12.Degrade();
            Assert.AreEqual(2, node1.Children.Count());
            Assert.AreEqual(1, node11.Children.Count());
        }

        [TestMethod]
        public void DegradeDocumentNode_FirstNode_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node11.Degrade();
            Assert.AreEqual(3, node1.Children.Count());
        }

        [TestMethod]
        public void DegradeDocumentNode_FirstDocumentNode_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node1.Degrade();
            Assert.AreEqual(3, node1.Children.Count());
        }

        [TestMethod]
        public void DegradeDocumentNode_Twice_Test()
        {
            var document = new Document();
            var node1 = document.AddDocumentNode("node1");
            var node11 = node1.AddDocumentNode("node11");
            var node12 = node1.AddDocumentNode("node12");
            var node13 = node1.AddDocumentNode("node13");
            node12.Degrade();
            node12.Degrade();
            Assert.AreEqual(2, node1.Children.Count());
            Assert.AreEqual(1, node11.Children.Count());
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
