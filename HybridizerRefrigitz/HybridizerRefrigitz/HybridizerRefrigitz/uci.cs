using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using HybridizerRefrigitz;
using System.Diagnostics;

public class GlobalMembersUci
{
    static Process myProcessO;
    static System.Threading.Thread tt = null;

    int i = 0;
    const string PieceToChar = "kqrnbp PBNRQK";


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
    private static object myProcess;





    // setoption() is called when engine receives the "setoption" UCI command. The
    // function updates the UCI option ("name") to the given value ("value").
    public static void Output()
    {
        /*ProcessStartInfo si = new ProcessStartInfo()
        {
            FileName = "HybridizerRefrigitz.exe",//"C:\\Program Files (x86)\\Arena\\Arena.exe",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            RedirectStandardOutput = true
        };

         myProcessO= new Process();
        myProcessO.StartInfo = si;
        try
        {
            // throws an exception on win98
            myProcessO.PriorityClass = ProcessPriorityClass.BelowNormal;
        }
        catch { }

        myProcessO.OutputDataReceived += new DataReceivedEventHandler(myProcess_OutputDataReceived);

        myProcessO.Start();
        myProcessO.BeginErrorReadLine();
        myProcessO.BeginOutputReadLine();*/
        object o = new object();
        lock (o)
        {
            do
            {
                string Is = "";
                if (ThinkingHybridizerRefrigitz.OutP != null && ThinkingHybridizerRefrigitz.OutP != ""
                       )
                {
                    Is = GlobalMembersUci.Next(ref ThinkingHybridizerRefrigitz.OutP);

                    // SendLine(Is);
                    Console.Write//Line
                        (
                        //"[UCI] "+
                        Is + " ");
                }
            } while (true);
        }
    }
    private static void SendLine(string command)
    {
        myProcessO.StandardInput.WriteLine(command);
        myProcessO.StandardInput.Flush();
    }
    private static void myProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        string text = e.Data;
        //Debug.WriteLine("[UCI] " + text);
    }

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
   public static string Next(ref string Is)
    {
       string m = "";
        try
        {
            if (Is.Length > 0)
            {
                if (Is.Contains(" "))
                {
                    m = Is.Substring(0, Is.IndexOf(" "));
                    Is = Is.Substring(Is.IndexOf(" ") + 1, Is.Length - Is.IndexOf(" ") - 1);

                }
                else
                {
                    m = Is;
                    Is = "";/// "quit";
                    return m;
                }
            }
        }
        catch (Exception t)
        {
            m = Is;
            Is = "";/// "quit";
            return m;

        }


        return m;

    }
    static void AlphabetRecurveFirst( String B)
    {
        Object O = new Object();
        lock (O)
        {
            String A = B[0].ToString();
            if (A == "a")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 0;
            else
                if (A == "b")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 1;
            else
                    if (A == "c")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 2;
            else
                        if (A == "d")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 3;
            else
                            if (A == "e")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 4;
            else
                                if (A == "f")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 5;
            else
                                    if (A == "g")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 6;
            else
                                        if (A == "h")
                GlobalMembersUci.t.t.R.CromosomRowFirst = 7;
            return;


        }
    }
    static void AlphabetRecurve(String B)
    {
        Object O = new Object();
        lock (O)
        {
            String A = B[2].ToString();
            if (A == "a")
                GlobalMembersUci.t.t.R.CromosomRow = 0;
            else
                if (A == "b")
                GlobalMembersUci.t.t.R.CromosomRow = 1;
            else
                    if (A == "c")
                GlobalMembersUci.t.t.R.CromosomRow = 2;
            else
                        if (A == "d")
                GlobalMembersUci.t.t.R.CromosomRow = 3;
            else
                            if (A == "e")
                GlobalMembersUci.t.t.R.CromosomRow = 4;
            else
                                if (A == "f")
                GlobalMembersUci.t.t.R.CromosomRow = 5;
            else
                                    if (A == "g")
                GlobalMembersUci.t.t.R.CromosomRow = 6;
            else
                                        if (A == "h")
                GlobalMembersUci.t.t.R.CromosomRow = 7;
            return;


        }
    }

    String Alphabet()
    {
        Object O = new Object();
        lock (O)
        {
            String A = "";
            if (GlobalMembersUci.t.t.R.CromosomRow == 0)
                A = "a";
            else
                if (GlobalMembersUci.t.t.R.CromosomRow == 1)
                A = "b";
            else
                    if (GlobalMembersUci.t.t.R.CromosomRow == 2)
                A = "c";
            else
                        if (GlobalMembersUci.t.t.R.CromosomRow == 3)
                A = "d";
            else
                            if (GlobalMembersUci.t.t.R.CromosomRow == 4)
                A = "e";
            else
                                if (GlobalMembersUci.t.t.R.CromosomRow == 5)
                A = "f";
            else
                                    if (GlobalMembersUci.t.t.R.CromosomRow == 6)
                A = "g";
            else
                                        if (GlobalMembersUci.t.t.R.CromosomRow == 7)
                A = "h";
            return A;


        }
    }
    int Piece_on(int Row, int Column)
    {
        Object O = new Object();
        lock (O)
        {
            return 6 + HybridizerRefrigitz.HybridizerRefrigitzForm.Table[Row, Column];
        }
    }
    bool Empty(int Row, int Column)
    {
        Object O = new Object();
        lock (O)
        {
            bool S = false;
            if (HybridizerRefrigitz.HybridizerRefrigitzForm.Table[Row, Column] == 0)
                S = true;
            else
                S = false;
            return S;
        }
    }
  
    public static void position(//Position pos, 
        ref string Is //temporary parameter.
          )
    {
        
        ChessLibrary.FenNotation r = new ChessLibrary.FenNotation(StartFEN);

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
        r.parse(fen);
        //target passent
        string move = r.move;
        if (move.Length == 4)
        {
            object o = new object();
            lock (o)
            {
                AlphabetRecurveFirst(move);
                GlobalMembersUci.t.t.R.CromosomColumnFirst = ((int)(7 - System.Convert.ToInt32(move[1])));

                AlphabetRecurve(move);
                GlobalMembersUci.t.t.R.CromosomColumn = ((int)(7 - System.Convert.ToInt32(move[3])));
                // HybridizerRefrigitzForm.Table[GlobalMembersUci.t.t.R.CromosomRow, GlobalMembersUci.t.t.R.CromosomColumn] = HybridizerRefrigitzForm.Table[GlobalMembersUci.t.t.R.CromosomRowFirst, GlobalMembersUci.t.t.R.CromosomColumnFirst];
                //  HybridizerRefrigitzForm.Table[GlobalMembersUci.t.t.R.CromosomRowFirst, GlobalMembersUci.t.t.R.CromosomColumnFirst] = 0;
                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRowFirst, GlobalMembersUci.t.t.R.CromosomColumnFirst);

                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRow, GlobalMembersUci.t.t.R.CromosomColumn);
            }
        }//castling
        else
         if (r.WK)
        {
            object o = new object();
            lock (o)
            {
                HybridizerRefrigitz.ChessRules.SmallKingCastleWHITE = true;

                int RowSource = 4;
                int ColumnSource = 0, ColumnDestination = 0;

                GlobalMembersUci.t.t.R.CromosomRowFirst = RowSource;
                GlobalMembersUci.t.t.R.CromosomColumnFirst = ColumnSource;
                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRowFirst, GlobalMembersUci.t.t.R.CromosomColumnFirst);

                GlobalMembersUci.t.t.R.CromosomRow = RowSource - 2;
                GlobalMembersUci.t.t.R.CromosomColumn = ColumnSource;
                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRow, GlobalMembersUci.t.t.R.CromosomColumn);
            }  //HybridizerRefrigitzForm.Table[RowSource - 1, ColumnDestination] = 4;
            //HybridizerRefrigitzForm.Table[RowSource - 2, ColumnDestination] = 6;
            //HybridizerRefrigitzForm.Table[RowSource, ColumnSource] = 0;
            //HybridizerRefrigitzForm.Table[7, ColumnSource] = 0;
        }
        else
             if (r.BK)
        {
            object o = new object();
            lock (o)
            {
                HybridizerRefrigitz.ChessRules.SmallKingCastleBLACK = true;

                int RowSource = 4;
                int ColumnSource = 7, ColumnDestination = 7;

                GlobalMembersUci.t.t.R.CromosomRowFirst = RowSource;
                GlobalMembersUci.t.t.R.CromosomColumnFirst = ColumnSource;
                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRowFirst, GlobalMembersUci.t.t.R.CromosomColumnFirst);

                GlobalMembersUci.t.t.R.CromosomRow = RowSource - 2;
                GlobalMembersUci.t.t.R.CromosomColumn = ColumnSource;
                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRow, GlobalMembersUci.t.t.R.CromosomColumn);
            } /*  HybridizerRefrigitzForm.Table[RowSource - 1, ColumnDestination] = -4;
               HybridizerRefrigitzForm.Table[RowSource - 2, ColumnDestination] = -6;
               HybridizerRefrigitzForm.Table[RowSource, ColumnSource] = 0;
               HybridizerRefrigitzForm.Table[0, ColumnSource] = 0;
           */
        }
        else
        if (r.WQ)
        {
            if (GlobalMembersUci.t.t.order == 1)
            {
                object o = new object();
                lock (o)
                {
                    HybridizerRefrigitz.ChessRules.BigKingCastleWHITE = true;

                    int RowSource = 4;
                    int ColumnSource = 0, ColumnDestination = 0;

                    GlobalMembersUci.t.t.R.CromosomRowFirst = RowSource;
                    GlobalMembersUci.t.t.R.CromosomColumnFirst = ColumnSource;
                    GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRowFirst, GlobalMembersUci.t.t.R.CromosomColumnFirst);

                    GlobalMembersUci.t.t.R.CromosomRow = RowSource + 2;
                    GlobalMembersUci.t.t.R.CromosomColumn = ColumnSource;
                    GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRow, GlobalMembersUci.t.t.R.CromosomColumn);
                } /*HybridizerRefrigitzForm.Table[RowSource + 1, ColumnDestination] = 4;
                        HybridizerRefrigitzForm.Table[RowSource + 2, ColumnDestination] = 6;
                        HybridizerRefrigitzForm.Table[RowSource, ColumnSource] = 0;

                        HybridizerRefrigitzForm.Table[7, ColumnSource] = 0;*/
            }
        }
        else
             if (r.BQ)
        {
            object o = new object();
            lock (o)
            {
                HybridizerRefrigitz.ChessRules.BigKingCastleBLACK = true;

                int RowSource = 4;
                int ColumnSource = 7, ColumnDestination = 7;

                GlobalMembersUci.t.t.R.CromosomRowFirst = RowSource;
                GlobalMembersUci.t.t.R.CromosomColumnFirst = ColumnSource;
                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRowFirst, GlobalMembersUci.t.t.R.CromosomColumnFirst);

                GlobalMembersUci.t.t.R.CromosomRow = RowSource + 2;
                GlobalMembersUci.t.t.R.CromosomColumn = ColumnSource;
                GlobalMembersUci.t.t.Play(GlobalMembersUci.t.t.R.CromosomRow, GlobalMembersUci.t.t.R.CromosomColumn);
            }   /*  HybridizerRefrigitzForm.Table[RowSource + 1, ColumnDestination] = -4;
      HybridizerRefrigitzForm.Table[RowSource + 2, ColumnDestination] = -6;
      HybridizerRefrigitzForm.Table[RowSource, ColumnSource] = 0;
      HybridizerRefrigitzForm.Table[0, ColumnSource] = 0;
 */
        }


        //pos.set(fen, UCIoption.Options["UCI_Chess960"], GlobalMembersThread.Threads.main());
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


    public static void go(ref string Is//, Position pos//, istringstream @is //int a is for distinguiish temporarly
          )
    {

        //Search.LimitsType limits = new Search.LimitsType();
        string token = "";

        token = Next(ref Is);
        while (token != null && token != "")
        {
            if (token == "searchmoves"
                )
            {
                token = Next(ref Is);

                while (token != null&&token!="")
                {
                    //limits.searchmoves.Add(GlobalMembersUci.to_move(pos, token));
                    token = Next(ref Is);
                }
            }

            else if (token == "wtime")
            {
                object o = new object();
                lock (o)
                {
                    AllDraw.wtime = System.Convert.ToInt32(Next(ref Is));
                }
                // limits.time[(int)Color.WHITE] = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "btime")
            {
                object o = new object();
                lock (o)
                {
                    AllDraw.btime = System.Convert.ToInt32(Next(ref Is));
                    //  limits.time[(int)Color.BLACK] = System.Convert.ToInt32(Next(ref Is));
                }
            }
            else if (token == "winc")
            {
                object o = new object();
                lock (o)
                {
                    AllDraw.winc = System.Convert.ToInt32(Next(ref Is));
                    //  limits.inc[(int)Color.WHITE] = System.Convert.ToInt32(Next(ref Is));
                }
            }
            else if (token == "binc")
            {
                object o = new object();
                lock (o)
                {
                    AllDraw.binc = System.Convert.ToInt32(Next(ref Is));
                    //   limits.inc[(int)Color.BLACK] = System.Convert.ToInt32(Next(ref Is));
                }
            }
            else if (token == "movestogo")
            {
              //  limits.movestogo = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "depth")
            {
                object o = new object();
                lock (o)
                {
                    AllDraw.MaxAStarGreedy = System.Convert.ToInt32(Next(ref Is));

                } //   limits.depth = System.Convert.ToInt32(Next(ref Is));
            }
            else if (token == "nodes")
            {
              //  limits.nodes = System.Convert.ToInt64(Next(ref Is));
            }
            else if (token == "movetime")
            {
                object o = new object();
                lock (o)
                {
                    AllDraw.TimeMax = System.Convert.ToInt32(Next(ref Is));
                    //  limits.movetime = System.Convert.ToInt32(Next(ref Is));
                }
            }
            else if (token == "mate")
            {
                object o = new object();
                lock (o)
                {
                    AllDraw.EndOfGame = true;
                    //   limits.mate = System.Convert.ToInt32(Next(ref Is));
                }
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
    static void setoption(ref string Is)
    {

        string token, name="" ,value="";

        token = Next(ref Is); ; // Consume "name" token

        // Read option name (can contain spaces)
        token = Next(ref Is);
        while (token!="" && token != "value") {
            if (name=="")
                name += " 0" + token;
            else
                name +=" 1" + token;
            token = Next(ref Is);
        }
        // Read option value (can contain spaces)
        token = Next(ref Is);
        while (token != "" && token != "value")
        {
            if (value == "")
                value += " 0" + token;
            else
                value += " 1" + token;
            token = Next(ref Is);
        }
       /*if (Options.count(name))
            Options[name] = value;
        else
            sync_cout << "No such option: " << name << sync_endl;
   */ }

    String Fen()
    {
        Object O = new Object();
        lock (O)
        {
            bool StartPos = false;
            if (GlobalMembersUci.t.t.R.CromosomRow == -1 || GlobalMembersUci.t.t.R.CromosomColumn == -1)
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
            if (!(GlobalMembersUci.t.t.order == 1))
                ss += " w ";
            else
                ss += " b ";
            if (HybridizerRefrigitz.ChessRules.SmallKingCastleWHITE)
                ss += "K";

            if (HybridizerRefrigitz.ChessRules.BigKingCastleWHITE)
                ss += "Q";

            if (HybridizerRefrigitz.ChessRules.SmallKingCastleBLACK)
                ss += "k";

            if (HybridizerRefrigitz.ChessRules.BigKingCastleBLACK)
                ss += "q";

            if (!HybridizerRefrigitz.ChessRules.CastleKingAllowedWHITE && !HybridizerRefrigitz.ChessRules.CastleKingAllowedBLACK)
                ss += '-';
            String S = " - ";

            if (!StartPos)
            {
                if (!(GlobalMembersUci.t.t.order == 1))
                {
                    if (System.Math.Abs(HybridizerRefrigitz.HybridizerRefrigitzForm.Table[(int)GlobalMembersUci.t.t.R.CromosomRow, (int)GlobalMembersUci.t.t.R.CromosomColumn]) == 1)
                    {
                        S = " ";
                        S += Alphabet() + ((int)(7 - GlobalMembersUci.t.t.R.CromosomColumn)).ToString();
                        S += " ";
                    }
                }
                else
                {

                    if (System.Math.Abs(HybridizerRefrigitz.HybridizerRefrigitzForm.Table[(int)GlobalMembersUci.t.t.R.CromosomRow, (int)GlobalMembersUci.t.t.R.CromosomColumn]) == 1)
                    {
                        S = " ";

                        S += Alphabet() + ((int)(7 - GlobalMembersUci.t.t.R.CromosomColumn)).ToString();
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
            int StockMovebase = HybridizerRefrigitz.HybridizerRefrigitzForm.MovmentsNumber / 2;
            int StockMove = HybridizerRefrigitz.HybridizerRefrigitzForm.MovmentsNumber % 2;
            S += (StockMovebase).ToString() + " " + ((int)StockMove).ToString() + "\n";

            ss += S;

            //if (MovmentsNumber % 2 == 0 && MovmentsNumber != 0)
            //   StockMovebase++;
            //else
            //    StockMove++;

            //ss = "position fen " + ss;

            return ss;
            //return fenS.ToString();


        }
    }
    public static void loop(string[] argv)
    {
        if (tt == null)
        {
            //string IsA = argv[0];
            var tt = new Task(() => GlobalMembersUci.Output());
            tt.Start();
        }
       /* else if (!tt.IsAlive)
        {
            string IsA = argv[0];
            var tt = new Task(() => GlobalMembersUci.Output());
            tt.Start();
        }
        */
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
            if (cmd != "quit")
            {

                cmd = Console.ReadLine();
                token = Next(ref cmd);

            }
            // The GUI sends 'ponderhit' to tell us to ponder on the same move the
            // opponent has played. In case Signals.stopOnPonderhit is set we are
            // waiting for 'ponderhit' to stop the search (for instance because we
            // already ran out of time), otherwise we should continue searching but
            // switching from pondering to normal search.
            if (token == "quit"
                || (token == "stop" && HybridizerRefrigitz.AllDraw.CalIdle == 1)
                || (token == "ponderhit" 
                ))
            {
             if((token == "quit"
                || token == "stop")&& HybridizerRefrigitz.AllDraw.CalIdle == 1)
                {
                    HybridizerRefrigitz.AllDraw.CalIdle = 2;
                    while (HybridizerRefrigitz.AllDraw.CalIdle != 5) { }
                    HybridizerRefrigitz.AllDraw.CalIdle=-1; }
                //t.t.Play(-1, -1);//remain fen
                //StartFEN = (new GlobalMembersUci()).Fen();
            }
            else if (token == "ponderhit")
            {
                HybridizerRefrigitz.AllDraw.CalIdle = 0;



            }
            else if (token == "uci")

            {
                Console.WriteLine("\nid name tetrashop.ir and faradars.org 2020 Hybridizer chess engine.");

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
                if (AllDraw.CalIdle == 0)
                    Console.WriteLine("\nreadyok");

                //sync_cout << "readyok" << sync_endl;
            }

            else if (token == "go")
            {
                if (HybridizerRefrigitz.AllDraw.CalIdle != 1)
                {
                    if (HybridizerRefrigitz.AllDraw.CalIdle == 0)
                    {
                        Console.Write("\ngo 0");

                        HybridizerRefrigitz.AllDraw.CalIdle = 2;
                        Console.Write("\ngo 2");
                        while (HybridizerRefrigitz.AllDraw.CalIdle != 1)
                        {
                        }
                        Console.Write("\ngo 1");
                    }
                } //undeterministic blok line location!
                Console.Write("\ngo go");
                go(ref cmd);

                Console.Write("\ngo play");
                AllDraw.OrderPlateDraw = AllDraw.OrderPlate;
                t.t.Play(-1, -1);
                HybridizerRefrigitzForm.Table = t.t.Draw.CloneATable(AllDraw.TableListAction[AllDraw.TableListAction.Count - 2]);
                Console.Write("\ngo finished.");
                HybridizerRefrigitz.AllDraw.CalIdle = 0;
            }

            else if (token == "position")
            {
                position(ref cmd);
            }

            else if (token == "setoption")
            {

                setoption(ref argv[0]);
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
                posa();
                //sync_cout << pos << sync_endl;
            }
            else if (token == "eval")
            {
                //sync_cout << Eval::trace(pos) << sync_endl;
            }

            else if (token == "perft")
            {
                int depth;
                //stringstream ss;

                 depth=System.Convert.ToInt32(Console.ReadLine());
                AllDraw.MaxAStarGreedy = depth;
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
    static void posa()
    {
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine("\n+---+---+---+---+---+---+---+---+");
            Console.Write("|");

            for (int j = 0; j < 8; j++)
            {
                switch (HybridizerRefrigitzForm.Table[j, i])
                {
                    case -6:
                        Console.Write(" k |");
                        break;
                    case -5:
                        Console.Write(" q |");
                        break;
                    case -4:
                        Console.Write(" r |");
                        break;
                    case -3:
                        Console.Write(" b |");
                        break;
                        case -2:
                        Console.Write(" n |");
                        break;
                    case -1:
                        Console.Write(" p |");
                        break;
                    case 6:
                        Console.Write(" K |");
                        break;
                    case 5:
                        Console.Write(" Q |");
                        break;
                    case 4:
                        Console.Write(" R |");
                        break;
                    case 3:
                        Console.Write(" B |");
                        break;
                    case 2:
                        Console.Write(" N |");
                        break;
                    case 1:
                        Console.Write(" P |");
                        break;
                    case 0:
                        Console.Write("   |");
                        break;

                }
            }
        }
        Console.WriteLine("\n+---+---+---+---+---+---+---+---+");
        Console.WriteLine("\nfen: "+ StartFEN);

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
namespace UCI
{
    

    //C++ TO C# CONVERTER NOTE: C# has no need of forward class declarations:
    //class Option;

    /// Custom comparator because UCI options should be case insensitive
    public class CaseInsensitiveLess
    {
        //C++ TO C# CONVERTER WARNING: 'const' methods are not available in C#:
        //ORIGINAL LINE: bool operator ()(const string&, const string&) const;
        //C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
        //  bool operator ()(string NamelessParameter1, string NamelessParameter2);
    }

    /// Our options container is actually a std::map

    /// Option class implements an option as defined  by UCI protocol
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

} // namespace UCI