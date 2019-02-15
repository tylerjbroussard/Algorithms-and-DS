using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Ex1
{
	class WordGame
	{
		private HashSet<string> allWords;	// all knowns words, i.e., the English dictionary
		List<List<char>> board;             // the playing board
		List<List<bool>> visited;			// indicates if a cell on the board has been visted or not
		private static string allWordsFile =                                                                            "C:\\Users\\sanjeevq\\OneDrive\\Teaching\\AlgoAndDS\\C#\\Ex1\\Ex1\\Words.txt";
		private int maxWordLength = 5;

		static void MainWorGame(string[] args)
		{
			uint boardRows = 6;
			uint boardCols = 6;
			WordGame wg = new WordGame(allWordsFile, boardRows, boardCols);
			wg.Run();
		}

		public WordGame(string wordsFile, uint rows, uint cols)
		{
			InitializeWords(wordsFile);
			InitializeBoard(rows, cols);
		}

		private void InitializeBoard(uint numRows, uint numCols)
		{
			// First allocate the memory for the board with numRows and numCols, and the visited structure
			visited = new List<List<bool>>((int)numRows);
			board = new List<List<char>>((int)numRows);
			for (int row = 0; row < numRows; ++row)
			{
				visited.Add(new List<bool>((int)numCols));
				board.Add(new List<char>((int)numCols));
			}

			// Now fill up board with some characters, and initialize visited to false
			string boardStr = "eporilafgklnzioesdtquanipldbnvxcveroiylknm";
			for (int row = 0; row < numRows; ++row)
			{
				for (int col = 0; col < numCols; ++col)
				{
					board[row].Add(boardStr[col + row * (int)numCols]);
					visited[row].Add(false);
				}
			}
		}

		private void InitializeWords(string wordsFile)
		{
			allWords = new HashSet<string>();

			char[] wordSeparators = { ' ', '\n', '\t' };

			try
			{
				uint lineCount = 0;
				using (StreamReader sr = new StreamReader(wordsFile))
				{
					string line;

					while ((line = sr.ReadLine()) != null)
					{
						++lineCount;
						string[] wordsInLine = line.Split(wordSeparators);

						foreach (var word in wordsInLine)
						{
							if (word.Length > 0)
								allWords.Add(word);
						}
					}
				}

				Console.WriteLine("Read " + allWords.Count + " words from " + lineCount + " lines in words file");
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception reading words file:" + e.ToString());
			}
		}
		
		public void Run()
		{
			ShowBoard();
			HashSet<string> foundWords = FindAllWordsInBoard();
			Print(foundWords);
		}

		private HashSet<string> FindAllWordsInBoard()
		{
			HashSet<string> foundWords = new HashSet<string>();
			int numRows = board.Count;
			int numCols = board[0].Count;

			for (int row = 0; row < numRows; ++row)
			{
				for (int col = 0; col < numCols; ++col)
				{
					StringBuilder word = new StringBuilder();

					// Find all words starting at character in cell (row,col) in the board
					FindWordsStartingAtCell(row, col, word, foundWords);
				}
			}

			return foundWords;
		}

		private void FindWordsStartingAtCell(int row, int col, StringBuilder word, HashSet<string> foundWords)
		{
			if (word.Length >= maxWordLength)
				return;

			MarkVisited(true, row, col);        // mark cell (row,col) as visited.
			word.Append(board[row][col]);

			AddFoundWordIfValid(word, foundWords);

			// Now go forward in DFS mode 
			for (int rowIdx = row - 1; rowIdx <= row + 1; ++rowIdx)
			{
				if (!IsValidRow(rowIdx))
					continue;
				for (int colIdx = col - 1; colIdx <= col + 1; ++colIdx)
				{
					if (!IsValidCol(colIdx))
						continue;
					if (visited[rowIdx][colIdx])
						continue;

					FindWordsStartingAtCell(rowIdx, colIdx, word, foundWords);
				}
			}

			// We are leaving now, mark cell (row,col) as
			// not visited (in case we come back to this cell in future)
			MarkVisited(false, row, col);

			// remove the last character we added to word, ie. board[row][col] we added at beginning of this method
			if (word.Length > 0)
				word.Remove(word.Length - 1, 1);
		}

		private void MarkVisited(bool visitedStatus, int row, int col)
		{
			visited[row][col] = visitedStatus;
		}

		private bool IsValidRow(int row)
		{
			return (row >= 0) && (row < board.Count);
		}

		private bool IsValidCol( int col)
		{
			return (col >= 0) && (col < board[0].Count);
		}


		private void AddFoundWordIfValid(StringBuilder word, HashSet<string> foundWords)
		{
			if (allWords.Contains(word.ToString()))
			{
				foundWords.Add(word.ToString());
			}
		}
		
		private void Print(HashSet<string> words)
		{
			Console.WriteLine("Found " + words.Count + " words:");
			foreach(var word in words)
			{
				Console.Write(word + " ");
			}
		}

		private void ShowBoard()
		{
			int numRows = board.Count;
			int numCols = board[0].Count;

			Console.WriteLine();

			for (int row = 0; row < numRows; ++row)
			{
				for (int col = 0; col < numCols; ++col)
				{
					Console.Write(board[row][col] + "   ");
				}
				Console.WriteLine();
				Console.WriteLine();
			}
		}
		
	}
}
