namespace TestCommon
{
    using Common.DataFlows.Game;
    using Common.Records;
    using Common.Records.DataFlows.DataFlowReadRecord;
    using Common.Records.DataFlows.DataFlowWriteRecord;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDataFlow
    {
        private static NumbersGameDataFlow _dataFlow;

        [ClassInitialize()]
        public static void TestDataFlowInitialize(TestContext context)
        {
            string uri = "https://7annld7mde.execute-api.ap-southeast-2.amazonaws.com/main/game";
            _dataFlow = new NumbersGameDataFlow(uri, 1000000);
        }

        [TestMethod]
        public void TestDataFlowReadMethod()
        {
            NumbersGameReadRecord numbersGameReadRecord;
            string message;

            Assert.IsTrue(_dataFlow.ExecuteDataFlowReader(out numbersGameReadRecord, out message), message);
            Assert.IsTrue(numbersGameReadRecord.children_count > 0);
        }

        [TestMethod]
        public void TestDataFlowWriteMethod()
        {
            string message;

            NumbersGame numbersGame = new NumbersGame(99, 5, 12);
            numbersGame.SetupNewGame();
            Assert.IsTrue(numbersGame.Play(out message), message);

            NumbersGameWriteResponseRecord numbersGameResponse = null;

            //TODO:Commented out to protect Live game service.
            //Assert.IsTrue(_dataFlow.ExecuteDataFlowWriter(numbersGame, 
            //    out numbersGameResponse, out message), message);
            //Assert.IsTrue(numbersGameResponse.id > 0);
        }
    }
}
