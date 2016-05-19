using AmpLib.TCG.Cards.Heros;

namespace AmpLib.TCG.Board
{
    public class Board
    {
        public Hero Player1 { get; set; }
        public Hero Player2 { get; set; }

        private Board() { }

        //public static Board InitializeBoard(int player1Selection, int player2Selection)
        //{
        //    var board = new Board();

        //    if (player1Selection == 1)
        //    {
        //        board.Player1 = new MageHero("Mage", 20, 15);
        //    }
            
        //    if (player2Selection == 1)
        //    {
        //        board.Player2 = new MageHero("Mage", 20, 15);
        //    }
            
        //    return board;
        //}
    }
}