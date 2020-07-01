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
        static void Main()
        {
            /* cuda.DeviceSynchronize();
             HybRunner runner = HybRunner.Cuda("Hybridizer.Runtime.CUDAImports.dll").SetDistrib(1, 2);
             GlobalMembersUci.t = new ArtificialInteligenceMove(new HybridizerRefrigitzForm());
             runner.Wrap(GlobalMembersUci.t);
             */
            GlobalMembersUci.t = new ArtificialInteligenceMove(new HybridizerRefrigitzForm());
            GlobalMembersUci.t.t.Form1_Load();
            Console.ReadLine();
        }
    }
}
//End of Documents.