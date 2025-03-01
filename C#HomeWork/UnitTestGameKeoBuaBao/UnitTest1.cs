using PlayerChoice;
using System.Xml.Linq;

namespace UnitTestGameKeoBuaBao
{
    public class UnitTest1
    {
        [Fact]
        public void CheckResult_Player1Rock_Player2Scissor_ShouldReturnPlayer1Win()
        {
            // Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player1 = Choice.Rock;
            Choice player2 = Choice.Scissor;
            string expected = "Player 1 Win";

            // Act
            string result = game.CheckResult(player1, player2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_Player1Scissor_Player2Paper_ShouldReturnPlayer1Win()
        {
            // Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player1 = Choice.Scissor;
            Choice player2 = Choice.Paper;
            string expected = "Player 1 Win";

            // Act
            string result = game.CheckResult(player1, player2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]  
        public void CheckResult_Player1Paper_Player2Rock_ShouldReturnPlayer1Win()
        {
            //Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player1 = Choice.Paper;
            Choice player2 = Choice.Rock;
            string expected = "Player 1 Win";

           //Act
           string result = game.CheckResult(player1, player2);

           //Assert
           Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_Player2Rock_Player1Scissor_ShouldReturnPlayer2Win()
        {
            // Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player2 = Choice.Rock;
            Choice player1 = Choice.Scissor;
            string expected = "Player 2 Win";

            // Act
            string result = game.CheckResult(player1, player2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_Player2Scissor_Player1Paper_ShouldReturnPlayer2Win()
        {
            // Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player2 = Choice.Scissor;
            Choice player1 = Choice.Paper;
            string expected = "Player 2 Win";

            // Act
            string result = game.CheckResult(player1, player2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_Player2Paper_Player1Rock_ShouldReturnPlayer2Win()
        {
            //Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player2 = Choice.Paper;
            Choice player1 = Choice.Rock;
            string expected = "Player 2 Win";

            //Act
            string result = game.CheckResult(player1, player2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_Player1Paper_Player2Paper_ShouldReturnDraw()
        {
            //Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player2 = Choice.Paper;
            Choice player1 = Choice.Paper;
            string expected = "Draw";

            //Act
            string result = game.CheckResult(player1, player2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_Player1Rock_Player2Rock_ShouldReturnDraw()
        {
            //Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player2 = Choice.Rock;
            Choice player1 = Choice.Rock;
            string expected = "Draw";

            //Act
            string result = game.CheckResult(player1, player2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_Player1Scissor_Player2Scissor_ShouldReturnDraw()
        {
            //Arrange
            KeoBuaBao game = new KeoBuaBao();
            Choice player2 = Choice.Scissor;
            Choice player1 = Choice.Scissor;
            string expected = "Draw";

            //Act
            string result = game.CheckResult(player1, player2);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckResult_ShouldThrowException_WhenPlayer1ChoiceIsInvalid()
        {
            KeoBuaBao game = new KeoBuaBao();

            Assert.Throws<ArgumentException>(() => game.CheckResult((Choice)100, Choice.Rock));
        }

        [Fact]
        public void CheckResult_ShouldThrowException_WhenPlayer2ChoiceIsInvalid()
        {
            //Arrange
            KeoBuaBao game = new KeoBuaBao();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => game.CheckResult(Choice.Rock, (Choice)100));
        }

        [Fact]
        public void CheckResult_ShouldThrowException_WhenBothChoicesAreInvalid()
        {
            // Arrange
            KeoBuaBao game = new KeoBuaBao();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => game.CheckResult((Choice)999, (Choice)100));
        }
    }
}