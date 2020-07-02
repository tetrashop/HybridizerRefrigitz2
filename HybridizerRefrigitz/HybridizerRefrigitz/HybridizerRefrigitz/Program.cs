using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Hybridizer.Runtime.CUDAImports;
using static System.Net.Mime.MediaTypeNames;

namespace HybridizerRefrigitz
{
    
    static class Program
    {

        [Kernel]
        //Main Programm.
        //[STAThread]
        static void Main(string[] args)
        {
            /* cuda.DeviceSynchronize();
             HybRunner runner = HybRunner.Cuda("Hybridizer.Runtime.CUDAImports.dll").SetDistrib(1, 2);
             GlobalMembersUci.t = new ArtificialInteligenceMove(new HybridizerRefrigitzForm());
             runner.Wrap(GlobalMembersUci.t);
             */
            if (GlobalMembersUci.t == null)
            {
                GlobalMembersUci.t = new ArtificialInteligenceMove(new HybridizerRefrigitzForm());
                if (GlobalMembersUci.t.t == null)
                {
                    if (!GlobalMembersUci.t.t.LoadP)
                        GlobalMembersUci.t.t.Form1_Load();
                }
                else
                {
                    if (!GlobalMembersUci.t.t.LoadP)
                        GlobalMembersUci.t.t.Form1_Load();
                }
            }
            GlobalMembersUci.loop(args);
        }
    }
}
//End of Documents.