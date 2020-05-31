using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Hybridizer.Runtime.CUDAImports;

namespace HybridizerRefrigitz
{
    
    static class Program
    {


        //Main Programm.
        //[STAThread]
        static void Main()
        {
            cuda.DeviceSynchronize();
            HybRunner runner = HybRunner.Cuda("HybridizerRefrigitz_CUDA.vs2015.dll").SetDistrib(1, 2);
            GlobalMembersUci.t = new ArtificialInteligenceMove(new HybridizerRefrigitzForm());
            runner.Wrap(GlobalMembersUci.t);

            //Application.Run(new HybridizerRefrigitzForm());
        }
    }
}
//End of Documents.