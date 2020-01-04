using System;
using System.Collections.Generic;
using System.Threading;

namespace Front_Console
{
	public static class ConsoleManager
	{

		private class MessageConsole
		{
			public readonly ConsoleColor Color;
			public readonly string Message;


			public MessageConsole(ConsoleColor Color, string Message)
			{
				this.Color = Color;
				this.Message = Message;
			}
		}


		private static readonly object readLock = new object();
		private static readonly object writeLock = new object();


		private static List<MessageConsole> trackMessage = new List<MessageConsole>();




		public static void PrintTrack()
		{
			lock (writeLock)
			{
				foreach (MessageConsole message in trackMessage)
				{
					Console.ForegroundColor = message.Color;
					Console.Write(message.Message);
					Console.ResetColor();
				}
			}
		}




		/// <summary>
		/// The program waits for the user to press Enter
		/// </summary>
		public static void ReadKey()
		{
			lock (readLock)
			{
				lock (writeLock)
				{
					Console.WriteLine("\n\n\n       Press any key to continue...");
				}
				Console.ReadKey();
			}

		}


		/// <summary>
		/// The program waits for the user to press Enter
		/// </summary>
		public static string Read(string message)
		{
			lock (readLock)
			{
				lock (writeLock)
				{
					Console.WriteLine(message);
				}
				return Console.ReadLine();
			}

		}



		/// <summary> Displays a message in a given color </summary>
		/// <param : color> color of the message </param>
		/// <param : message> message to be displayed </param>
		public static void Write(ConsoleColor color, string message)
		{
			lock (writeLock)
			{
				Console.ForegroundColor = color;
				Console.Write(message);
				Console.ResetColor();
			}
		}


		/// <summary> Displays a message in a given color and track the message</summary>
		/// <param : color> color of the message </param>
		/// <param : message> message to be displayed </param>
		public static void TrackWrite(ConsoleColor color, string message)
		{
			lock (writeLock)
			{
				Console.ForegroundColor = color;
				Console.Write(message);
				Console.ResetColor();

				trackMessage.Add(new MessageConsole(color, message));
			}
		}


		/// <summary> Displays a message in a given color, then adds a backslash </summary>
		/// <param : color> color of the message </param>
		/// <param : message> message to be displayed </param>
		public static void WriteLine(ConsoleColor color, string message)
		{
			lock (writeLock)
			{
				Console.ForegroundColor = color;
				Console.WriteLine(message);
				Console.ResetColor();
			}
		}


		/// <summary> Displays a message in a given color, then adds a backslash </summary>
		/// <param : color> color of the message </param>
		/// <param : message> message to be displayed </param>
		public static void TrackWriteLine(ConsoleColor color, string message)
		{
			lock (writeLock)
			{
				Console.ForegroundColor = color;
				Console.WriteLine(message);
				Console.ResetColor();

				trackMessage.Add(new MessageConsole(color, message + "\n"));
			}
		}

	}
}
