using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
namespace HybridizerRefrigitz
{
    [Serializable]
    public class DrawHourse
    {

        
        StringBuilder Space = new StringBuilder("&nbsp;");
//#pragma warning disable CS0414 // The field 'DrawHourse.Spaces' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'DrawHourse.Spaces' is assigned but its value is never used
        int Spaces = 0;
#pragma warning restore CS0414 // The field 'DrawHourse.Spaces' is assigned but its value is never used
//#pragma warning restore CS0414 // The field 'DrawHourse.Spaces' is assigned but its value is never used


        public int WinOcuuredatChiled = 0; public int[] LoseOcuuredatChiled = { 0, 0, 0 };
        
        
        
        //Iniatite Global Variables.
        List<int[]> ValuableSelfSupported = new List<int[]>();

        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfObjectsT = false;
        public bool UsePenaltyRegardMechnisamT = true;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;
        public bool ArrangmentsChanged = true;
        public static long MaxHeuristicxH = -20000000000000000;
        public float Row, Column;
        public Color color;
        public int[,] Table = null;
        public ThinkingHybridizerRefrigitz[] HourseThinking = new ThinkingHybridizerRefrigitz[AllDraw.HourseMovments];
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
        public bool MaxFound(ref bool MaxNotFound)
        {
            
            int a = ReturnHeuristic();
            if (MaxHeuristicxH < a)
            {
                Object O2 = new Object();
                lock (O2)
                {
                    MaxNotFound = false;
                    if (ThinkingHybridizerRefrigitz.MaxHeuristicx < MaxHeuristicxH)
                        ThinkingHybridizerRefrigitz.MaxHeuristicx = a;
                    MaxHeuristicxH = a;
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
            for (var ii = 0; ii < AllDraw.HourseMovments; ii++)

                a += HourseThinking[ii].ReturnHeuristic(-1, -1, Order, false,ref HaveKilled);
            
            return a;
        }
        //Constructor 1.
        
        //Constructpor 2.
        public DrawHourse(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, Color a, int[,] Tab, int Ord, bool TB, int Cur//,ref AllDraw. THIS
            )
        {
            

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
                //Initiate Global Variable By Local Paramenters.
                Table = new int[8, 8];
                for (var ii = 0; ii < 8; ii++)
                    for (var jj = 0; jj < 8; jj++)
                        Table[ii, jj] = Tab[ii, jj];
                for (var ii = 0; ii < AllDraw.HourseMovments; ii++)
                    HourseThinking[ii] = new ThinkingHybridizerRefrigitz(ii,3,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 8, Ord, TB, Cur, 4, 3);

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
        //Cloen a Copy.
        public void Clone(ref DrawHourse AA//, ref AllDraw. THIS
            )
        {
            
            int[,] Tab = new int[8, 8];
            for (var i = 0; i < 8; i++)
                for (var j = 0; j < 8; j++)
                    Tab[i, j] = this.Table[i, j];
            //Create a Construction Ojects and Initiate a Clone Copy.
            AA = new DrawHourse(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, this.Row, this.Column, this.color, this.CloneATable(Table), this.Order, false, this.Current);
            AA.ArrangmentsChanged = ArrangmentsChanged;
            for (var i = 0; i < AllDraw.HourseMovments; i++)
            {

                AA.HourseThinking[i] = new ThinkingHybridizerRefrigitz(i,3,CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)this.Row, (int)this.Column);
                this.HourseThinking[i].Clone(ref AA.HourseThinking[i]);

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
        //Draw a Instatnt Hourse on the Table Method.
        public void DrawHourseOnTable( int CellW, int CellH)
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
                                 //Draw an Instatnt WHITE Hourse on the Table.
                                //g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "HG.png"), new Rectangle((int)(Row * (float)CellW), (int)(Column * (float)CellH), CellW, CellH));
                            }
                        }
                        else
                        {
                            Object O1 = new Object();
                            lock (O1)
                            {    //Draw an Instant from File of WHITE Soldeirs.
                                 //Draw an Instatnt BLACK Hourse on the Table.
                                //g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "HB.png"), new Rectangle((int)(Row * (float)CellW), (int)(Column * (float)CellH), CellW, CellH));
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
