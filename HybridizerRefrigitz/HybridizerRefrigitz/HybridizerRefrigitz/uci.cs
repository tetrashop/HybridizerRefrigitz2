using System.Collections.Generic;
using System;
using HybridizerRefrigitz;
public class GlobalMembersUci
{

    public const bool HasPopCnt = false;
    public const bool HasPext = false;

#if IS_64BIT
	public const bool Is64Bit = true;
#else
    public const bool Is64Bit = false;
#endif


    public const int MAX_MOVES = 256;
    public const int MAX_PLY = 128;
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

    public static void position(//Position pos, 
        string Is //temporary parameter.
          )
    {

        //Move m;
        string token;
        string fen = "";

        token = Next(ref Is);
        if (token == "startpos")
        {
            fen = StartFEN.ToString();
            token = Next(ref Is); // Consume "moves" token if any
        }
        else if (token == "fen")
        {
            token = Next(ref Is);

            while (token != null && token != "moves")
            {
                fen += token + " ";
                token = Next(ref Is);
            }
        }
        else
            return;

        //pos.set(fen, GlobalMembersUcioption.Options["UCI_Chess960"], GlobalMembersThread.Threads.main());
        /*#if StateStackPtr_ConditionalDefinition1
            SetupStates = std.auto_ptr<Stack<StateInfo>>(new Stack<StateInfo>());
        #elif StateStackPtr_ConditionalDefinition2
            SetupStates = std.auto_ptr<Stack<StateInfo>>(new Stack<StateInfo>());
        #else
            SetupStates = Search.StateStackPtr(new Stack<StateInfo>());
        #endif
        */
        // Parse move list (if any)
        /*token = Next(ref Is);
        Move m;
        while (token!=null && (m = GlobalMembersUci.to_move(pos, token)) != Move.MOVE_NONE)
        {
            SetupStates.push(new StateInfo());
            pos.do_move(m, SetupStates.top());
        }*/
    }

    
    public static void go(string Is//, Position pos//, istringstream @is //int a is for distinguiish temporarly
          )
    {

        //Search.LimitsType limits = new Search.LimitsType();
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
                    //limits.searchmoves.Add(GlobalMembersUci.to_move(pos, token));
                    token = Next(ref Is);
                }
            }

            else if (token == "wtime")
            {
               // limits.time[(int)Color.WHITE] = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "btime")
            {
              //  limits.time[(int)Color.BLACK] = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "winc")
            {
              //  limits.inc[(int)Color.WHITE] = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "binc")
            {
             //   limits.inc[(int)Color.BLACK] = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "movestogo")
            {
              //  limits.movestogo = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "depth")
            {
             //   limits.depth = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "nodes")
            {
              //  limits.nodes = System.Convert.ToInt64(Next(ref Is));
            }
            else if (token == "movetime")
            {
              //  limits.movetime = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "mate")
            {
             //   limits.mate = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "infinite")
            {
               // limits.infinite = true;
            }
            else if (token == "ponder")
            {
             //   limits.ponder = true;
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
  
}



    
    

 // namespace Search
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


public enum Color
{
    WHITE,
    BLACK,
    NO_COLOR,
    COLOR_NB = 2
}