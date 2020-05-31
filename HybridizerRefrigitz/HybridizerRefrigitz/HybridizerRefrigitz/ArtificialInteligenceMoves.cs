﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;




public class ArtificialInteligenceMove
{	public static bool UpdateIsRunning=false; 
	public static ArtificialInteligenceMove tta;
	int LevelMul=1;
	int Order=1;
	public int x,y,x1,y1;

    public HybridizerRefrigitz.HybridizerRefrigitzForm t = null;

    bool Idle = false;
	public static bool IdleProgress=true;
	public  ArtificialInteligenceMove(HybridizerRefrigitz.HybridizerRefrigitzForm tt)
    {
        //Awake ();
        t = tt;
		var ttt = new Thread (new ThreadStart (ThinkingIdle));
		ttt.Start ();
		
			//ttt.Join ();
			
	}


    ConsoleColor OrderConsoleColor(int Ord)
    {
        Object O = new Object();
        lock (O)
        {
            ConsoleColor a = ConsoleColor.Gray;
            if (Ord == -1)
                a = ConsoleColor.Black;
            return a;
        }
    }
    public void ThinkingIdle()
	{
		object O=new object();
		lock(O){
			bool ReadyZero = true;
			do {
				if(t!=null)
				{
					if(t.LoadP||Idle){
						if(HybridizerRefrigitz.AllDraw.CalIdle==0&&ReadyZero)
						{
							ReadyZero=false;

						}
						if(HybridizerRefrigitz.AllDraw.CalIdle==0&&(!ArtificialInteligenceMove.UpdateIsRunning)
						)
										{

								bool Blit=HybridizerRefrigitz.AllDraw.Blitz;
							HybridizerRefrigitz.AllDraw.Blitz=false;
															Idle=true;
                            HybridizerRefrigitz.AllDraw.TimeInitiation = (DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000);
                            HybridizerRefrigitz.AllDraw.MaxAStarGreedy = HybridizerRefrigitz.AllDraw.PlatformHelperProcessorCount * LevelMul;
                            var arrayA =Task.Factory.StartNew(() =>	t.Draw.InitiateAStarGreedyt(HybridizerRefrigitz.AllDraw.MaxAStarGreedy,1, 4,OrderConsoleColor(t.Draw.OrderP), CloneATable(t.brd.GetTable()), t.Draw.OrderP, false, false, 0));
							//var arrayA =Task.Factory.StartNew(() =>	t.Play(-1,-1));
                            arrayA.Wait();
							object i=new object();

							lock(i)
							{
								bool LoadTree=false;
								(new HybridizerRefrigitz.TakeRoot()).Save(false, false, t, ref LoadTree, false, false, false, false, false, false, false, true);
							}
							HybridizerRefrigitz.AllDraw.Blitz=Blit;
//							Thread.Sleep(50);
							//LevelMul++;
							IdleProgress=false;
							ArtificialInteligenceMove.UpdateIsRunning=true;

							HybridizerRefrigitz.AllDraw.CalIdle=1;
						}
						if(HybridizerRefrigitz.AllDraw.CalIdle==2)
						{
					
							HybridizerRefrigitz.AllDraw.CalIdle=5;
						}
//						if(HybridizerRefrigitz.AllDraw.CalIdle==2)
//						{
//							Debug.Log("Ready to 5 base");
//
//							HybridizerRefrigitz.AllDraw.CalIdle=5;
//						}
//						Debug.Log("Ready to 0 base");

						if(HybridizerRefrigitz.AllDraw.CalIdle==5)
						{		HybridizerRefrigitz.AllDraw.CalIdle=1;
//						        HybridizerRefrigitz.AllDraw.IdleInWork=false;

							//Debug.Log("Ready to 1 base");
							ReadyZero=true;
						}
						while(HybridizerRefrigitz.AllDraw.CalIdle==1)
						{	

							//Thread.Sleep(1);
						}
						while(ArtificialInteligenceMove.UpdateIsRunning)
						{	
							//Thread.Sleep(1);
						}

						HybridizerRefrigitz.AllDraw.IdleInWork=true;
						HybridizerRefrigitz.AllDraw.CalIdle=0;
						IdleProgress=true;
//				
					}
				}
				} while(HybridizerRefrigitz.AllDraw.CalIdle!=3);
		
		}
	}
	int[,] CloneATable(int[,] Tab)
	{
		object O = new object();
		lock (O)
		{          
			int[,] Tabl = new int[8, 8];
			for (var i = 0; i < 8; i++)
				for (var j = 0; j < 8; j++)
					Tabl[i, j] = Tab[i, j];

			return Tabl;
		}
	}
	
}

