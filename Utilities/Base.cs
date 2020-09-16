using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel.Application;
//using Microsoft.Office.Interop.Excel._Workbook;
//using Microsoft.Office.Interop.Excel._Worksheet;
//using Microsoft.Office.Interop.Excel.Range;
using ExcelDna.Integration;
using ExcelDna.Utilities;

namespace Utilities
{
    public class Utl
    {
        static string sAllCharacter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string sAllInteger = "0123456789";

        /// <summary>
        /// Check if the supplied symbol is valid
        /// Checks: Empty 
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public static bool Empty(string symbol)
        {
            bool g2g = false;
            string sym = symbol.Trim();

            g2g = string.IsNullOrWhiteSpace(sym);
            return g2g;
        }

        /*
         * This function can and wiil be called from within the 'isOption' function to determine if a provided ticker is a FOP
         */
        public static bool firstCharIs(string str, char exp)
        {
            // First, do length check 
            return (str.Trim().Length > 0 && str.Trim()[0] == exp);
        }

        public static bool startsWith(string str, string pfx)
        {
            return str.StartsWith(pfx);
        }


        public static int pos_first_alpha(string sym)
        {
            int idx = -1;
            char ch;
            for(int i = 0; i < sym.Length; i++)
            {
                ch = sym[i];                 
                if((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')) { 
                    idx = i;
                    break;
                }
            }
            return idx;
        }


        public static int pos_last_alpha(string sym)
        {
            int idx = -1;
            char ch;
            for (int i = sym.Length - 1; i >= 0; i--)
            {
                ch = sym[i];
                if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        public static int pos_first_num(string sym)
        {
            int idx = -1;
            char ch;
            for (int i = 0; i < sym.Length; i++)
            {
                ch = sym[i];
                if (Char.IsDigit(ch)) 
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }


        public static int pos_last_num(string sym)
        {
            int idx = -1;
            char ch;
            for (int i = sym.Length - 1; i >= 0; i--)
            {
                ch = sym[i];
                if (Char.IsDigit(ch))
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        /// <summary>
        /// 
        /// TODO: handle FOPs 
        /// </summary>
        /// <param name="sym"></param>
        /// <returns></returns>
        public static string symbol(string sym)
        {
            string str = "";
            int idx1 = Utl.pos_first_alpha(sym);
            int idx2 = Utl.pos_first_num(sym);

            if(idx2 == -1 && sym.Length < 6)
            {
                idx2 = Utl.pos_last_alpha(sym) + 1;
            }

            if (sym.Length > 0 && idx1 != -1 && idx1 != -1)
            {
                str = sym.Substring(idx1, idx2 - idx1);
            }
            return str;
        }


    } // End class Utl 


    public class TOS
    {

    } // end class TOS 
    public class opt
    {
        /*
        Futures
        Delivery month  Letter
        January         F
        February        G
        March           H
        April           J
        May             K
        June            M
        July            N
        August          Q
        September       U
        October         V
        November        X
        December        Z
        */ 


        /*
        Options
        Delivery month
                    Call Put 
        January	    A	M
        February	B	N
        March	    C	O
        April	    D	P
        May	        E	Q
        June	    F	R
        July	    G	S
        August	    H	T
        September	I	U
        October	    J	V
        November	K	W
        December	L	X
        */

        public static char futureCode(string sym)
        {
            return '-';
        }
        public static char optionCode(string sym)
        {
            return '-';
        }

        /// <summary>
        /// borked 
        /// </summary>
        /// <param name="sym"></param>
        /// <returns></returns>
        public static DateTime getDate(string sym)
        {
            /*
            Dim first_num, last_alpha As Integer
            Dim dateStr As String

            first_num = pos_first_num(sym)
            last_alpha = pos_last_alpha(sym)
            dateStr = Mid(sym, first_num, last_alpha - first_num)

            Dim year, mo, day As String

            year = "20" & Mid(dateStr, 1, 2)
            mo = Mid(dateStr, 3, 2)
            day = Mid(dateStr, 5, 2)

            getDate = year & "/" & mo & "/" & day 
             */
            string dateStr = opt.exDateStr(sym);
            int yr = Int32.Parse(dateStr.Substring(0, 2));
            int mo = Int32.Parse(dateStr.Substring(2, 2));
            int da = Int32.Parse(dateStr.Substring(4, 2));

            return new DateTime(yr, mo, da);
        }

        public static double divYieldAsDouble(string sym)
        {
            /*
            Dim yieldStr As String
            yieldStr = GetTOS(sym, "YIELD")
            yieldStr = Left(yieldStr, Len(sym))

            divYieldAsDouble = yieldStr / 100
             */
            return 0.0;
        }

        /// <summary>
        /// 
        /// Does not currently support FOPs 
        /// </summary>
        /// <param name="sym"></param>
        /// <returns></returns>
        public static string exDateStr(string sym)
        {
            string str = "";
            int idx1 = Utl.pos_first_num(sym);
            int idx2 = Utl.pos_last_alpha(sym);



            if (sym.Length > 0 && idx1 != -1 && idx1 != -1)
            {
                str = sym.Substring(idx1, idx2 - idx1);
            }

            return str; 
        }


        public static double strike(string sym)
        {
            double strk = 0.0;
            int idx1 = Utl.pos_last_alpha(sym);

            if (sym.Length > 6)
            {
                strk = Double.Parse(sym.Substring(idx1 + 1));
            }
            return strk; 
        }


        public static int multiplier(string sym)
        {
            int amt = 0;

            // FOP
            if (Utl.startsWith(sym, "./"))
            {
                amt = 50;
            } 
            else if (Utl.startsWith(sym, "."))
            {
                amt = 100;
            } 
            else
            {
                amt = 1;
            }
            return amt;
        }
    } // end class opt 


    public class Basic

    {
        [ExcelFunction()]
        public static void generateCover()
        {

            //Worksheet ws = Worksheet.ActiveSheet();
            //ws.Range("G20").SetValue(9);
        }

        public static Dictionary<string, string> tosRTDMap = new Dictionary<string, string>()
#region 
        {
            // Label                     ThinkOrSwim item
            {"% Change"                , "MARK_PERCENT_CHANGE"},

            {"Description"             , "Description"},
            {"LAST"                    , "LAST"},
            {"BID"                     , "BID"},
            {"ASK"                     , "ASK"},
            {"52High"                  , "52High"},
            {"52Low"                   , "52Low"},
            {"ASK_SIZE"                , "ASK_SIZE"},
            {"ASKX"                    , "ASKX"},
            {"AV_TRADE_PRICE"          , "AV_TRADE_PRICE"},
            {"AX"                      , "AX"},
            {"BA_SIZE"                 , "BA_SIZE"},
            {"BACK_EX_MOVE"            , "BACK_EX_MOVE"},
            {"BACK_VOL"                , "BACK_VOL"},
            {"BETA"                    , "BETA"},
            {"BID_SIZE"                , "BID_SIZE"},
            {"BIDX"                    , "BIDX"},
            {"BX"                      , "BX"},
            {"CALL_VOLUME_INDEX"       , "CALL_VOLUME_INDEX"},
            {"CLOSE"                   , "CLOSE"},
            {"COVERED_RETURN"          , "COVERED_RETURN"},
            {"DELTA"                   , "DELTA"},
            {"DIV"                     , "DIV"},
            {"DIV_FREQ"                , "DIV_FREQ"},
            {"EPS"                     , "EPS"},
            {"EX_DIV_DATE"             , "EX_DIV_DATE"},
            {"EX_MOVE_DIFF"            , "EX_MOVE_DIFF"},
            {"EXCHANGE"                , "EXCHANGE"},
            {"EXPIRATION"              , "EXPIRATION"},
            {"EXPIRATION_DAY"          , "EXPIRATION_DAY"},
            {"EXTRINSIC"               , "EXTRINSIC"},
            {"FRONT_EX_MOVE"           , "FRONT_EX_MOVE"},
            {"FRONT_VOL"               , "FRONT_VOL"},
            {"FX_PAIR"                 , "FX_PAIR"},
            {"GAMMA"                   , "GAMMA"},
            {"HIGH"                    , "HIGH"},
            {"HTB_ETB"                 , "HTB_ETB"},
            {"IMPL_VOL"                , "IMPL_VOL"},
            {"INTRINSIC"               , "INTRINSIC"},
            {"LAST_SIZE"               , "LAST_SIZE"},
            {"LASTX"                   , "LASTX"},
            {"LOW"                     , "LOW"},
            {"LX"                      , "LX"},
            {"MARK"                    , "MARK"},
            {"MARK_CHANGE"             , "MARK_CHANGE"},
            {"MARK_PERCENT_CHANGE"     , "MARK_PERCENT_CHANGE"},
            {"MARK_PERCENT_UNDERLYING" , "MARK_PERCENT_UNDERLYING"},
            {"MARKET_CAP"              , "MARKET_CAP"},
            {"MAX_COVERED_RETURN"      , "MAX_COVERED_RETURN"},
            {"MRKT_MKR_MOVE"           , "MRKT_MKR_MOVE"},
            {"MT_NEWS"                 , "MT_NEWS"},
            {"NET_CHANGE"              , "NET_CHANGE"},
            {"OPEN"                    , "OPEN"},
            {"OPEN_INT"                , "OPEN_INT"},
            {"OPTION_VOLUME_INDEX"     , "OPTION_VOLUME_INDEX"},
            {"P_L_DAY"                 , "P_L_DAY"},
            {"P_L_OPEN"                , "P_L_OPEN"},
            {"P_L_PERCENT"             , "P_L_PERCENT"},
            {"P_L_YTD"                 , "P_L_YTD"},
            {"PE"                      , "PE"},
            {"PERCENT_CHANGE"          , "PERCENT_CHANGE"},
            {"PERCENT_IN_THE_COLUMN"   , "PERCENT_IN_THE_COLUMN"},
            {"PERCENT_OUT_THE_MONEY"   , "PERCENT_OUT_THE_MONEY"},
            {"POSITION_N_L"            , "POSITION_N_L"},
            {"POSITION_QTY"            , "POSITION_QTY"},
            {"PROB_OF_TOUCHING"        , "PROB_OF_TOUCHING"},
            {"PROB_OTM"                , "PROB_OTM"},
            {"PUT_CALL_RATIO"          , "PUT_CALL_RATIO"},
            {"PUT_VOLUME_INDEX"        , "PUT_VOLUME_INDEX"},
            {"QUOTE_TREND"             , "QUOTE_TREND"},
            {"RHO"                     , "RHO"},
            {"ROC"                     , "ROC"},
            {"ROR"                     , "ROR"},
            {"SHARES"                  , "SHARES"},
            {"STOCK_BTA"               , "STOCK_BETA"},
            {"STENGTH_METER"           , "STENGTH_METER"},
            {"STRIKE"                  , "STRIKE"},
            {"SYMBOL"                  , "SYMBOL"},
            {"Ticker"                  , "SYMBOL"},
            {"THETA"                   , "THETA"},
            {"VEGA"                    , "VEGA"},
            {"VOL_DIFF"                , "VOL_DIFF"},
            {"VOL_INDEX"               , "VOL_INDEX"},
            {"VOLUME"                  , "VOLUME"},
            {"WEIGHTED_BACK_VOL"       , "WEIGHTED_BACK_VOL"},
            {"Maturity"                , "Maturity"},
            {"EV/E 2019"               , "EV/E 2019"},
            {"Earnings 2019"           , "Earnings 2019"},
            {"AE 2019"                 , "AE 2019"},
            {"Yield"                   , "Yield"}
        };
#endregion


        public static double[,] Func( double x, double y)
        {
            double[,] array = new double[2, 2];
            array[0, 0] = x;
            array[0, 1] = y;
            array[1, 0] = Math.Pow(x, 2);
            array[1, 1] = Math.Pow(y, 2);

            return array;
        }


        public static String TOSFetch(string col)
        {
            return tosRTDMap.ContainsKey(col) ? tosRTDMap[col] : "" ;
        }


        public static double MainFetch( string col)
        {

            return 0.0;
        }
        /// <summary>
        /// Check if the supplied symbol is valid
        /// Checks: Empty 
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        public static bool isValid(string symbol)
        {
            bool g2g = true;
            string sym = symbol.Trim();

            //if (sym == "")
            if (string.IsNullOrWhiteSpace(sym)) 
            {
                g2g = false;
            }
            
            return !string.IsNullOrWhiteSpace(symbol.Trim());
        } 


        /*
        * 
        */
        public static bool isOption( string ticker)
        {
            return ticker.Length > 10 && firstCharIs(ticker, '.');
        }


        /*
         * This function can and wiil be called from within the 'isOption' function to determine if a provided ticker is a FOP
         */
        public static bool isFuture(string ticker)
        {
            return ticker.Length > 3 && firstCharIs(ticker, '/');
        }

       
        /*
         * 
         */
        public static bool isFOP(string ticker)
        {
            return isOption(ticker) && isFuture(ticker.TrimStart('.'));
        }

        /*
         * This function can and wiil be called from within the 'isOption' function to determine if a provided ticker is a FOP
         */
        public static bool firstCharIs(string str,  char exp)
        {
            // First, do length check 
            return (str.Trim().Length > 0 && str.Trim()[0] == exp);
        }


        /*
         * 
         */
        public static double getRange(double last, double high, double low)
        {
            bool valid = last != 0.0;
            valid = valid | (high != 0.0);
            valid = valid | (low != 0.0);
            if (valid)
                return (last - low) / (high - low) * 100;
            else
                return 0.0;
        }


        public static double terminalValue(double cashFlow, double LTg, double WACC)
        {
            // Add WACC > LTg check 
            double val = (Int32)(cashFlow * (1.0F + LTg) / (WACC - LTg));
            return val;
        }


        // works 
        public static double discount(Int32 amt, Int32 n, double rate)
        {
            return (double)(amt / Math.Pow((1.0F + rate), n));
        }

    }

    public class Valuation
    {

        public static double NPV_Basic(double cf_0, Int32 N, double STg, double LTg, double WACC)
        {
            double presentValue = 0;
            double cf_t = cf_0; // Cash flow time t

            for(int time_t = 1; time_t <= N; time_t++) {
                cf_t = (double)(cf_t * (1.0F + STg));
                presentValue += (double)(cf_t / Math.Pow((1.0F + WACC), time_t));
            }
            
            // Handle Terminal Value            
            cf_t = Basic.terminalValue(cf_t, LTg, WACC);
            presentValue += (double)(cf_t / Math.Pow((1.0F + WACC), N)); // Discout terminal value to present 

            return presentValue;
        }
    }
}
