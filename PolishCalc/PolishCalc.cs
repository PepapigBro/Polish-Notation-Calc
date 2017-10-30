using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PolishCalcLibrary
{
   
    public class PolishCalc
    {

        private string userInput;
        private  double? ExecuteAnOperation(string[] opearands, char _operator)
        {
            switch (_operator)
            {
                case '+':
                    return Convert.ToDouble(opearands[0]) + Convert.ToDouble(opearands[1]);
                case '-':
                    return Convert.ToDouble(opearands[0]) - Convert.ToDouble(opearands[1]);
                case '*':
                    return Convert.ToDouble(opearands[0]) * Convert.ToDouble(opearands[1]);
                case '/':
                    return Convert.ToDouble(opearands[0]) / Convert.ToDouble(opearands[1]);
            }
            return null;

        }

        public PolishCalc(string userInput) {
            this.userInput = userInput;
        }

        public double? Calculate() {
            double? result = null;
            bool errorEnabled = false;
            while (true)
            {
                //Получение всех выражений вида "+ 1 2" - оператор и два операнда справа
                Regex regex = new Regex(@"[-*+/]\s*\d+(\,\d+)?\s+\d+(\,\d+)?");
                MatchCollection matches = regex.Matches(userInput);

                if (matches.Count == 0) { break; }

                foreach (Match matchItem in matches)
                {
                    string itemExpr = matchItem.Value;
                    //замена всех мультипробелов на одинарные пробелы
                    itemExpr = Regex.Replace(itemExpr, @"\s+", " ");

                    //извлечение операндов
                    string[] operands = itemExpr.Split(new char[] { '*', '/', '+', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    //извлечение оператора
                    char _operator = itemExpr[0];

                    //получение результата мат. операции, null - признак ошибки
                    double? resultIteration = ExecuteAnOperation(operands, _operator);

                    if (resultIteration != null)
                    {
                        userInput = userInput.Replace(matchItem.Value, " " + resultIteration.ToString());
                    }
                    else { errorEnabled = true;  break; }
                }



            }
            if (errorEnabled == false) { result = Convert.ToDouble(userInput); }

            return result;


        }


    }
}




