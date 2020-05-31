using System.Collections.Generic;
using System;
using HybridizerRefrigitz;
public class GlobalMembersUci
{
    public static ArtificialInteligenceMove t;
    /*
	  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
	  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
	  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
	
	  Stockfish is free software: you can redistribute it and/or modify
	  it under the terms of the GNU General Public License as published by
	  the Free Software Foundation, either version 3 of the License, or
	  (at your option) any later version.
	
	  Stockfish is distributed in the hope that it will be useful,
	  but WITHOUT ANY WARRANTY; without even the implied warranty of
	  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	  GNU General Public License for more details.
	
	  You should have received a copy of the GNU General Public License
	  along with this program.  If not, see <http://www.gnu.org/licenses/>.
	*/




    //void benchmark(Position pos, istream @is);

    // FEN string of the initial position, normal chess
    public static string StartFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";


    // position() is called when engine receives the "position" UCI command.
    // The function sets up the position described in the given FEN string ("fen")
    // or the starting position ("startpos") and then makes the moves given in the
    // following move list ("moves").

    public static void position(//Position pos, istringstream @is
        )
    {

       /* Move m;
        
        string token;
        string fen;

        @is >> token;

        if (token == "startpos")
        {
            fen = ((char)StartFEN).ToString();
            @is >> token; // Consume "moves" token if any
        }
        else if (token == "fen")
        {
            while (@is >> token && token != "moves")
            {
                fen += token + " ";
            }
        }
        else
            return;

        pos.set(fen, GlobalMembersUcioption.Options["UCI_Chess960"], GlobalMembersThread.Threads.main());
#if StateStackPtr_ConditionalDefinition1
		SetupStates = std.auto_ptr<Stack<StateInfo>>(new Stack<StateInfo>());
#elif StateStackPtr_ConditionalDefinition2
		SetupStates = std.auto_ptr<Stack<StateInfo>>(new Stack<StateInfo>());
#else
        SetupStates = Search.StateStackPtr(new Stack<StateInfo>());
#endif

        // Parse move list (if any)
        while (@is >> token && (m = GlobalMembersUci.to_move(pos, token)) != Move.MOVE_NONE)
        {
            SetupStates.push(new StateInfo());
            pos.do_move(m, SetupStates.top());
        }
        */
    }


    // setoption() is called when engine receives the "setoption" UCI command. The
    // function updates the UCI option ("name") to the given value ("value").

    public enum Color
    {
        WHITE,
        BLACK,
        NO_COLOR,
        COLOR_NB = 2
    }
    public static void setoption(int c,int a//istringstream @is//temporary partameters
        )
    {
        /*
        string token;
        string name;
        string value;

        //@is >> token; // Consume "name" token

        // Read option name (can contain spaces)
        while (@is >> token && token != "value")
        {
            name += (string)(" ", !string.IsNullOrEmpty(name)) + token;
        }

        // Read option value (can contain spaces)
        while (@is >> token)
        {
            value += (string)(" ", !string.IsNullOrEmpty(value)) + token;
        }

        if (GlobalMembersUcioption.Options.count(name))
        {
            GlobalMembersUcioption.Options[name] = value;
        }
        else
        {
            sync_cout << "No such option: " << name << sync_endl;
        }*/
    }

    // position() is called when engine receives the "position" UCI command.
    // The function sets up the position described in the given FEN string ("fen")
    // or the starting position ("startpos") and then makes the moves given in the
    // following move list ("moves").
    static string Next(ref string Is)
    {
        string m = "";
        try
        {
            m = Is.Substring(0, Is.IndexOf(" "));
            Is = Is.Substring(Is.IndexOf(" ") + 1);
        }
        catch (Exception t)
        {
            return null;

        }


        return m;

    }

    public static void position(Position pos, string Is //temporary parameter.
          )
	  {

		//Move m;
		string token;
		string fen="";

		token=Next(ref Is);
		if (token == "startpos")
		{
			fen = StartFEN.ToString();
            token = Next(ref Is); // Consume "moves" token if any
		}
		else if (token == "fen")
		{
            token = Next(ref Is);

            while (token!=null && token != "moves")
			{
				fen += token + " ";
                token = Next(ref Is);
            }
		}
		else
			return;
        
		pos.set(fen, GlobalMembersUcioption.Options["UCI_Chess960"], GlobalMembersThread.Threads.main());
	#if StateStackPtr_ConditionalDefinition1
		SetupStates = std.auto_ptr<Stack<StateInfo>>(new Stack<StateInfo>());
	#elif StateStackPtr_ConditionalDefinition2
		SetupStates = std.auto_ptr<Stack<StateInfo>>(new Stack<StateInfo>());
	#else
		SetupStates = Search.StateStackPtr(new Stack<StateInfo>());
	#endif

		// Parse move list (if any)
		while (@is >> token && (m = GlobalMembersUci.to_move(pos, token)) != Move.MOVE_NONE)
		{
			SetupStates.push(new StateInfo());
			pos.do_move(m, SetupStates.top());
		}
    }


    // setoption() is called when engine receives the "setoption" UCI command. The
    // function updates the UCI option ("name") to the given value ("value").

    public static void setoption(string Is//istringstream @is
          )
	  {
        
		string token;
		string name;
		string value;

        token = Next(ref Is);

        // Read option name (can contain spaces)
        token = Next(ref Is);

        while (token != null && token != "value")
        {
            //name += (string)(" ", !string.IsNullOrEmpty(name)) + token;
            token = Next(ref Is);
        }

        // Read option value (can contain spaces)
        token = Next(ref Is);
        while (token != null)
        {
            //value += (string)(" ", !string.IsNullOrEmpty(value)) + token;
            token = Next(ref Is);
        }


        /*	  if (GlobalMembersUcioption.Options.count(name))
         {
             GlobalMembersUcioption.Options[name] = value;
         }
         else
         {
             sync_cout << "No such option: " << name << sync_endl;
         }*/
    }


    // go() is called when engine receives the "go" UCI command. The function sets
    // the thinking time and other parameters from the input string, then starts
    // the search.

    public static void go(string Is,Position pos//, istringstream @is //int a is for distinguiish temporarly
          )
	  {

        Search.LimitsType limits = new Search.LimitsType();
        string token = "";

        token = Next(ref Is);
        while (token != null)
        {
            if (token == "searchmoves"
                )
            {
                token = Next(ref Is);

                while (token != null)
                {
                    limits.searchmoves.Add(GlobalMembersUci.to_move(pos, token));
                    token = Next(ref Is);
                }
            }

			else if (token == "wtime")
			{
                limits.time[(int)Color.WHITE] = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "btime")
			{
				limits.time[(int)Color.BLACK] = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "winc")
			{
				limits.inc[(int)Color.WHITE] = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "binc")
			{
				limits.inc[(int)Color.BLACK] = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "movestogo")
			{
				limits.movestogo = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "depth")
			{
				limits.depth = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "nodes")
			{
				limits.nodes = System.Convert.ToInt64(Next(ref Is));
            }
			else if (token == "movetime")
			{
				limits.movetime = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "mate")
			{
				 limits.mate = System.Convert.ToInt32(Next(ref Is));
            }
			else if (token == "infinite")
			{
				limits.infinite = true;
			}
			else if (token == "ponder")
			{
				limits.ponder = true;
			}
            token = Next(ref Is);

        }

        //GlobalMembersThread.Threads.start_thinking(pos, limits, SetupStates);

    }
    void loop(string[] argv)
    {

        //Position pos;
        string token = "", cmd = "";

        //pos.set(StartFEN, false, &States->back(), Threads.main());

        for (int i = 1; i < argv.Length; ++i)
            cmd += (argv[i]).ToString() + " ";

        do
        {

            if (argv.Length == 1 && cmd == "") // Block here waiting for input or EOF
                cmd = "quit";

            // istringstream is (cmd);

            token = ""; // getline() could return empty or blank line
                        //is >> skipws >> token;

            // The GUI sends 'ponderhit' to tell us to ponder on the same move the
            // opponent has played. In case Signals.stopOnPonderhit is set we are
            // waiting for 'ponderhit' to stop the search (for instance because we
            // already ran out of time), otherwise we should continue searching but
            // switching from pondering to normal search.
            if (token == "quit"
                || token == "stop"
                || (token == "ponderhit" && HybridizerRefrigitz.AllDraw.CalIdle == 0
                ))
            {
                if (HybridizerRefrigitz.AllDraw.CalIdle == 0)
                {
                    HybridizerRefrigitz.AllDraw.CalIdle = 2;
                    while (HybridizerRefrigitz.AllDraw.CalIdle != 1) { }
                }
                 Search::Signals.stop = true;
                // Threads.main()->start_searching(true); // Could be sleeping
            }
            else if (token == "ponderhit")
            {
                if (HybridizerRefrigitz.AllDraw.CalIdle == 0)
                {

                    HybridizerRefrigitz.AllDraw.CalIdle = 2;
                    while (HybridizerRefrigitz.AllDraw.CalIdle != 1) { };
                }

                //Search::Limits.ponder = 0; // Switch to normal search

            }
            else if (token == "uci")

            {
                //sync_cout << "id name " << engine_info(true)
                //     << "\n" << Options
                //    << "\nuciok" << sync_endl;

            }
            else if (token == "ucinewgame")


            {
                //Search::clear();
                //Time.availableNodes = 0;
            }
            else if (token == "isready")
            {
                //sync_cout << "readyok" << sync_endl;
            }

            else if (token == "go")
            {
                if (HybridizerRefrigitz.AllDraw.CalIdle == 0)
                {
                    HybridizerRefrigitz.AllDraw.CalIdle = 2;
                    while (HybridizerRefrigitz.AllDraw.CalIdle != 1) { }
                }
                t.t.Play(AllDraw.OrderPlate, -1);

                //go(pos, is);
            }

            else if (token == "position")
            {
                //position(pos, is);
            }

            else if (token == "setoption")
            {
                //setoption(is);
            }

            // Additional custom non-UCI commands, useful for debugging
            else if (token == "flip")
            {
                //pos.flip();
            }
            else if (token == "bench")
            {
                //benchmark(pos, is
            }
            else if (token == "d")
            {
                //sync_cout << pos << sync_endl;
            }
            else if (token == "eval")
            {
                //sync_cout << Eval::trace(pos) << sync_endl;
            }

            else if (token == "perft")
            {
                //int depth;
                //stringstream ss;

                //is >> depth;
                //ss << Options["Hash"] << " "
                //  << Options["Threads"] << " " << depth << " current perft";

                //  benchmark(pos, ss);
            }
            else
            {
                //sync_cout << "Unknown command: " << cmd << sync_endl;
            }

        } while (token != "quit" && argv.Length == 1); // Passed args have one-shot behaviour

        // Threads.main()->wait_for_search_finished();
    }
    /// UCI::to_move() converts a string representing a move in coordinate notation
    /// (g1f3, a7a8q) to the corresponding legal Move, if any.

    
    
}
namespace Search
{

    /// Stack struct keeps track of the information we need to remember from nodes
    /// shallower and deeper in the tree during the search. Each search thread has
    /// its own array of Stack objects, indexed by the current ply.

    public class Stack
    {
        //C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent for pointers to value types:
        //ORIGINAL LINE: Move* pv;
        public Move pv;
        public int ply;
        public Move currentMove;
        public Move excludedMove;
        public Move[] killers = new Move[2];
        public Value staticEval;
        public Value history;
        public bool skipEarlyPruning;
        public int moveCount;
        public Stats<Value, true> counterMoves;
    }


    /// RootMove struct is used for moves at the root of the tree. For each root move
    /// we store a score and a PV (really a refutation in the case of moves which
    /// fail low). Score is normally set at -VALUE_INFINITE for all non-pv moves.

    public class RootMove
    {

        public RootMove(Move m)
        {
            this.pv = new List<Move>(1, m);
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: bool operator <(const RootMove& m) const
        public static bool operator <(RootMove ImpliedObject, RootMove m) // Descending sort
        {
            return m.score < ImpliedObject.score;
        }
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: bool operator ==(const Move& m) const
        public static bool operator ==(RootMove ImpliedObject, Move m)
        {
            return ImpliedObject.pv[0] == m;
        }
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        //  bool extract_ponder_from_tt(Position pos);

        public Value score = -Value.VALUE_INFINITE;
        public Value previousScore = -Value.VALUE_INFINITE;
        public List<Move> pv = new List<Move>();
    }



    /// LimitsType struct stores information sent by GUI about available time to
    /// search the current move, maximum depth/time, if we are in analysis mode or
    /// if we have to ponder while it's our opponent's turn to move.

    public class LimitsType
    {

        public LimitsType() // Init explicitly due to broken value-initialization of non POD in MSVC
        {
            nodes = time[(int)Color.WHITE] = time[(int)Color.BLACK] = inc[(int)Color.WHITE] = inc[(int)Color.BLACK] = npmsec = movestogo = depth = movetime = mate = infinite = ponder = 0;
        }

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: bool use_time_management() const
        public bool use_time_management()
        {
            return !(mate | movetime | depth | nodes | infinite);
        }

        public List<Move> searchmoves = new List<Move>();
        public int[] time = new int[(int)Color.COLOR_NB];
        public int[] inc = new int[(int)Color.COLOR_NB];
        public int npmsec;
        public int movestogo;
        public int depth;
        public int movetime;
        public int mate;
        public int infinite;
        public int ponder;
        public long nodes;
        public std.chrono.milliseconds.rep startTime = new std.chrono.milliseconds.rep();
    }


    /// SignalsType struct stores atomic flags updated during the search, typically
    /// in an async fashion e.g. to stop the search by the GUI.

    public class SignalsType
    {
        public std.atomic_bool stop = new std.atomic_bool();
        public std.atomic_bool stopOnPonderhit = new std.atomic_bool();
    }

} // namespace Search
public enum Move : int
{
    MOVE_NONE,
    MOVE_NULL = 65
}

public enum PieceType
{
    NO_PIECE_TYPE,
    PAWN,
    KNIGHT,
    BISHOP,
    ROOK,
    QUEEN,
    KING,
    ALL_PIECES = 0,
    PIECE_TYPE_NB = 8
}
public enum Piece
{
    NO_PIECE,
    W_PAWN = 1,
    W_KNIGHT,
    W_BISHOP,
    W_ROOK,
    W_QUEEN,
    W_KING,
    B_PAWN = 9,
    B_KNIGHT,
    B_BISHOP,
    B_ROOK,
    B_QUEEN,
    B_KING,
    PIECE_NB = 16
}
public enum Square
{
    SQ_A1,
    SQ_B1,
    SQ_C1,
    SQ_D1,
    SQ_E1,
    SQ_F1,
    SQ_G1,
    SQ_H1,
    SQ_A2,
    SQ_B2,
    SQ_C2,
    SQ_D2,
    SQ_E2,
    SQ_F2,
    SQ_G2,
    SQ_H2,
    SQ_A3,
    SQ_B3,
    SQ_C3,
    SQ_D3,
    SQ_E3,
    SQ_F3,
    SQ_G3,
    SQ_H3,
    SQ_A4,
    SQ_B4,
    SQ_C4,
    SQ_D4,
    SQ_E4,
    SQ_F4,
    SQ_G4,
    SQ_H4,
    SQ_A5,
    SQ_B5,
    SQ_C5,
    SQ_D5,
    SQ_E5,
    SQ_F5,
    SQ_G5,
    SQ_H5,
    SQ_A6,
    SQ_B6,
    SQ_C6,
    SQ_D6,
    SQ_E6,
    SQ_F6,
    SQ_G6,
    SQ_H6,
    SQ_A7,
    SQ_B7,
    SQ_C7,
    SQ_D7,
    SQ_E7,
    SQ_F7,
    SQ_G7,
    SQ_H7,
    SQ_A8,
    SQ_B8,
    SQ_C8,
    SQ_D8,
    SQ_E8,
    SQ_F8,
    SQ_G8,
    SQ_H8,
    SQ_NONE,

    SQUARE_NB = 64,

    NORTH = 8,
    EAST = 1,
    SOUTH = -8,
    WEST = -1,

    NORTH_EAST = NORTH + EAST,
    SOUTH_EAST = SOUTH + EAST,
    SOUTH_WEST = SOUTH + WEST,
    NORTH_WEST = NORTH + WEST
}



public class Position
{
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  static void init();

    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Position();
    //C++ TO C# CONVERTER TODO TASK: C# has no equivalent to ' = delete':
    //ORIGINAL LINE: Position(const Position&) = delete;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Position(Position NamelessParameter);
    //C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
    //ORIGINAL LINE: Position& operator =(const Position&) = delete;
    //C++ TO C# CONVERTER TODO TASK: C# has no equivalent to ' = delete':
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Position CopyFrom(Position NamelessParameter);

    // FEN string input/output
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Position set(string fenStr, bool isChess960, StateInfo si, Thread th);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: const string fen() const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  string fen();

    // Position representation
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pieces() const
    public ulong pieces()
    {
        return byTypeBB[(int)PieceType.ALL_PIECES];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pieces(PieceType pt) const
    public ulong pieces(PieceType pt)
    {
        return byTypeBB[(int)pt];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pieces(PieceType pt1, PieceType pt2) const
    public ulong pieces(PieceType pt1, PieceType pt2)
    {
        return byTypeBB[(int)pt1] | byTypeBB[(int)pt2];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pieces(Color c) const
    public ulong pieces(Color c)
    {
        return byColorBB[(int)c];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pieces(Color c, PieceType pt) const
    public ulong pieces(Color c, PieceType pt)
    {
        return byColorBB[(int)c] & byTypeBB[(int)pt];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pieces(Color c, PieceType pt1, PieceType pt2) const
    public ulong pieces(Color c, PieceType pt1, PieceType pt2)
    {
        return byColorBB[(int)c] & (byTypeBB[(int)pt1] | byTypeBB[(int)pt2]);
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Piece piece_on(Square s) const
    public Piece piece_on(Square s)
    {
        return board[(int)s];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Square ep_square() const
    public Square ep_square()
    {
        return st.epSquare;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool empty(Square s) const
    public bool empty(Square s)
    {
        return board[(int)s] == Piece.NO_PIECE;
    }
    //C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
    //ORIGINAL LINE: template<PieceType Pt>
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline int count(Color c) const
    public int count<PieceType Pt>(Color c)
        {
        return pieceCount[(int)GlobalMembersBenchmark.make_piece(c, Pt)];
    }
    //C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
    //ORIGINAL LINE: template<PieceType Pt>
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline const Square* squares(Color c) const
    //C++ TO C# CONVERTER WARNING: C# has no equivalent to methods returning pointers to value types:
    public Square squares(<PieceType Pt>Color c)
    {
        return pieceList[(int)GlobalMembersBenchmark.make_piece(c, Pt)];
    }
    //C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
    //ORIGINAL LINE: template<PieceType Pt>
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Square square(Color c) const
    public Square square<PieceType Pt>(Color c)
        {
        Debug.Assert(pieceCount[(int)GlobalMembersBenchmark.make_piece(c, Pt)] == 1);
        return pieceList[(int)GlobalMembersBenchmark.make_piece(c, Pt), 0];
    }

    // Castling
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline int can_castle(Color c) const
    public int can_castle(Color c)
    {
        return st.castlingRights & (((int)CastlingRight.WHITE_OO | (int)CastlingRight.WHITE_OOO) << (2 * c));
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline int can_castle(CastlingRight cr) const
    public int can_castle(CastlingRight cr)
    {
        return st.castlingRights & (int)cr;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool castling_impeded(CastlingRight cr) const
    public bool castling_impeded(CastlingRight cr)
    {
        return byTypeBB[(int)PieceType.ALL_PIECES] & castlingPath[(int)cr];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Square castling_rook_square(CastlingRight cr) const
    public Square castling_rook_square(CastlingRight cr)
    {
        return castlingRookSquare[(int)cr];
    }

    // Checking
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong checkers() const
    public ulong checkers()
    {
        return st.checkersBB;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong discovered_check_candidates() const
    public ulong discovered_check_candidates()
    {
        return st.blockersForKing[~sideToMove] & pieces(sideToMove);
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pinned_pieces(Color c) const
    public ulong pinned_pieces(Color c)
    {
        return st.blockersForKing[(int)c] & pieces(c);
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong check_squares(PieceType pt) const
    public ulong check_squares(PieceType pt)
    {
        return st.checkSquares[(int)pt];
    }

    // Attacks to/from a given square
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong attackers_to(Square s) const
    public ulong attackers_to(Square s)
    {
        return attackers_to(s, byTypeBB[(int)PieceType.ALL_PIECES]);
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: ulong attackers_to(Square s, ulong occupied) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  ulong attackers_to(Square s, ulong occupied);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong attacks_from(Piece pc, Square s) const
    public ulong attacks_from(Piece pc, Square s)
    {
        return GlobalMembersBenchmark.attacks_bb(pc, s, byTypeBB[(int)PieceType.ALL_PIECES]);
    }
    //C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
    //ORIGINAL LINE: template<PieceType>
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong attacks_from(Square s) const
    public ulong attacks_from<PieceType>(Square s)
    {
        return Pt == PieceType.BISHOP || Pt == ((int)PieceType.ROOK) != 0 ? attacks_bb<Pt>(s, byTypeBB[(int)PieceType.ALL_PIECES]) : Pt == ((int)PieceType.QUEEN) != 0 ? attacks_from<PieceType.ROOK>(s) | attacks_from<PieceType.BISHOP>(s) : GlobalMembersBitboard.StepAttacksBB[Pt, (int)s];
    }
    //C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
    //ORIGINAL LINE: template<PieceType>
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong attacks_from<PAWN>(Square s, Color c) const
    public ulong attacks_from<PieceType>(Square s, Color c)
    {
        return GlobalMembersBitboard.StepAttacksBB[(int)GlobalMembersBenchmark.make_piece(c, PieceType.PAWN), (int)s];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: ulong slider_blockers(ulong sliders, Square s, ulong& pinners) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  ulong slider_blockers(ulong sliders, Square s, ref ulong pinners);

    // Properties of moves
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: bool legal(Move m) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  bool legal(Move m);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: bool pseudo_legal(const Move m) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  bool pseudo_legal(Move m);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool capture(Move m) const
    public bool capture(Move m)
    {
        Debug.Assert(GlobalMembersBenchmark.is_ok(m));
        // Castling is encoded as "king captures rook"
        return (!empty(GlobalMembersBenchmark.to_sq(m)) && GlobalMembersBenchmark.type_of(m) != MoveType.CASTLING) || GlobalMembersBenchmark.type_of(m) == MoveType.ENPASSANT;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool capture_or_promotion(Move m) const
    public bool capture_or_promotion(Move m)
    {
        Debug.Assert(GlobalMembersBenchmark.is_ok(m));
        return GlobalMembersBenchmark.type_of(m) != ((int)MoveType.NORMAL) != 0 ? GlobalMembersBenchmark.type_of(m) != MoveType.CASTLING : !empty(GlobalMembersBenchmark.to_sq(m));
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: bool gives_check(Move m) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  bool gives_check(Move m);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool advanced_pawn_push(Move m) const
    public bool advanced_pawn_push(Move m)
    {
        return GlobalMembersBenchmark.type_of(moved_piece(m)) == PieceType.PAWN && GlobalMembersBenchmark.relative_rank(sideToMove, GlobalMembersBenchmark.from_sq(m)) > Rank.RANK_4;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Piece moved_piece(Move m) const
    public Piece moved_piece(Move m)
    {
        return board[(int)GlobalMembersBenchmark.from_sq(m)];
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Piece captured_piece() const
    public Piece captured_piece()
    {
        return st.capturedPiece;
    }

    // Piece specific
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool pawn_passed(Color c, Square s) const
    public bool pawn_passed(Color c, Square s)
    {
        return !(pieces(~c, PieceType.PAWN) & GlobalMembersBenchmark.passed_pawn_mask(c, s));
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool opposite_bishops() const
    public bool opposite_bishops()
    {
        return pieceCount[(int)Piece.W_BISHOP] == 1 && pieceCount[(int)Piece.B_BISHOP] == 1 && GlobalMembersBenchmark.opposite_colors(square<PieceType.BISHOP>(Color.WHITE), square<PieceType.BISHOP>(Color.BLACK));
    }

    // Doing and undoing moves
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void do_move(Move m, StateInfo st, bool givesCheck);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void undo_move(Move m);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void do_null_move(StateInfo st);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void undo_null_move();

    // Static Exchange Evaluation
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: bool see_ge(Move m, Value value) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  bool see_ge(Move m, Value value);

    // Accessing hash keys
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong key() const
    public ulong key()
    {
        return st.key;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: ulong key_after(Move m) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  ulong key_after(Move m);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong material_key() const
    public ulong material_key()
    {
        return st.materialKey;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong pawn_key() const
    public ulong pawn_key()
    {
        return st.pawnKey;
    }

    // Other properties of the position
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Color side_to_move() const
    public Color side_to_move()
    {
        return sideToMove;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: Phase game_phase() const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Phase game_phase();
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline int game_ply() const
    public int game_ply()
    {
        return gamePly;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline bool is_chess960() const
    public bool is_chess960()
    {
        return chess960;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Thread* this_thread() const
    public Thread this_thread()
    {
        return thisThread;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline ulong nodes_searched() const
    public ulong nodes_searched()
    {
        return nodes;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: bool is_draw() const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  bool is_draw();
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline int rule50_count() const
    public int rule50_count()
    {
        return st.rule50;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Score psq_score() const
    public Score psq_score()
    {
        return st.psq;
    }
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: inline Value non_pawn_material(Color c) const
    public Value non_pawn_material(Color c)
    {
        return st.nonPawnMaterial[(int)c];
    }

    // Position consistency check, for debugging
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: bool pos_is_ok(int* failedStep = null) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  bool pos_is_ok(ref int failedStep);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void flip();

    // Initialization helpers (used while setting up a position)
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void set_castling_right(Color c, Square rfrom);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: void set_state(StateInfo* si) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void set_state(StateInfo si);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: void set_check_info(StateInfo* si) const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void set_check_info(StateInfo si);

    // Other helpers
    private void put_piece(Piece pc, Square s)
    {

        board[(int)s] = pc;
        byTypeBB[(int)PieceType.ALL_PIECES] |= s;
        byTypeBB[(int)GlobalMembersBenchmark.type_of(pc)] |= s;
        byColorBB[(int)GlobalMembersBenchmark.color_of(pc)] |= s;
        index[(int)s] = pieceCount[(int)pc]++;
        pieceList[(int)pc, index[(int)s]] = s;
        pieceCount[(int)GlobalMembersBenchmark.make_piece(GlobalMembersBenchmark.color_of(pc), PieceType.ALL_PIECES)]++;
    }
    private void remove_piece(Piece pc, Square s)
    {

        // WARNING: This is not a reversible operation. If we remove a piece in
        // do_move() and then replace it in undo_move() we will put it at the end of
        // the list and not in its original place, it means index[] and pieceList[]
        // are not invariant to a do_move() + undo_move() sequence.
        byTypeBB[(int)PieceType.ALL_PIECES] ^= s;
        byTypeBB[(int)GlobalMembersBenchmark.type_of(pc)] ^= s;
        byColorBB[(int)GlobalMembersBenchmark.color_of(pc)] ^= s;
        /* board[s] = NO_PIECE;  Not needed, overwritten by the capturing one */
        Square lastSquare = pieceList[(int)pc, --pieceCount[(int)pc]];
        index[(int)lastSquare] = index[(int)s];
        pieceList[(int)pc, index[(int)lastSquare]] = lastSquare;
        pieceList[(int)pc, pieceCount[(int)pc]] = Square.SQ_NONE;
        pieceCount[(int)GlobalMembersBenchmark.make_piece(GlobalMembersBenchmark.color_of(pc), PieceType.ALL_PIECES)]--;
    }
    private void move_piece(Piece pc, Square from, Square to)
    {

        // index[from] is not updated and becomes stale. This works as long as index[]
        // is accessed just by known occupied squares.
        ulong from_to_bb = GlobalMembersBitboard.SquareBB[(int)from] ^ GlobalMembersBitboard.SquareBB[(int)to];
        byTypeBB[(int)PieceType.ALL_PIECES] ^= from_to_bb;
        byTypeBB[(int)GlobalMembersBenchmark.type_of(pc)] ^= from_to_bb;
        byColorBB[(int)GlobalMembersBenchmark.color_of(pc)] ^= from_to_bb;
        board[(int)from] = Piece.NO_PIECE;
        board[(int)to] = pc;
        index[(int)to] = index[(int)from];
        pieceList[(int)pc, index[(int)to]] = to;
    }
    //C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
    //ORIGINAL LINE: template<bool Do>
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void do_castling<bool Do>(Color us, Square from, Square to, Square rfrom, Square rto);

    // Data members
    private Piece[] board = new Piece[(int)Square.SQUARE_NB];
    private ulong[] byTypeBB = new ulong[(int)PieceType.PIECE_TYPE_NB];
    private ulong[] byColorBB = new ulong[(int)Color.COLOR_NB];
    private int[] pieceCount = new int[(int)Piece.PIECE_NB];
    private Square[,] pieceList = new Square[(int)Piece.PIECE_NB, 16];
    private int[] index = new int[(int)Square.SQUARE_NB];
    private int[] castlingRightsMask = new int[(int)Square.SQUARE_NB];
    private Square[] castlingRookSquare = new Square[(int)CastlingRight.CASTLING_RIGHT_NB];
    private ulong[] castlingPath = new ulong[(int)CastlingRight.CASTLING_RIGHT_NB];
    private ulong nodes;
    private int gamePly;
    private Color sideToMove;
    private Thread thisThread;
    private StateInfo st;
    private bool chess960;
}

//C++ TO C# CONVERTER NOTE: C# does not allow anonymous namespaces:
//namespace



/// UCI::loop() waits for a command from stdin, parses it and calls the appropriate
/// function. Also intercepts EOF from stdin to ensure gracefully exiting if the
/// GUI dies unexpectedly. When called with some command line arguments, e.g. to
/// run 'bench', once the command is executed the function returns immediately.
/// In addition to the UCI ones, also some additional debug commands are supported.



/// UCI::value() converts a Value to a string suitable for use with the UCI
/// protocol specification:
///
/// cp <x>    The score from the engine's point of view in centipawns.
/// mate <y>  Mate in y moves, not plies. If the engine is getting mated
///           use negative values for y.



/// UCI::square() converts a Square to a string in algebraic notation (g1, a7, etc.)



/// UCI::move() converts a Move to a string in coordinate notation (g1f3, a7a8q).
/// The only special case is castling, where we print in the e1g1 notation in
/// normal chess mode, and in e1h1 notation in chess960 mode. Internally all
/// castling moves are always encoded as 'king captures rook'.



/// UCI::to_move() converts a string representing a move in coordinate notation
/// (g1f3, a7a8q) to the corresponding legal Move, if any.

