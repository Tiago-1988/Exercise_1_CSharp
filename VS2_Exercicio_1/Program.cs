using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS2_Exercicio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcedimentoAvaliacoes();
            //ProcedimentoArrayBidimensional();
            ProcedimentoExercicio4();
            Console.WriteLine("Pressione tecla para sair");
            Console.ReadKey();
        }
        // exercicio 1 - função para obtenção de intervalo inteiro 

        static int ObterNumeroInteiro(int Min, int Max)
        {
            int numero = 0;
            string valor = "";
            do
            {
                Console.Write("Defina um número inteiro entre {0} e {1}:", Min, Max);
                valor = Console.ReadLine();
                if (int.TryParse(valor, out numero) == false)
                    Console.WriteLine("Formato Inválido");
                else if (numero < Min | numero > Max)
                    Console.WriteLine("Valor fora  do intervalo");
            } while (int.TryParse(valor, out numero) == false |
                        numero < Min | numero > Max);
            return numero; 
        }


        static void ProcedimentoAvaliacoes()
        {
            // criar um array 
            int[] avaliacoes = new int[10];
            //Introdução dos valores 
            for (int i = 0; i < avaliacoes.Length; i++)
            {
                int n = ObterNumeroInteiro(0, 20);
                avaliacoes[i] = n;      
            }
            // Apresnetação dos valores do array
            for (int i = 0; i < avaliacoes.Length; i++)
            {
                Console.Write("{0}\t", avaliacoes[i]);
            }

            // 2.1 Calcular a media das avaliações 
            double media = 0;
            media = avaliacoes.Average();
            Console.WriteLine("\nA média das avaliações é de: {0}", media);

            // 2.2 indicar a avaliação Minima e a Máxima 

            Console.WriteLine("A avaliação mais baixa é: {0}, e a avaliação mais " +
                "alta é: {1}", avaliacoes.Min(), avaliacoes.Max());
            // 2.3 indicar o número de aprovados e número de reprovados
            int aprovados = 0, reprovados = 0;
            for (int i = 0; i < avaliacoes.Length; i++)
            {
                if (avaliacoes[i] >= 10)
                    aprovados++;
                else
                    reprovados++;
            }
            Console.WriteLine("O número de reprovados é {0} e o número de aprovados " +
                "é de {1}", reprovados, aprovados);
            //2.4 indicar as 3  melhores notas 
            Array.Sort(avaliacoes);
            Array.Reverse(avaliacoes);
            Console.WriteLine("");
            Console.WriteLine("As 3 melhores avaliações são: {0} ; {1} ; {2}", avaliacoes[0], avaliacoes[1], avaliacoes[2] );
            //2.5 indicar a moda das notas utilizando dicionário

            Dictionary<int, int> moda = new Dictionary<int, int>();
            foreach (int a in avaliacoes)
            {
                if (moda.ContainsKey(a))
                    moda[a] = moda[a] + 1;
                else
                    moda[a] = 1;
            }

            int resultado = int.MinValue;
            int Max = int.MinValue; 
            foreach(int Key in moda.Keys)
            {
                if (moda[Key] > Max)
                {
                    Max = moda[Key];
                    resultado = Key;
                }
            }
            Console.WriteLine("A moda das avalições é {0}", resultado);

            //2.6 Pedir ao utilizador um valor e verificar quantas vezes esse valor está no array
            int contador = 0; 
            int z = ObterNumeroInteiro(0, 20);
            Console.WriteLine("O valor definido é: {0}", z);
            for (int i = 0; i < avaliacoes.Length; i++)
            {
                if (avaliacoes[i] != z)
                {
                    contador = contador + 0;
                }
                else
                    contador++;
            }
            Console.WriteLine("O valor {0} está presente no array {1} vezes.", z, contador);

            // 2.7 Ordenar o array de forma ascendente 
            Console.WriteLine("As avaliações ordenadas de forma ascendente:");
            Array.Sort(avaliacoes);
            for (int i = 0; i < avaliacoes.Length; i++)
            {
                Console.Write("{0}\t", avaliacoes[i]);
            }
            Console.WriteLine("");
            // 2.8 escrever as 3, 4 e 5 melhores avaliações do array
            Console.WriteLine("As 3ª, 4ª e 5ª melhores avaliações:");
            Array.Reverse(avaliacoes);
            for (int i = 2; i <= 4; i++)
            {
                Console.Write("{0}\t", avaliacoes[i]);
            }
        }

        static void ProcedimentoArrayBidimensional()
        {
            // 3.1 criar e preencher os arrays bidimensionais 
            int[,] arrayA = new int[3, 3];
            int[,] arrayB = new int[3, 3];
            Console.WriteLine("Obter valores para array A");
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    int n = ObterNumeroInteiro(-10, 10);
                    arrayA[i, j] = n;
                }
            }
            Console.WriteLine("Obter valores para array B");
            for (int i = 0; i < arrayB.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    int n = ObterNumeroInteiro(-10, 10);
                    arrayB[i, j] = n;
                }
            }
            // 3.2 definir em que array a média dos valores é maior 
            int somaA = 0, somaB = 0;
            double mediaA = 0, mediaB = 0;

            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    somaA = somaA + arrayA[i, j];
                }
            }
            mediaA = (double)somaA / arrayA.Length;

            for (int i = 0; i < arrayB.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    somaB = somaB + arrayB[i, j];
                }
            }
            mediaB = (double)somaB / arrayB.Length;

            if (mediaA > mediaB)
                Console.WriteLine("A maior média é a A com {0}.", mediaA);
            else
                Console.WriteLine("A maior média é a b com {0},", mediaB);
            // 3.3 array com maior incidência de valores negativos 

            int  negativosA = 0, negativosB = 0;
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    if (arrayA[i, j] < 0)
                        negativosA++;
                }
            }
            for (int i = 0; i < arrayB.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    if (arrayB[i, j] < 0)
                        negativosB++;
                }
            }
            if(negativosA > negativosB)
                Console.WriteLine("O array com maior incidência de negativos é o " +
                    "A com {0} valores negativos.", negativosA);
            else
                Console.WriteLine("O array com maior incidência de negativos é o " +
                    "B com {0} valores negativos.", negativosB);
            Console.WriteLine();
            //3.4 soma dos valores dos array e transferencia para outro array
            int soma = 0;
            int[,] arraySoma = new int[3, 3];

            for (int i = 0; i < arraySoma.GetLength(0); i++)
            {
                for (int j = 0; j < arraySoma.GetLength(1); j++)
                {
                    soma = arrayA[i, j] + arrayB[i, j];
                    arraySoma[i, j] = soma; 
                }
            }

            for (int i = 0; i < arraySoma.GetLength(0); i++)
            {
                for (int j = 0; j < arraySoma.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arraySoma[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Troca dos valores dos arrays");
            // 2.5 troca dos valores do array a para o arrayb e vice versa.
            int auxiliar = 0; 
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    auxiliar = arrayA[i, j];
                    arrayA[i, j] = arrayB[i, j];
                    arrayB[i, j] = auxiliar;
                }
            }

            Console.WriteLine("Array A");
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arrayA[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Array B");
            for (int i = 0; i < arrayB.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arrayB[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void ProcedimentoExercicio4()
        {
            // 4.1 procedimento de troca de valores entre arrays. 
            int[,] arrayA = new int[3, 5] { { -2, 3, 4, 11, -8 }, { -1, 0, 12, -6, 9 }, {23,4,6,8,-3 } };
            int[,] arrayB = new int[5, 3] { { 2, 3, 8 },{ -2, -4, -5 },{ 0, 8, -14 },{ 3, 5, 6 },{ -9, -8, -1 }};

            Console.WriteLine("Array A");
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arrayA[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Array B");
            for (int i = 0; i < arrayB.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arrayB[i, j]);
                }
                Console.WriteLine();

            }
            Console.WriteLine("Array auxiliar");
            int[] auxiliar = new int[5];
            int x = 0, e=1, k = 2, w = 0;

            for (int j = 0; j < 5; j++)
            {
                auxiliar[x] = arrayA[e,j];
                x++;
            }
            for (int i = 0; i < 5; i++)
            {
                arrayA[e, i] = arrayB[i, k];
            }
            for (int i = 0; i < 5; i++)
            {
                arrayB[i, k] = auxiliar[w];
                w++;
            }
            Console.WriteLine("Array A/2");
            for (int i = 0; i < arrayA.GetLength(0); i++)
            {
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arrayA[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Array B/2");
            for (int i = 0; i < arrayB.GetLength(0); i++)
            {
                for (int j = 0; j < arrayB.GetLength(1); j++)
                {
                    Console.Write("{0}\t", arrayB[i, j]);
                }
                Console.WriteLine();

            }

        }
    }
}
