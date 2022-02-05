using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Tests
{
    [TestClass]
    public class TestSolver
    {

        [TestMethod]
        public void Empty1()
        {
            string boardString = "0";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }

        [TestMethod]
        public void TestEmpty4()
        {
            string boardString = "0000000000000000";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }

        [TestMethod]
        public void TestEmpty9()
        {
            string boardString = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }

        [TestMethod]
        public void TestEmpty16()
        {
            string boardString = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }
        [TestMethod]
        public void TestSolved4()
        {
            string boardString = "2134341243211243";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }

        [TestMethod]
        public void TestSolved9()
        {
            string boardString = "619742358457831692823695174236419587591278463784356219962183745345967821178524936";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }

        [TestMethod]
        public void TestSolved16()
        {
            string boardString = "289:134576;<=>?@37=128694>@?5:;<4<?6>@7;15:=28395>;@<:?=23984167724856319:<;>?@=135;=98?@24>7<:66:<>7;2@3?=189459=@?:4<>8756321;812347;:5<?@96=>;569@1>3=48:<72?<?746=98>;32:@51:@>=?25<6917;483>6153?:2;879@=<4=9:7;<@4?12365>8@4328>17<=65?;9:?;8<95=6:@>41372";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }
        [TestMethod]
        public void Test1on1first()
        {
            string boardString = "0";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);

            Assert.IsTrue(BoardUtils.IsBoardSolved(game.GetBoard()));
        }
        [TestMethod]
        public void Test1on1second()
        {
            string boardString = "1";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }

        [TestMethod]
        public void Test4on4first()
        {
            string boardString = "0000000000000000";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }
        [TestMethod]
        public void Test4on4second()
        {
            string boardString = "4030020400202000";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }

        [TestMethod]
        public void Test9on9first()
        {
            string boardString = "010040050407000602820600074000010500500000003004050000960003045305000801070020030";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }
        public void Test9on9second()
        {
            string boardString = "000260701680070090190004500820100040004602900050003028009300074040050036703018000";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }
        [TestMethod]
        public void Test9on9third()
        {
            string boardString = "000000317500000000001900000012600074600000030000000005000006000024350760080010400";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }
        [TestMethod]
        public void Test16on16first()
        {
            string boardString = "040080@0;010060>30090?04:70=00<006002;0080003000?000000=00>002040008030070005000000000>0000:0@0=009250000800;000<010000@00=00030000<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;005;3:000800<400010>00;9000=?04050=040600000020<090<0@0=00010060?0";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }

        [TestMethod]
        public void Test16on16second()
        {
            string boardString = "0090104576;<=0?00700280040005:0<0<00000015:=28390000000023984167000856009:<0>0@=1300000002407<:600<0702030=189450=0004<0875632108103000:5<0@96=>05600003=48:<72000000090>032:@5100>=000<69170483061530000879@=<400070004012365>800320>07<=65009:00009000:@>41372";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }
        [TestMethod]
        public void Test16on16third()
        {
            string boardString = "102000;680054<00>00;08:0<09007000<00000002700?090090070000:0>85;0:0@1002;40600080300000900000000;942050>00=030000000008@3920040000100:?39600000000060900@0<02;4>00000000200000102000@0>8100=<06054?10>0000600@0060@00250000000<000<00@0:0710=00400:>?00;43000501";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }

        [TestMethod]
        public void Test16on16fourth()
        {
            string boardString = "0000700000000400003000000000000000040000001=000000000000000070000000500000000000000;080000000000000000700000000000000000000000000000000000000000000000000000000000030000000000000500000900000200000000000000000000<0000000000000000000010000600<08000000;0000000";
            string boardResult = Solver.Solve(boardString);

            Game game = new Game(boardResult);
            bool isSolved = BoardUtils.IsBoardSolved(game.GetBoard());
            Assert.IsTrue(isSolved);
        }
        [TestMethod]
        public void Test16on16()
        {
            Assert.AreEqual(Solver.Solve("0000010000000000000000400000000000000000000000000000000000000000000000002;000000000800>0300000<0=0000000000000000000000000000600000000080000000000007000000008000000000000000000000000000000000000000000000>0000000000000000000000000000000000000000000000000000"), "@;6>31729<58?:=4:2<36=45>?7;1@894?17;>89:@2=635<598=<@?:43617;>29:>?8<=62;@7314526789:>;3145=?<@=45<?31@89:627;>13;@2457=>?<869:>@=:1238;794<5?63<2;75:4@6>?981=?195=6;><83:42@77846@9<?15=2;>:385?947216:<>@=3;<=:1586374;@>92?6>@2:;9<?=135478;734>?@=5289:<61");
        }

        [TestMethod]
        public void TestEmptyBoard()
        {
            string boardString = "";
            string boardResult = Solver.Solve(boardString);

            Assert.IsNull(boardResult);
        }

        [TestMethod]
        public void TestIllegalChar()
        {
            string boardString = "2";
            string boardResult = Solver.Solve(boardString);

            Assert.IsNull(boardResult);
        }

        [TestMethod]
        public void TestIllegalChar2()
        {
            string boardString = "0000000000000005";
            string boardResult = Solver.Solve(boardString);

            Assert.IsNull(boardResult);
        }

        [TestMethod]
        public void TestWrongSizeBoard()
        {
            string boardString = "12000";
            string boardResult = Solver.Solve(boardString);

            Assert.IsNull(boardResult);

        }

        [TestMethod]
        public void TestUnsolebaleBoard()
        {
            string boardString = "1230000400000000";
            string boardResult = Solver.Solve(boardString);

            Assert.IsNull(boardResult);
        }
        [TestMethod]
        public void TestUnsolebaleBoard2()
        {
            string boardString = "0234000000001000";
            string boardResult = Solver.Solve(boardString);

            Assert.IsNull(boardResult);
        }
    }
}