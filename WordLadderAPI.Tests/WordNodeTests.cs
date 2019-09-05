using NUnit.Framework;

namespace WordLadderAPI.Tests
{
    public class WordNodeTests
    {
        WordLadderAPI.WordNode node;
        WordLadderAPI.WordNode node2;

        [SetUp]
        public void Setup()
        {
            node = new WordLadderAPI.WordNode("feed");
            node2 = new WordLadderAPI.WordNode("seed");
        }

        [Test]
        public void WordSet()
        {
            Assert.AreEqual("feed", node.Word);
            Assert.Pass("Test1 Successful");
        }
        [Test]
        public void OneStepAway_1Step()
        {
            Assert.IsTrue(node.isStepAway(node2));
            Assert.Pass("success {0} is one away from {1}",node.Word, node2.Word);
        }

        [Test]
        public void OneStepAway_2Step()
        {
            node2.Word = "seen";

            Assert.IsFalse(node.isStepAway(node2));
            Assert.Pass("success: {0} is not one away from {1}", node.Word, node2.Word);
        }

        [Test]
        public void OneStepAway_Equal()
        {
            node2.Word = "feed";

            Assert.IsFalse(node.isStepAway(node2));
            Assert.Pass("success: {0} is not one away from {1}", node.Word, node2.Word);
        }

        [Test]
        public void ONeStepAway_diffLengths()
        {
            node2.Word = "feeds";

            Assert.IsFalse(node.isStepAway(node2));
            Assert.Pass("success: {0} is not one away from {1} as different lengths", node.Word, node2.Word);
        }
    }
}