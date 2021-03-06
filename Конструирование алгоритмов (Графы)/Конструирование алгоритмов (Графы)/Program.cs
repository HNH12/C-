﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OperationsOnGraph;
using System.IO;
using System.ComponentModel;

namespace Конструирование_алгоритмов__Графы_
{
	class ReadAndWriteFile
	{
		/// <summary>
		/// Чтение из файла
		/// </summary>
		/// <param name="inputGraph"></param>
		/// <param name="nameFile"></param>
		static public void ReadingFromFile(RichTextBox inputGraph, string nameFile)
		{
			FileStream fstream = File.OpenRead(nameFile);
			byte[] array = new byte[fstream.Length];
			fstream.Read(array, 0, array.Length);
			inputGraph.Text = System.Text.Encoding.Default.GetString(array);
		}

		/// <summary>
		/// Запись в файл текста из RichTextBox
		/// </summary>
		/// <param name="output"></param>
		/// <param name="nameFile"></param>
		static public void WriteToFile(RichTextBox output, string nameFile, string notation = "")
		{
			FileStream fstream = new FileStream(nameFile, FileMode.OpenOrCreate);
			byte[] array = System.Text.Encoding.Default.GetBytes(notation + output.Text);
			fstream.Write(array, 0, array.Length);
		}

		/// <summary>
		/// Запись в файл текста из RichTexBox и TextBox
		/// </summary>
		/// <param name="outputRichTextBox"></param>
		/// <param name="outputTextBox"></param>
		/// <param name="nameFile"></param>
		static public void WriteToFile(RichTextBox outputRichTextBox, TextBox outputTextBox, string nameFile, 
			string firstNotation = "", string secondNotation = "")
		{
			FileStream fstream = new FileStream(nameFile, FileMode.OpenOrCreate);
			byte[] array1 = System.Text.Encoding.Default.GetBytes(firstNotation + outputRichTextBox.Text);
			byte[] array2 = System.Text.Encoding.Default.GetBytes("\n" + secondNotation + outputTextBox.Text);
			fstream.Write(array1, 0, array1.Length);
			fstream.Write(array2, 0, array2.Length);
		}

		/// <summary>
		/// Запись в файл из TextBox
		/// </summary>
		/// <param name="outputTextBox"></param>
		/// <param name="nameFile"></param>
		static public void WriteToFile(TextBox outputTextBox, string nameFile, string notation = "")
		{
			FileStream fstream = new FileStream(nameFile, FileMode.OpenOrCreate);
			byte[] array = System.Text.Encoding.Default.GetBytes(notation + outputTextBox.Text);
			fstream.Write(array, 0, array.Length);
		}
	}

	public class Tasks
	{
		private void OutputFromListAnswerTextBox(List<int> list, TextBox outTask)
		{
			outTask.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				if (i == list.Count - 1)
					outTask.AppendText(list[i].ToString());
				else
					outTask.AppendText(list[i].ToString() + " - ");
			}
		}

		private void OutputMatrixRichTextBox(int[][] matrix, RichTextBox outMatrix)
		{
			outMatrix.Clear();
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix.Length; j++)
					outMatrix.AppendText(matrix[i][j].ToString() + " ");
				outMatrix.AppendText("\n");
			}
		}

		private void OutputStack(Stack<int> stack, TextBox outStack)
		{
			outStack.Clear();
			while (stack.Count != 0)
				outStack.AppendText(stack.Pop().ToString() + " ");
		}

		private void OutputBellmanFord(int[] distance, int startVertex, RichTextBox outputTask)
		{
			for (int i = 0; i < distance.Length; i++)
			{
				if (i < distance.Length)
				{
					if (distance[i] != int.MaxValue)
						outputTask.AppendText("От " + startVertex + " до " + i + " : " + distance[i] + "\n");
					else
						outputTask.AppendText("От " + startVertex + " до " + i + " : " + "\u221E\n");
				}
				else
				{
					if (distance[i] != int.MaxValue)
						outputTask.AppendText("От вершины " + startVertex + " до вершины " + i + " : " + distance[i]);
					else
						outputTask.AppendText("От вершины " + startVertex + " до вершины " + i + " : \u221E");
				}
			}
		}

		private int GetNeededLength(TextBox nL)
		{
			return Convert.ToInt32(nL.Text);
		}

		private int GetStartVertex(TextBox sV)
		{
			return Convert.ToInt32(sV.Text);
		}

		/// <summary>
		/// Дан смешанный граф. Дано натуральное число n. Найти количество путей длины n.
		/// </summary>
		/// <param name="matrixGraph"></param>
		/// <param name="neededLength"></param>
		/// <param name="outTask"></param>
		public void FirstTask(RichTextBox matrixGraph, TextBox neededLength, TextBox outTask)
		{
			ClassOperationsOnGraph operation = new ClassOperationsOnGraph(matrixGraph);
			int n = GetNeededLength(neededLength);
			int countWay = operation.GetCountWay(n);
			outTask.Clear();
			outTask.AppendText(countWay.ToString());
		}

		/// <summary>
		/// Дан неориентированный граф. Построить произвольное максимальное независимое множество вершин графа.
		/// </summary>
		/// <param name="matrixGraph"></param>
		/// <param name="outTask"></param>
		public void SecondTask(RichTextBox matrixGraph, TextBox outTask)
		{
			ClassOperationsOnGraph operation = new ClassOperationsOnGraph(matrixGraph);
			List<int> Answer = operation.FindMaxIndependent();
			OutputFromListAnswerTextBox(Answer, outTask);
		}

		/// <summary>
		/// Дан ориентированный слабосвязный граф. Построить топологическую сортировку вершин этого графа.
		/// </summary>
		/// <param name="matrixGraph"></param>
		/// <param name="outTask"></param>
		/// <param name="newMatrixGraph"></param>
		public void ThirdTask(RichTextBox matrixGraph, TextBox outTask, RichTextBox newMatrixGraph)
		{
			ClassOperationsOnGraph operation = new ClassOperationsOnGraph(matrixGraph);

			(int[][], Stack<int>) tupleTask = (operation.TopologicalSortGraphAndStack());

			newMatrixGraph.Clear();
			outTask.Clear();

			if (tupleTask.Item1 == null)
				newMatrixGraph.AppendText("Граф не ацикличен\nСортировка невозможна");
			else
			{
				OutputMatrixRichTextBox(tupleTask.Item1, newMatrixGraph);
				OutputStack(tupleTask.Item2, outTask);
			}
		}

		/// <summary>
		/// Дан произвольный неориентированный граф, проверить, будет ли он деревом.
		/// </summary>
		/// <param name="matrixGraph"></param>
		/// <param name="outTask"></param>
		public void FourthTask(RichTextBox matrixGraph, TextBox outTask)
		{
			outTask.Clear();
			ClassOperationsOnGraph operation = new ClassOperationsOnGraph(matrixGraph);
			if (operation.CheckTree())
				outTask.AppendText("Граф является деревом");
			else
				outTask.AppendText("Граф не является деревом");
		}

		/// <summary>
		/// Реализовать алгоритм Беллмана – Форда нахождения кратчайшего пути. Описать возможности его применения.
		/// </summary>
		/// <param name="matrixGraph"></param>
		/// <param name="outTask"></param>
		public void FifthTask(RichTextBox matrixGraph, TextBox inTask, RichTextBox outTask)
		{
			outTask.Clear();
			ClassOperationsOnGraph operation = new ClassOperationsOnGraph(matrixGraph);
			OutputBellmanFord(operation.BellmanFord(GetStartVertex(inTask)),GetStartVertex(inTask), outTask);
		}
	}

	/* Знаю, что это не есть хорошо;
		Буду исправлять по-тихоньку. 
		Если введённые данные не подходят под условие "дано",
		тогда вызываются эти исключения */
	public class ExceptionHandling
	{
		/// <summary>
		/// В матрице нет букв
		/// </summary>
		/// <param name="enterCountWayTextBox"></param>
		/// <returns></returns>
		public bool OnlyNumbers(TextBox enterCountWayTextBox)
		{
			string text = enterCountWayTextBox.Text;
			for (int i = 0; i < text.Length; i++)
			{
				if (!(text[i] >= '1' && text[i] <= '9'))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Граф не взвешанный
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public bool NotWeightedGraph(int[][] graph)
		{
			for (int i = 0; i < graph.Length; i++)
			{
				for (int j = 0; j < graph.Length; j++)
				{
					if (!(graph[i][j] == 0 || graph[i][j] == 1))
						return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Одинаковое количество столбцов и строк
		/// </summary>
		/// <param name="graphRichTextBox"></param>
		/// <returns></returns>
		private bool CheckLength(RichTextBox graphRichTextBox)
		{
			string[] text = graphRichTextBox.Text.Split('\n');
			for (int i = 0; i < text.Length; i++)
			{
				string[] text1 = text[i].Split(' ');
				if (text1.Length != text.Length)
					return false;
				//for (int j = 0; j < text1.Length; j++)
				//{
				//	if (text1[j] != "1" && text1[j]!= "0")
				//		return false;
				//}
			}
			return true;
		}

		public int[][] GetMatrix(RichTextBox graphRichTextBox)
		{
			string[] lines = graphRichTextBox.Text.Split('\n');
			int countVertex = lines.Length;

			int[][] graph = new int[countVertex][];
			for (int i = 0; i < countVertex; i++)
			{
				graph[i] = new int[countVertex];
				string[] elements = lines[i].Split(' ');
				for (int j = 0; j < countVertex; j++)
				{
					graph[i][j] = int.Parse(elements[j]);
				}
			}
			return graph;
		}

		/// <summary>
		/// Неориентированный граф
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public bool UndirectedGraph(int[][] graph)
		{
			for (int i = 0; i < graph.Length; i++)
			{
				for (int j = 0; j < graph.Length; j++)
				{
					if (graph[i][j] != graph[j][i])
						return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Ориентированный граф
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public bool DirectedGraph(int[][] graph)
		{
			for (int i = 0; i < graph.Length; i++)
			{
				for (int j = 0; j < graph.Length; j++)
				{
					if ((graph[i][j] == graph[j][i]) && graph[i][j] == 1)
						return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Проверка матрицы на корректность
		/// </summary>
		/// <param name="graphRichTextBox"></param>
		/// <returns></returns>
		public bool CheckRightMatrix(RichTextBox graphRichTextBox)
		{
			try
			{
				int[][] graph = GetMatrix(graphRichTextBox);
				if (!CheckLength(graphRichTextBox))
					return false;
				if (!NotWeightedGraph(graph))
					return false;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool CheckRightMatrixWeight(RichTextBox graphRichTextBox)
		{
			try
			{
				int[][] graph = GetMatrix(graphRichTextBox);
				if (!CheckLength(graphRichTextBox))
					return false;
				return true;
			}
			catch
			{
				return false;
			}
		}
	}


	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Menu());
		}
	}
}
