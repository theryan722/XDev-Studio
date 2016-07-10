using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

//TODO:Cleanup Code, properly format/tab lines
namespace XDev.CompilerHelper
{
    
   public class Launch
    {

       /// <summary>
       /// Launches a process and gets the output
       /// </summary>
       /// <param name="fileloc"></param>
       /// <returns>Array of string with output and errors</returns>
        public static String[] LaunchAndGetOutputErrors(String fileloc){
            int timeout = 15000;
            String[] toret = new String[2];
            using (Process process = new Process()){
                process.StartInfo.FileName = fileloc;
                process.StartInfo.Arguments = "";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                StringBuilder output = new StringBuilder();
                StringBuilder error = new StringBuilder();

                using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false)){
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            output.AppendLine(e.Data);
                        }
                    };
        process.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data == null)
            {
                errorWaitHandle.Set();
            }
            else
            {
                error.AppendLine(e.Data);
            }
        };

        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        if (process.WaitForExit(timeout) &&
            outputWaitHandle.WaitOne(timeout) &&
            errorWaitHandle.WaitOne(timeout))
        {
            toret[0] = output.ToString();
            toret[1] = error.ToString();
            return toret;
            // Process completed. Check process.ExitCode here.
        }
        else
        {
            return null;
            // Timed out.
        }
    }
}
        }

   }
}
