using System.Collections.Generic;
using System;
using HybridizerRefrigitz;
public class GlobalMembersUci
{
    public static ArtificialInteligenceMove t;
    




    //void benchmark(Position pos, istream @is);

    // FEN string of the initial position, normal chess
    public static string StartFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";





    // setoption() is called when engine receives the "setoption" UCI command. The
    // function updates the UCI option ("name") to the given value ("value").

    static string IsNullOrEmpty(string name)

    {
        if (name != null)
        {
            if (name != "")
                return name;
        }

        return " ";
    }
   
    public static void setoption(int c,int a//istringstream @is//temporary partameters
        )
    {
        
        string token;
        string name = "";
        string value = "";

        token = Next(ref Is);
        // Read option name (can contain spaces)
        while (token != "value")
        {
           name += IsNullOrEmpty(name) + token;
        }

        token = Next(ref Is);

        // Read option value (can contain spaces)
        while (token !=null)
        {
           value += IsNullOrEmpty(value) + token;
        }

        if (GlobalMembersUcioption.Options.count(name))
        {
            GlobalMembersUcioption.Options[name] = value;
        }
        else
        {
            Console.WriteLine("No such option: " + name +"\r\n");
        }
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
            token = Console.ReadLine();
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
                t.t.Play(-1, -1);//remain fen
            }
            else if (token == "ponderhit")
            {
                HybridizerRefrigitz.AllDraw.CalIdle = 0;
                

      
            }
            else if (token == "uci")

            {
                //sync_cout << "id name " << engine_info(true)
                //     << "\n" << Options
                //    << "\nuciok" << sync_endl;

            }
            else if (token == "ucinewgame")


            {
                t.t.Form1_Load();

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


    /// The Stats struct stores moves statistics. According to the template parameter
    /// the class can store History and Countermoves. History records how often
    /// different moves have been successful or unsuccessful during the current search
    /// and is used for reduction and move ordering decisions.
    /// Countermoves store the move that refute a previous one. Entries are stored
    /// using only the moving piece and destination square, hence two moves with
    /// different origin but same destination and piece will be considered identical.
    //C++ TO C# CONVERTER TODO TASK: C++ template specifiers containing defaults cannot be converted to C#:
    //ORIGINAL LINE: template<typename T, bool CM = false>
    public class Stats<T, bool CM = false>
    {

        public Value Max = new Value(1 << 28);

        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: const T* operator [](Piece pc) const
        public T this[Piece pc]
        {
            get
            {
                return table[(int)pc];
            }
        }
        public T this[Piece pc]
        {
            get
            {
                return table[(int)pc];
            }
        }
        public void clear()
        {
            std.memset(table, 0, sizeof(T));
        }
        public void update(Piece pc, Square to, Move m)
        {
            table[(int)pc, (int)to] = m;
        }
        public void update(Piece pc, Square to, Value v)
        {

            if (Math.Abs((int)v) >= 324)
                return;

            table[(int)pc, (int)to] -= table[(int)pc, (int)to] * Math.Abs((int)v) / (CM ? 936 : 324);
            table[(int)pc, (int)to] += (int)v * 32;
        }

        private T[,] table = new T[(int)Piece.PIECE_NB, (int)Square.SQUARE_NB];
    }

    public enum Value : int
    {
        VALUE_ZERO = 0,
        VALUE_DRAW = 0,
        VALUE_KNOWN_WIN = 10000,
        VALUE_MATE = 32000,
        VALUE_INFINITE = 32001,
        VALUE_NONE = 32002,

        VALUE_MATE_IN_MAX_PLY = VALUE_MATE - 2 * MAX_PLY,
        VALUE_MATED_IN_MAX_PLY = -VALUE_MATE + 2 * MAX_PLY,

        PawnValueMg = 188,
        PawnValueEg = 248,
        KnightValueMg = 753,
        KnightValueEg = 832,
        BishopValueMg = 826,
        BishopValueEg = 897,
        RookValueMg = 1285,
        RookValueEg = 1371,
        QueenValueMg = 2513,
        QueenValueEg = 2650,

        MidgameLimit = 15258,
        EndgameLimit = 3915
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

/// Option class implements an option as defined by UCI protocol
public class Option
{

    private delegate void OnChange(Option NamelessParameter);


    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Option(OnChange);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Option(bool v, OnChange);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Option(string v, OnChange);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Option(int v, int min, int max, OnChange);

    //C++ TO C# CONVERTER NOTE: This 'CopyFrom' method was converted from the original C++ copy assignment operator:
    //ORIGINAL LINE: Option& operator =(const string&);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  Option CopyFrom(string NamelessParameter);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  void operator <<(Option NamelessParameter);
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: operator int() const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  operator int();
    //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
    //ORIGINAL LINE: operator string() const;
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  operator string();
    public static bool BestMove;
    //C++ TO C# CONVERTER TODO TASK: C# has no concept of a 'friend' function:
    //ORIGINAL LINE: friend std::ostream& operator <<(std::ostream&, const ClassicMap<string, Option, CaseInsensitiveLess>&);
    //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
    //  std::ostream operator <<(std::ostream NamelessParameter1, ClassicMap<string, Option, CaseInsensitiveLess>);

    private string defaultValue;
    private string currentValue;
    private string type;
    private int min;
    private int max;
    private uint idx;
    private OnChange on_change;
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


public enum Color
{
    WHITE,
    BLACK,
    NO_COLOR,
    COLOR_NB = 2
}
public class Position
{   bool BobSection = true;

    const string PieceToChar = "kqrnbp PBNRQK";

    float RowRealesedP = -1, ColumnRealeasedP = -1;
    float RowRealesed = -1, ColumnRealeased = -1;

    Position set(string fenStr)
    {
        return this;

    }

    String Alphabet()
    {
        Object O = new Object();
        lock (O)
        {
            String A = "";
            if (RowRealesed == 0)
                A = "a";
            else
                if (RowRealesed == 1)
                A = "b";
            else
                    if (RowRealesed == 2)
                A = "c";
            else
                        if (RowRealesed == 3)
                A = "d";
            else
                            if (RowRealesed == 4)
                A = "e";
            else
                                if (RowRealesed == 5)
                A = "f";
            else
                                    if (RowRealesed == 6)
                A = "g";
            else
                                        if (RowRealesed == 7)
                A = "h";
            return A;


        }
    }
    String Number()
    {
        Object O = new Object();
        lock (O)
        {
            String A = "";
            if (ColumnRealeased == 7)
                A = "0";
            else
                if (ColumnRealeased == 6)
                A = "1";
            else
                    if (ColumnRealeased == 5)
                A = "2";
            else
                        if (ColumnRealeased == 4)
                A = "3";
            else
                            if (ColumnRealeased == 3)
                A = "4";
            else
                                if (ColumnRealeased == 2)
                A = "5";
            else
                                    if (ColumnRealeased == 1)
                A = "6";
            else
                                        if (ColumnRealeased == 0)
                A = "7";
            return A;

        }
    }
    bool Empty(int Row, int Column)
    {
        Object O = new Object();
        lock (O)
        {
            bool S = false;
            if (GlobalMembersUci.t.t.Table[Row, Column] == 0)
                S = true;
            else
                S = false;
            return S;
        }
    }
    String Fen(int RowRealesed, int ColumnRealeased)
    {
        Object O = new Object();
        lock (O)
        {
            bool StartPos = false;
            if (RowRealesed == -1 || ColumnRealeased == -1)
                StartPos = true;

            int EmptyCnt;
            String ss = "";

            for (int r = 0; r <= 7; ++r)
            {
                for (int f = 0; f <= 7; ++f)
                {
                    for (EmptyCnt = 0; f <= 7 && Empty(f, r); ++f)
                        ++EmptyCnt;

                    if (EmptyCnt != 0)
                        ss += EmptyCnt;

                    if (f <= 7)
                        ss += PieceToChar[Piece_on(f, r)];
                }

                if (r != 7)
                    ss += '/';
            }
            if (!BobSection)
                ss += " w ";
            else
                ss += " b ";
            if (HybridizerRefrigitz.ChessRules.SmallKingCastleGray)
                ss += "K";

            if (HybridizerRefrigitz.ChessRules.BigKingCastleGray)
                ss += "Q";

            if (HybridizerRefrigitz.ChessRules.SmallKingCastleBrown)
                ss += "k";

            if (HybridizerRefrigitz.ChessRules.BigKingCastleBrown)
                ss += "q";

            if (!HybridizerRefrigitz.ChessRules.CastleKingAllowedGray && !HybridizerRefrigitz.ChessRules.CastleKingAllowedBrown)
                ss += '-';
            String S = " - ";

            if (!StartPos)
            {
                if (!BobSection)
                {
                    if (System.Math.Abs(GlobalMembersUci.t.t.Table[(int)RowRealesed, (int)ColumnRealeased]) == 1)
                    {
                        S = " ";
                        S += Alphabet() + ((int)(7 - ColumnRealeased)).ToString();
                        S += " ";
                    }
                }
                else
                {

                    if (System.Math.Abs(GlobalMembersUci.t.t.Table[(int)RowRealesed, (int)ColumnRealeased]) == 1)
                    {
                        S = " ";
                        S += Alphabet() + ((int)(7 - ColumnRealeased)).ToString();
                        S += " ";
                    }
                }
            }
            else
            {
                S = " ";
                S += "-";
                S += " ";
            }
            int StockMovebase = HybridizerRefrigitzForm.MovmentsNumber / 2;
            int StockMove = HybridizerRefrigitzForm.MovmentsNumber % 2;
            S += (StockMovebase).ToString() + " " + ((int)StockMove).ToString() + "\n";

            ss += S;

            //if (MovmentsNumber % 2 == 0 && MovmentsNumber != 0)
            //   StockMovebase++;
            //else
            //    StockMove++;

            ss = "position fen " + ss;

            return ss;



        }
    }
    int Piece_on(int Row, int Column)
    {
        Object O = new Object();
        lock (O)
        {
            return 6 + GlobalMembersUci.t.t.Table[Row, Column];
        }
    }//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
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
*/    private Piece[] board = new Piece[(int)Square.SQUARE_NB];
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

