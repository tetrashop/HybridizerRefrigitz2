using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using System.IO;
namespace HybridizerRefrigitz
{
    [Serializable]
    public class DrawKing
    {

        StringBuilder Space = new StringBuilder("&nbsp;");
//// The field 'DrawKing.Spaces' is assigned but its value is never used
// The field 'DrawKing.Spaces' is assigned but its value is never used
        
 // The field 'DrawKing.Spaces' is assigned but its value is never used
// // The field 'DrawKing.Spaces' is assigned but its value is never used


        public static bool KingGrayNotCheckedByQuantumMove = false;
        public static bool KingBrownNotCheckedByQuantumMove = false;

        public int WinOcuuredatChiled = 0; public int[] LoseOcuuredatChiled = { 0, 0, 0 };
        
        
        
        //Initiate Global Variables.
        List<int[]> ValuableSelfSupported = new List<int[]>();

        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfobjectsT = false;
        public bool UsePenaltyRegardMechnisamT = true;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;

        public bool ArrangmentsChanged = true;
        public static long MaxHeuristicxK = -20000000000000000;
        public float Row, Column;
        public ConsoleColor color;
        public int[,] Table = null;
        public ThinkingHybridizerRefrigitz[] KingThinking = new ThinkingHybridizerRefrigitz[AllDraw.KingMovments];
        public int Current = 0;
        public int Order;
        int CurrentAStarGredyMax = -1;

        static void Log(Exception ex)
        {

            try
            {
                object a = new object();
                lock (a)
                {
                    string stackTrace = ex.ToString();
                    //Write to File.
                     File.AppendAllText(AllDraw.Root + "\\ErrorProgramRun.txt",  ": On" + DateTime.Now.ToString());

                }
            }

            catch (Exception t) { /*Log(t);*/ }

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
                object O2 = new object();
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
        public DrawKing(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, ConsoleColor a, int[,] Tab, int Ord, bool TB, int Cur//, ref AllDraw. THIS
            )
        {
            
            object balancelock = new object();
            lock (balancelock)
            {


                CurrentAStarGredyMax = CurrentAStarGredy;
                MovementsAStarGreedyHeuristicFoundT = MovementsAStarGreedyHeuristicTFou;
                IgnoreSelfobjectsT = IgnoreSelfObject;
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
                    KingThinking[ii] = new ThinkingHybridizerRefrigitz(ii, 6, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 8, Ord, TB, Cur, 2, 6);

                Row = i;
                Column = j;
				color= a;
                Order = Ord;
                Current = Cur;
            }
            
        }
        int[,] CloneATable(int[,] Tab)
        {
            
            object O = new object();
            lock (O)
            {
                //Create and new an object.
                int[,] Table = new int[8, 8];
                //Assigne Parameter To New objects.
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        Table[i, j] = Tab[i, j];
                //Return New object.
                
                return Table;
            }

        }
        bool[,] CloneATable(bool[,] Tab)
        {
            
            object O = new object();
            lock (O)
            {
                //Create and new an object.
                bool[,] Table = new bool[8, 8];
                //Assigne Parameter To New objects.
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        Table[i, j] = Tab[i, j];
                //Return New object.
                
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
            //Initiate a Construction object and Clone a Copy.
            AA = new DrawKing(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, this.Row, this.Column, this.color, this.CloneATable(Table), this.Order, false, this.Current);
            AA.ArrangmentsChanged = ArrangmentsChanged;
            for (var i = 0; i < AllDraw.KingMovments; i++)
            {

                AA.KingThinking[i] = new ThinkingHybridizerRefrigitz(i, 6, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)this.Row, (int)this.Column);
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
			AA.color= color;
            
        }
        
    }
}
//End of Documentation.
