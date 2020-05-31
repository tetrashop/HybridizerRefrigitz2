using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Drawing;
using System.IO;
namespace HybridizerRefrigitz
{
    [Serializable]
    public class DrawElefant

    {
        

        StringBuilder Space = new StringBuilder("&nbsp;");
//// The field 'DrawElefant.Spaces' is assigned but its value is never used
// The field 'DrawElefant.Spaces' is assigned but its value is never used
        
 // The field 'DrawElefant.Spaces' is assigned but its value is never used
// // The field 'DrawElefant.Spaces' is assigned but its value is never used



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
        public static long MaxHeuristicxE = -20000000000000000;
        public float Row, Column;
        public ThinkingHybridizerRefrigitz[] ElefantThinking = new ThinkingHybridizerRefrigitz[AllDraw.ElefantMovments];
        public int[,] Table = null;
        public ConsoleColor color;
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
        public bool MaxFound(ref bool MaxNotFound)
        {
            
            int a = ReturnHeuristic();
            if (MaxHeuristicxE < a)
            {
                object O2 = new object();
                lock (O2)
                {
                    MaxNotFound = false;
                    if (ThinkingHybridizerRefrigitz.MaxHeuristicx < MaxHeuristicxE)
                        ThinkingHybridizerRefrigitz.MaxHeuristicx = a;
                    MaxHeuristicxE = a;
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
            for (var ii = 0; ii < AllDraw.ElefantMovments; ii++)

                a += ElefantThinking[ii].ReturnHeuristic(-1, -1, Order, false,ref HaveKilled);

            
            return a;
        }

        //Constructor 1.
        
        //Constructor 2.
        public DrawElefant(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, ConsoleColor a, int[,] Tab, int Ord, bool TB, int Cur//,ref AllDraw. THIS
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
                //Initiate Global Variables By Local Parameters.
                Table = new int[8, 8];
                for (var ii = 0; ii < 8; ii++)
                    for (var jj = 0; jj < 8; jj++)
                        Table[ii, jj] = Tab[ii, jj];
                for (var ii = 0; ii < AllDraw.ElefantMovments; ii++)
                    ElefantThinking[ii] = new ThinkingHybridizerRefrigitz(ii,2,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 16, Ord, TB, Cur, 4, 2);

                Row = i;
                Column = j;
                color =a;
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
        public void Clone(ref DrawElefant AA//, ref AllDraw. THIS
            )
        {
            
            int[,] Tab = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    Tab[i, j] = this.Table[i, j];
            //Initiate a Constructed object an Clone a Copy.
            AA = new DrawElefant(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, this.Row, this.Column, this.color, this.CloneATable(Table), this.Order, false, this.Current);
            AA.ArrangmentsChanged = ArrangmentsChanged;
            for (var i = 0; i < AllDraw.ElefantMovments; i++)
            {

                AA.ElefantThinking[i] = new ThinkingHybridizerRefrigitz(i,2,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfobjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)this.Row, (int)this.Column);
                this.ElefantThinking[i].Clone(ref AA.ElefantThinking[i]);

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
