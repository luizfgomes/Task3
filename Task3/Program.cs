using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3 {
    class Program {

        static void Main(string[] args)
        {

            Console.WriteLine(solution(6, 1, 1));
            Console.ReadLine();
            Console.WriteLine(solution(1, 3, 1));
            Console.ReadLine();
            Console.WriteLine(solution(0, 8, 1));
            Console.ReadLine();
            Console.WriteLine(solution(0, 8, 101));
            Console.ReadLine();
        }

        public static string solution(int A, int B, int C) {

            string rest;
            if ((A>=0 && A<=100) && (B>= 0 && B<= 100) && (C >= 0 && C <= 100)) {

                CalcTheMostValue calcTheMostValue = new CalcTheMostValue();

                List<ImportantValues> newList = calcTheMostValue.ConvertValuesToList(A, B, C);
                rest = AlphabetGeneration.RestAlphabet(newList);

                return rest;
            } else {

                rest = "Valores Informados devem estar entre 0..100";
                return rest;
            }

        }
    }

    class ImportantValues {
        public int value { get; set; }
        public string letters { get; set; }
    }

    class CalcTheMostValue {

        public List<ImportantValues> listImportValues = new List<ImportantValues>();
        public List<ImportantValues> newList = new List<ImportantValues>();

        public List<ImportantValues> ConvertValuesToList(int A, int B, int C) {

            listImportValues = new List<ImportantValues> {

                new ImportantValues{value = A, letters = "a"},
                new ImportantValues{value = B, letters = "b"},
                new ImportantValues{value = C, letters = "c"}
            };

            var result = listImportValues.OrderByDescending(x => x.value);

            List<ImportantValues> newList = new List<ImportantValues>();

            foreach(var e in result) {

                newList.Add(new ImportantValues { value = e.value, letters = e.letters });
            }

            return newList;
        }

    }

    class AlphabetGeneration {

        public static string RestAlphabet(List<ImportantValues> T) {

            string result = "";

            int counterFirst = 0;
            int counterSecound = 0;
            int counterThird = 0;

            CalcFirstNumber();

            void CalcFirstNumber() {

                while (T[0].value > 0 && counterFirst < 2) {

                    counterFirst++;
                    T[0].value--;
                    result += T[0].letters;
                }

                if ((counterFirst == 2 || T[0].value == 0) && T[1].value > 0) {

                    CalcSecoundNumber();
                } else if ((counterFirst == 2 || T[0].value == 0) && T[2].value > 0) {

                    CalcThirdNumber();
                }
            }

            void CalcSecoundNumber() {

                while (T[1].value > 0 && counterSecound < 2) {

                    counterSecound++;
                    T[1].value--;
                    result += T[1].letters;
                }
                if (counterSecound == 2 || T[1].value == 0) {

                    counterFirst = 0;
                    counterSecound = 0;
                    CalcFirstNumber();
                }
            }

            void CalcThirdNumber() {

                while (T[2].value > 0) {

                    if (counterThird < 2) {

                        counterThird++;
                        T[2].value--;
                        result += T[2].letters;
                    }
                }
                if (counterSecound == 2 || T[1].value == 0) {

                    counterFirst = 0;
                    counterThird = 0;
                    CalcFirstNumber();
                }
            }
            return result;
        }

    }

}
