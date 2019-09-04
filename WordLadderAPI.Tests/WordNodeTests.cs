using NUnit.Framework;

namespace Tests
{
    public class WordNodeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WordSet()
        {
            WordLadderAPI.WordNode node = new WordLadderAPI.WordNode("hello");
            Assert.AreEqual("hello", node.Word);
            Assert.Pass("Test1 Successful");
        }
        [Test]
        public void OneStepAway_1Step()
        {
            WordLadderAPI.WordNode node = new WordLadderAPI.WordNode("feed");
            WordLadderAPI.WordNode node2 = new WordLadderAPI.WordNode("seed");
            
            Assert.IsTrue(node.isStepAway(node2));
            Assert.Pass("success {0} is one away from {1}",node.Word, node2.Word);
        }

        [Test]
        public void OneStepAway_2Step()
        {
            WordLadderAPI.WordNode node = new WordLadderAPI.WordNode("feed");
            WordLadderAPI.WordNode node2 = new WordLadderAPI.WordNode("seen");

            Assert.IsFalse(node.isStepAway(node2));
            Assert.Pass("success: {0} is not one away from {1}", node.Word, node2.Word);
        }

        [Test]
        public void OneStepAway_Equal()
        {
            WordLadderAPI.WordNode node = new WordLadderAPI.WordNode("feed");
            WordLadderAPI.WordNode node2 = new WordLadderAPI.WordNode("feed");

            Assert.IsFalse(node.isStepAway(node2));
            Assert.Pass("success: {0} is not one away from {1}", node.Word, node2.Word);
        }

        [Test]
        public void ONeStepAway_diffLengths()
        {
            WordLadderAPI.WordNode node = new WordLadderAPI.WordNode("feed");
            WordLadderAPI.WordNode node2 = new WordLadderAPI.WordNode("feeds");

            Assert.IsFalse(node.isStepAway(node2));
            Assert.Pass("success: {0} is not one away from {1} as different lengths", node.Word, node2.Word);
        }
    }
}