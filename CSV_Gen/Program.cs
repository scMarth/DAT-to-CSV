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

            /*
            //////////////////////////////////////////////////////////
            String test = "   Hello, World!!!   ";
            Console.Write(test); Console.WriteLine(test);
            Console.WriteLine(removeEndSpaces(removeFrontSpaces(test)) + "ZED");
            //////////////////////////////////////////////////////////
            */

            printHeader(outfile);
            int count = 0;

            
            foreach (string line in lines)
            {
                
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(0, 7))) + ","); //PRODNO
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(7, 7))) + ","); //MFG_FIRMNO
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(14, 7))) + ","); //REG_FIRMNO
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(21, 5))) + ","); //LABEL_SEQ_NO
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(26, 2))) + ","); //REVISION_NO
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(28, 7))) + ","); //FUT_FIRMNO
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(35, 1))) + ","); //PRODSTAT_IND

                appendToFile(outfile, removeEndSpaces(line.Substring(36, 100)) + ","); //PRODUCT_NAME

                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(136, 24))) + ","); //SHOW_REGNO
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(160, 1))) + ","); //AER_GRND_IND
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(161, 1))) + ","); //AGRICCOM_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(162, 1))) + ","); //CONFID_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(163, 7))) + ","); //DENSITY
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(170, 2))) + ","); //FORMULA_CD
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(172, 11))) + ","); //FULL_EXP_DT
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(183, 11))) + ","); //FULL_ISS_DT
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(194, 1))) + ","); //FUMIGANT_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(195, 1))) + ","); //GEN_PEST_IND
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(196, 11))) + ","); //LASTUP_DT
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(207, 1))) + ","); //MFG_REF_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(208, 11))) + ","); //PROD_INAC_DT
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(219, 11))) + ","); //REG_DT
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(230, 1))) + ","); //REG_TYPE_IND
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(231, 1))) + ","); //RODENT_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(232, 1))) + ","); //SIGNLWRD_IND
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(233, 1))) + ","); //SOILAPPL_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(234, 1))) + ","); //SPECGRAV_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(235, 8))) + ","); //SPEC_GRAVITY
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(243, 1))) + ","); //CONDREG_SW
                appendToFile(outfile, removeEndSpaces(removeFrontSpaces(line.Substring(244, 1))) + "\n"); //VAR2_SW
                

                /*
                appendToFile(outfile, "\n" + (line.Substring(0, 7))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(0, 7))) + ","); appendToFile(outfile, "\nexecuted PRODNO"); //PRODNO
                appendToFile(outfile, "\n" + (line.Substring(7, 7))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(7, 7))) + ","); appendToFile(outfile, "\nexecuted MFG_FIRMNO"); //MFG_FIRMNO
                appendToFile(outfile, "\n" + (line.Substring(14, 7))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(14, 7))) + ","); appendToFile(outfile, "\nexecuted REG_FIRMNO"); //REG_FIRMNO
                appendToFile(outfile, "\n" + (line.Substring(21, 5))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(21, 5))) + ","); appendToFile(outfile, "\nexecuted LABEL_SEQ_NO"); //LABEL_SEQ_NO
                appendToFile(outfile, "\n" + (line.Substring(26, 2))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(26, 2))) + ","); appendToFile(outfile, "\nexecuted REVISION_NO"); //REVISION_NO
                appendToFile(outfile, "\n" + (line.Substring(28, 7))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(28, 7))) + ","); appendToFile(outfile, "\nexecuted FUT_FIRMNO"); //FUT_FIRMNO
                appendToFile(outfile, "\n" + (line.Substring(35, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(35, 1))) + ","); appendToFile(outfile, "\nexecuted PRODSTAT_IND"); //PRODSTAT_IND

                appendToFile(outfile, "\n" + (line.Substring(36, 100))); appendToFile(outfile, "\n" + removeEndSpaces(line.Substring(36, 100)) + ","); appendToFile(outfile, "\nexecuted PRODUCT_NAME"); //PRODUCT_NAME

                appendToFile(outfile, "\n" + (line.Substring(136, 24))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(136, 24))) + ","); appendToFile(outfile, "\nexecuted SHOW_REGNO"); //SHOW_REGNO
                appendToFile(outfile, "\n" + (line.Substring(160, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(160, 1))) + ","); appendToFile(outfile, "\nexecuted AER_GRND_IND"); //AER_GRND_IND
                appendToFile(outfile, "\n" + (line.Substring(161, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(161, 1))) + ","); appendToFile(outfile, "\nexecuted AGRICCOM_SW"); //AGRICCOM_SW
                appendToFile(outfile, "\n" + (line.Substring(162, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(162, 1))) + ","); appendToFile(outfile, "\nexecuted CONFID_SW"); //CONFID_SW
                appendToFile(outfile, "\n" + (line.Substring(163, 7))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(163, 7))) + ","); appendToFile(outfile, "\nexecuted DENSITY"); //DENSITY
                appendToFile(outfile, "\n" + (line.Substring(170, 2))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(170, 2))) + ","); appendToFile(outfile, "\nexecuted FORMULA_CD"); //FORMULA_CD
                appendToFile(outfile, "\n" + (line.Substring(172, 11))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(172, 11))) + ","); appendToFile(outfile, "\nexecuted FULL_EXP_DT"); //FULL_EXP_DT
                appendToFile(outfile, "\n" + (line.Substring(183, 11))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(183, 11))) + ","); appendToFile(outfile, "\nexecuted FULL_ISS_DT"); //FULL_ISS_DT
                appendToFile(outfile, "\n" + (line.Substring(194, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(194, 1))) + ","); appendToFile(outfile, "\nexecuted FUMIGANT_SW"); //FUMIGANT_SW
                appendToFile(outfile, "\n" + (line.Substring(195, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(195, 1))) + ","); appendToFile(outfile, "\nexecuted GEN_PEST_IND"); //GEN_PEST_IND
                appendToFile(outfile, "\n" + (line.Substring(196, 11))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(196, 11))) + ","); appendToFile(outfile, "\nexecuted LASTUP_DT"); //LASTUP_DT
                appendToFile(outfile, "\n" + (line.Substring(207, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(207, 1))) + ","); appendToFile(outfile, "\nexecuted MFG_REF_SW"); //MFG_REF_SW
                appendToFile(outfile, "\n" + (line.Substring(208, 11))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(208, 11))) + ","); appendToFile(outfile, "\nexecuted PROD_INAC_DT"); //PROD_INAC_DT
                appendToFile(outfile, "\n" + (line.Substring(219, 11))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(219, 11))) + ","); appendToFile(outfile, "\nexecuted REG_DT"); //REG_DT
                appendToFile(outfile, "\n" + (line.Substring(230, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(230, 1))) + ","); appendToFile(outfile, "\nexecuted REG_TYPE_IND"); //REG_TYPE_IND
                appendToFile(outfile, "\n" + (line.Substring(231, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(231, 1))) + ","); appendToFile(outfile, "\nexecuted RODENT_SW"); //RODENT_SW
                appendToFile(outfile, "\n" + (line.Substring(232, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(232, 1))) + ","); appendToFile(outfile, "\nexecuted SIGNLWRD_IND"); //SIGNLWRD_IND
                appendToFile(outfile, "\n" + (line.Substring(233, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(233, 1))) + ","); appendToFile(outfile, "\nexecuted SOILAPPL_SW"); //SOILAPPL_SW
                appendToFile(outfile, "\n" + (line.Substring(234, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(234, 1))) + ","); appendToFile(outfile, "\nexecuted SPECGRAV_SW"); //SPECGRAV_SW
                appendToFile(outfile, "\n" + (line.Substring(235, 8))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(235, 8))) + ","); appendToFile(outfile, "\nexecuted SPEC_GRAVITY"); //SPEC_GRAVITY
                appendToFile(outfile, "\n" + (line.Substring(243, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(243, 1))) + ","); appendToFile(outfile, "\nexecuted CONDREG_SW"); //CONDREG_SW
                appendToFile(outfile, "\n" + (line.Substring(244, 1))); appendToFile(outfile, "\n" + removeEndSpaces(removeFrontSpaces(line.Substring(244, 1))) + "\n"); appendToFile(outfile, "\nexecuted VAR2_SW"); //VAR2_SW
                */

            }
            
            return exit_status;

            //Console.ReadKey();
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
                foreach (Match match in matches)
                    return match.Value;
            }
            return "";
        }

        public static string removeEndSpaces(string inputStr)
        {
            /*
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"I:\GIS\vincentl\Desktop\CSV_Gen Testing\output.csv", true))
            {
                file.Write("\ncalling removeEndSpaces on:{0}\n", inputStr);
            }
            */

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
            return inputStr.Substring(0, index+1);
        }

        public static string removeFrontSpaces(string inputStr)
        {
            /*
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"I:\GIS\vincentl\Desktop\CSV_Gen Testing\output.csv", true))
            {
                file.Write("\ncalling removeFrontSpaces on:{0}\n",inputStr);
            }
            */

            if (inputStr.Length == 0)
            {
                return "";
            }

            int index = 0;

            while (index <= (inputStr.Length - 1) && inputStr[index] == ' ')
            {
                index++;
            }

            if (index > (inputStr.Length - 1)) return "";

            return inputStr.Substring(index, inputStr.Length - index);
        }

    }
}
