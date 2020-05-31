using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using System.IO;

namespace HybridizerRefrigitz
{
    [Serializable]
    public class DrawSoldier : ThingsConverter
    {
        
        StringBuilder Space = new StringBuilder("&nbsp;");
//// The field 'DrawSoldier.Spaces' is assigned but its value is never used
// The field 'DrawSoldier.Spaces' is assigned but its value is never used
        
 // The field 'DrawSoldier.Spaces' is assigned but its value is never used
// // The field 'DrawSoldier.Spaces' is assigned but its value is never used


        public int WinOcuuredatChiled = 0; public int[] LoseOcuuredatChiled = { 0, 0, 0 };
        //Iniatate Global Variables.
        
        
        List<int[]> ValuableSelfSupported = new List<int[]>();

        
        
        
        
        
        
        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfobjectsT = false;
        public bool UsePenaltyRegardMechnisamT = true;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;
        public bool ArrangmentsChanged = true;
        public static int MaxHeuristicxS = int.MinValue;
        public float Row, Column;
        public ConsoleColor color;
        public ThinkingHybridizerRefrigitz[] SoldierThinking = new ThinkingHybridizerRefrigitz[AllDraw.SodierMovments];
        public int[,] Table = null;
        public int Order = 0;
        public int Current = 0;
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
        public bool MaxFound(ref bool MaxNotFound)
        {
            
            int a = ReturnHeuristic();
            if (MaxHeuristicxS < a)
            {
                object O2 = new object();
                lock (O2)
                {
                    MaxNotFound = false;
                    if (ThinkingHybridizerRefrigitz.MaxHeuristicx < MaxHeuristicxS)
                        ThinkingHybridizerRefrigitz.MaxHeuristicx = a;
                    MaxHeuristicxS = a;
                }
                
                return true;
            }

            MaxNotFound = true;
            
            return false;
        }
        public int ReturnHeuristic()
        {
            int HaveKilled = 0;
            
            int a = 0;
            for (var ii = 0; ii < AllDraw.SodierMovments; ii++)

                a += SoldierThinking[ii].ReturnHeuristic(-1, -1, Order, false,ref HaveKilled);

            
            return a;
        }
        //clone a table
        int[,] CloneATable(int[,] Tab)
        {
            int[,] Tabl = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    Tabl[i, j] = Tab[i, j];
            return Tabl;
        }
        
        //Constructor 1.

        //Constructor 2.
        public DrawSoldier(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, ConsoleColor a, int[,] Tab, int Ord, bool TB, int Cur//, ref AllDraw. THIS
            ) :
            base(Arrangments, (int)i, (int)j, a, Tab, Ord, TB, Cur)
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
                //Initiate Global Variables.  
                Table = new int[8, 8];
                for (var ii = 0; ii < 8; ii++)
                    for (var jj = 0; jj < 8; jj++)
                        Table[ii, jj] = Tab[ii, jj];
                for (var ii = 0; ii < AllDraw.SodierMovments; ii++)

                    SoldierThinking[ii] = new ThinkingHybridizerRefrigitz(ii,1,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 4, Ord, TB, Cur, 16, 1);
                Row = i;
                Column = j;
                color =a;
                Order = Ord;
                Current = Cur;
            }
            
        }
        
        //Clone a Copy Method.
        public void Clone(ref DrawSoldier AA//, ref AllDraw. THIS
            )
        {
            
            int[,] Tab = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    Tab[i, j] = this.Table[i, j];
            //Initiate a object and Assignemt of a Clone to Construction of a Copy.

            AA = new DrawSoldier(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, this.Row, this.Column, this.color, CloneATable(Tab), this.Order, false, this.Current
                );
            AA.ArrangmentsChanged = ArrangmentsChanged;
            for (var i = 0; i < AllDraw.SodierMovments; i++)
            {

                AA.SoldierThinking[i] = new ThinkingHybridizerRefrigitz(i,1,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)this.Row, (int)this.Column);
                this.SoldierThinking[i].Clone(ref AA.SoldierThinking[i]);

            }
            AA.Table = new int[8, 8];
            for (var ii = 0; ii < 8; ii++)
                for (var jj = 0; jj < 8; jj++)
                    AA.Table[ii, jj] = Tab[ii, jj];
            AA.Row = Row;
            AA.Column = Column;
            AA.Order = Order;
            AA.Current = Current;
            AA.color=color;
            
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
        
    }
}
//End of Documentation.
