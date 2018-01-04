using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CSV_Gen
{
    class Program
    {

        static int exit_status = 0;

        static int Main(string[] args)
        {

            if (args.Length != 2)
            {
                Console.Write("args.Length = {0}\n", args.Length);
                usageError();
                return exit_status;

            }

            string[] lines = System.IO.File.ReadAllLines(@args[0]);
            string outfile = @args[1];



            printHeader(outfile);
            int count = 0;

            foreach (string line in lines)
            {

                appendToFile(outfile, getFirstToken(line.Substring(0, 7)) + ","); //PRODNO
                appendToFile(outfile, getFirstToken(line.Substring(7, 7)) + ","); //MFG_FIRMNO
                appendToFile(outfile, getFirstToken(line.Substring(14, 7)) + ","); //REG_FIRMNO
                appendToFile(outfile, getFirstToken(line.Substring(21, 5)) + ","); //LABEL_SEQ_NO
                appendToFile(outfile, getFirstToken(line.Substring(26, 2)) + ","); //REVISION_NO
                appendToFile(outfile, getFirstToken(line.Substring(28, 7)) + ","); //FUT_FIRMNO
                appendToFile(outfile, getFirstToken(line.Substring(35, 1)) + ","); //PRODSTAT_IND

                appendToFile(outfile, removeEndSpaces(line.Substring(36, 100)) + ","); //PRODUCT_NAME
                //appendToFile(outfile, "\n");
                

                /*
                count++;
                if (getFirstToken(line.Substring(36, 100) + ",") == "")
                {
                    appendToFile(outfile, "EMPTY STRING FOUND" + count.ToString());
                    break;
                }
                */

                appendToFile(outfile, getFirstToken(line.Substring(136, 24)) + ","); //SHOW_REGNO
                appendToFile(outfile, getFirstToken(line.Substring(160, 1)) + ","); //AER_GRND_IND
                appendToFile(outfile, getFirstToken(line.Substring(161, 1)) + ","); //AGRICCOM_SW
                appendToFile(outfile, getFirstToken(line.Substring(162, 1)) + ","); //CONFID_SW
                appendToFile(outfile, getFirstToken(line.Substring(163, 7)) + ","); //DENSITY
                appendToFile(outfile, getFirstToken(line.Substring(170, 2)) + ","); //FORMULA_CD
                appendToFile(outfile, getFirstToken(line.Substring(172, 11)) + ","); //FULL_EXP_DT
                appendToFile(outfile, getFirstToken(line.Substring(183, 11)) + ","); //FULL_ISS_DT
                appendToFile(outfile, getFirstToken(line.Substring(194, 1)) + ","); //FUMIGANT_SW
                appendToFile(outfile, getFirstToken(line.Substring(195, 1)) + ","); //GEN_PEST_IND
                appendToFile(outfile, getFirstToken(line.Substring(196, 11)) + ","); //LASTUP_DT
                appendToFile(outfile, getFirstToken(line.Substring(207, 1)) + ","); //MFG_REF_SW
                appendToFile(outfile, getFirstToken(line.Substring(208, 11)) + ","); //PROD_INAC_DT
                appendToFile(outfile, getFirstToken(line.Substring(219, 11)) + ","); //REG_DT
                appendToFile(outfile, getFirstToken(line.Substring(230, 1)) + ","); //REG_TYPE_IND
                appendToFile(outfile, getFirstToken(line.Substring(231, 1)) + ","); //RODENT_SW
                appendToFile(outfile, getFirstToken(line.Substring(232, 1)) + ","); //SIGNLWRD_IND
                appendToFile(outfile, getFirstToken(line.Substring(233, 1)) + ","); //SOILAPPL_SW
                appendToFile(outfile, getFirstToken(line.Substring(234, 1)) + ","); //SPECGRAV_SW
                appendToFile(outfile, getFirstToken(line.Substring(235, 8)) + ","); //SPEC_GRAVITY
                appendToFile(outfile, getFirstToken(line.Substring(243, 1)) + ","); //CONDREG_SW
                appendToFile(outfile, getFirstToken(line.Substring(244, 1)) + "\n"); //VAR2_SW

            }

            return exit_status;

            /*
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
            */
        }

        public static void usageError()
        {
            Console.Write("Usage: CSV_Gen.exe infile outfile\n");
            exit_status = 1;
        }

        public static void printHeader(string filename)
        {

            string csvHeader = "PRODNO,MFG_FIRMNO,REG_FIRMNO,LABEL_SEQ_NO,REVISION_NO,FUT_FIRMNO,PRODSTAT_IND,PRODUCT_NAME,SHOW_REGNO,AER_GRND_IND,AGRICCOM_SW,CONFID_SW,DENSITY,FORMULA_CD,FULL_EXP_DT,";
            csvHeader += "FULL_ISS_DT, FUMIGANT_SW, GEN_PEST_IND,LASTUP_DT,MFG_REF_SW,PROD_INAC_DT,REG_DT,REG_TYPE_IND,RODENT_SW,SIGNLWRD_IND,SOILAPPL_SW,SPECGRAV_SW,SPEC_GRAVITY,CONDREG_SW,VAR2_SW\n";
            System.IO.File.WriteAllText(filename, csvHeader);
        }

        public static void appendToFile(string filename, string str)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(filename, true))
            {
                file.Write(str);
            }
        }

        public static string getFirstToken(string inputStr)
        {
            string pattern = @"[^\s]+";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(inputStr);
            if (matches.Count > 0)
            {
                //Console.WriteLine("{0} ({1} matches):", inputStr, matches.Count);
                foreach (Match match in matches)
                    //Console.WriteLine("-->" + match.Value);
                    return match.Value;
            }
            return "";
        }

        public static string removeEndSpaces(string inputStr)
        {
            if (inputStr.Length == 0)
            {
                return "";
            }

            int index = inputStr.Length;
            index--;
            while (inputStr[index] == ' ' && index >= 0)
            {
                index--;
            }

            if (index < 0) return "";
            //StringBuilder sb = new StringBuilder(inputStr);
            return inputStr.Substring(0, index+1);
        }

        public static string removeFrontSpaces(string inputStr)
        {
            if (inputStr.Length == 0)
            {
                return "";
            }

            int index = 0;

            while (inputStr[index] == ' ' && index <= (inputStr.Length-1))
            {
                index++;
            }

            if (index > (inputStr.Length - 1)) return "";

            return inputStr.Substring(index, inputStr.Length - index);
        }

    }
}
