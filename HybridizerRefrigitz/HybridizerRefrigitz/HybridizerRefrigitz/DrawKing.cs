using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
namespace HybridizerRefrigitz
{
    [Serializable]
    public class DrawKing
    {

        StringBuilder Space = new StringBuilder("&nbsp;");
//#pragma warning disable CS0414 // The field 'DrawKing.Spaces' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'DrawKing.Spaces' is assigned but its value is never used
        int Spaces = 0;
#pragma warning restore CS0414 // The field 'DrawKing.Spaces' is assigned but its value is never used
//#pragma warning restore CS0414 // The field 'DrawKing.Spaces' is assigned but its value is never used


        public static bool KingWHITENotCheckedByQuantumMove = false;
        public static bool KingBLACKNotCheckedByQuantumMove = false;

        public int WinOcuuredatChiled = 0; public int[] LoseOcuuredatChiled = { 0, 0, 0 };
        
        
        
        //Initiate Global Variables.
        List<int[]> ValuableSelfSupported = new List<int[]>();

        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfObjectsT = false;
        public bool UsePenaltyRegardMechnisamT = true;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;

        public bool ArrangmentsChanged = true;
        public static long MaxHeuristicxK = -20000000000000000;
        public float Row, Column;
        public Color color;
        public int[,] Table = null;
        public ThinkingHybridizerRefrigitz[] KingThinking = new ThinkingHybridizerRefrigitz[AllDraw.KingMovments];
        public int Current = 0;
        public int Order;
        int CurrentAStarGredyMax = -1;

        static void Log(Exception ex)
        {

            try
            {
                Object a = new Object();
                lock (a)
                {
                    string stackTrace = ex.ToString();
                    //Write to File.
                    Helper.WaitOnUsed(AllDraw.Root + "\\ErrorProgramRun.txt"); File.AppendAllText(AllDraw.Root + "\\ErrorProgramRun.txt", stackTrace + ": On" + DateTime.Now.ToString());

                }
            }
#pragma warning disable CS0168 // The variable 't' is declared but never used
            catch (Exception t) { }
#pragma warning restore CS0168 // The variable 't' is declared but never used
        }
        public void Dispose()
        {
            
            ValuableSelfSupported = null;
             
        }

        public int ReturnHeuristic()
        {
            int HaveKilled = 0;
            
            int a = 0;
            for (var ii = 0; ii < AllDraw.KingMovments; ii++)

                a += KingThinking[ii].ReturnHeuristic(-1, -1, Order, false, ref HaveKilled);

            
            return a;
        }
        public bool MaxFound(ref bool MaxNotFound)
        {
            

            int a = ReturnHeuristic();
            if (MaxHeuristicxK < a)
            {
                Object O2 = new Object();
                lock (O2)
                {
                    MaxNotFound = false;
                    if (ThinkingHybridizerRefrigitz.MaxHeuristicx < MaxHeuristicxK)
                        ThinkingHybridizerRefrigitz.MaxHeuristicx = a;
                    MaxHeuristicxK = a;
                }
                
                return true;
            }

            MaxNotFound = true;
            
            return false;
        }
        //Constructor 1.
        
        //Constructor 2.
        public DrawKing(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, Color a, int[,] Tab, int Ord, bool TB, int Cur//, ref AllDraw. THIS
            )
        {
            
            object balancelock = new object();
            lock (balancelock)
            {


                CurrentAStarGredyMax = CurrentAStarGredy;
                MovementsAStarGreedyHeuristicFoundT = MovementsAStarGreedyHeuristicTFou;
                IgnoreSelfObjectsT = IgnoreSelfObject;
                UsePenaltyRegardMechnisamT = UsePenaltyRegardMechnisa;
                BestMovmentsT = BestMovment;
                PredictHeuristicT = PredictHurist;
                OnlySelfT = OnlySel;
                AStarGreedyHeuristicT = AStarGreedyHuris;
                ArrangmentsChanged = Arrangments;
                //Iniatite Global Variables.
                Table = new int[8, 8];
                for (var ii = 0; ii < 8; ii++)
                    for (var jj = 0; jj < 8; jj++)
                        Table[ii, jj] = Tab[ii, jj];
                for (var ii = 0; ii < AllDraw.KingMovments; ii++)
                    KingThinking[ii] = new ThinkingHybridizerRefrigitz(ii, 6, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 8, Ord, TB, Cur, 2, 6);

                Row = i;
                Column = j;
                color = a;
                Order = Ord;
                Current = Cur;
            }
            
        }
        int[,] CloneATable(int[,] Tab)
        {
            
            Object O = new Object();
            lock (O)
            {
                //Create and new an Object.
                int[,] Table = new int[8, 8];
                //Assigne Parameter To New Objects.
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        Table[i, j] = Tab[i, j];
                //Return New Object.
                
                return Table;
            }

        }
        bool[,] CloneATable(bool[,] Tab)
        {
            
            Object O = new Object();
            lock (O)
            {
                //Create and new an Object.
                bool[,] Table = new bool[8, 8];
                //Assigne Parameter To New Objects.
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        Table[i, j] = Tab[i, j];
                //Return New Object.
                
                return Table;
            }

        }

        //Clone a Copy.
        public void Clone(ref DrawKing AA//, ref AllDraw. THIS
            )
        {
            
            int[,] Tab = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    Tab[i, j] = this.Table[i, j];
            //Initiate a Construction Object and Clone a Copy.
            AA = new DrawKing(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, this.Row, this.Column, this.color, this.CloneATable(Table), this.Order, false, this.Current);
            AA.ArrangmentsChanged = ArrangmentsChanged;
            for (var i = 0; i < AllDraw.KingMovments; i++)
            {

                AA.KingThinking[i] = new ThinkingHybridizerRefrigitz(i, 6, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)this.Row, (int)this.Column);
                this.KingThinking[i].Clone(ref AA.KingThinking[i]);

            }
            AA.Table = new int[8, 8];
            for (var ii = 0; ii < 8; ii++)
                for (var jj = 0; jj < 8; jj++)
                    AA.Table[ii, jj] = Tab[ii, jj];
            AA.Row = Row;
            AA.Column = Column;
            AA.Order = Order;
            AA.Current = Current;
            AA.color = color;
            
        }
        //Draw an Instatnt King on the Table Method.
        public void DrawKingOnTable( int CellW, int CellH)
        {
            object balancelockS = new object();

            lock (balancelockS)
            {
                

                try
                {

                    
                    if (((int)Row >= 0) && ((int)Row < 8) && ((int)Column >= 0) && ((int)Column < 8))
                    { //WHITE Order.
                        if (Order == 1)
                        {
                            Object O1 = new Object();
                            lock (O1)
                            {    //Draw an Instant from File of WHITE Soldeirs.
                                 //Draw an Instatnt WHITE King Image On the Table.
                                //g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "KG.png"), new Rectangle((int)(Row * (float)CellW), (int)(Column * (float)CellH), CellW, CellH));

                            }

                        }
                        else
                        {
                            Object O1 = new Object();
                            lock (O1)
                            {    //Draw an Instant from File of WHITE Soldeirs.
                                 //Draw an Instatnt BLACK King Image On the Table.
                                //g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "KB.png"), new Rectangle((int)(Row * (float)CellW), (int)(Column * (float)CellH), CellW, CellH));

                            }
                        }
                    }


                }
                catch (Exception t)
                {
                    Log(t);
                }
                
            }
        }
    }
}
//End of Documentation.
