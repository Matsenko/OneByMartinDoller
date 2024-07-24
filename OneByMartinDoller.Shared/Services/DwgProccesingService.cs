using ACadSharp;
using ACadSharp.Entities;
using OneByMartinDoller.Shared.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneByMartinDoller.Shared.Services
{
	public class DwgProccesingService : IDwgProccessingService
	{
		public string ExtractLastValue(string input)
		{
			int startBracketIndex = input.IndexOf('{');
			int semicolonIndex = input.IndexOf(';');
			int closingBracketIndex = input.IndexOf('}');
			string result = string.Empty;

			if (startBracketIndex >= 0 && semicolonIndex >= 0 && closingBracketIndex > semicolonIndex)
			{
				string firstChar = string.Empty;
				string secondChar = string.Empty;

				if (startBracketIndex > 0)
				{
					firstChar = input.Substring(0, startBracketIndex);
					if (firstChar.Contains('\\'))
					{
						input = input.Remove(0, startBracketIndex);
						semicolonIndex = input.IndexOf(';');
						input = input.Remove(0, semicolonIndex + 1);
						int backSlashIndex = input.IndexOf('\\');
						firstChar = input.Substring(0, backSlashIndex);
						backSlashIndex = input.IndexOf("\\S");
						input = input.Remove(0, backSlashIndex + 2);
						int squareIndex = input.IndexOf("^");
						result = input.Substring(0, squareIndex);

						result = ConvertToSuperscript(result);
					}
					else
					{
						result = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1).Trim();
					}
				}
				else if (startBracketIndex == 0)
				{
					firstChar = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1);
					input = input.Remove(0, closingBracketIndex + 1);
					if (input.Length > 1)
					{
						startBracketIndex = input.IndexOf('{');
						closingBracketIndex = input.IndexOf('}');
						semicolonIndex = input.IndexOf(';');
						secondChar = input.Substring(0, startBracketIndex);
						result = input.Substring(semicolonIndex + 1, closingBracketIndex - semicolonIndex - 1).Trim();
					}
					else
					{
						result = input;
					}
				}
				if (firstChar != string.Empty)
				{
					if (secondChar == string.Empty)
					{
						return $"{firstChar}{result}";
					}
					else
					{
						return $"{firstChar}{secondChar}{result}";
					}
				}
			}

			return input;
		}

		public string ConvertToSuperscript(string input)
		{
			StringBuilder result = new StringBuilder();
			foreach (char c in input)
			{
				result.Append(CharToSuperscript(c));
			}
			return result.ToString();
		}

		public string CharToSuperscript(char c)
		{
			switch (c)
			{
				case '0': return "\u2070";
				case '1': return "\u00B9";
				case '2': return "\u00B2";
				case '3': return "\u00B3";
				case '4': return "\u2074";
				case '5': return "\u2075";
				case '6': return "\u2076";
				case '7': return "\u2077";
				case '8': return "\u2078";
				case '9': return "\u2079";
				case 'a': return "\u1D43";
				case 'b': return "\u1D47";
				case 'c': return "\u1D9C";
				case 'd': return "\u1D48";
				case 'e': return "\u1D49";
				case 'f': return "\u1DA0";
				case 'g': return "\u1D4D";
				case 'h': return "\u02B0";
				case 'i': return "\u2071";
				case 'j': return "\u02B2";
				case 'k': return "\u1D4F";
				case 'l': return "\u02E1";
				case 'm': return "\u1D50";
				case 'n': return "\u207F";
				case 'o': return "\u1D52";
				case 'p': return "\u1D56";
				case 'q': return "\u02A0";
				case 'r': return "\u02B3";
				case 's': return "\u02E2";
				case 't': return "\u1D57";
				case 'u': return "\u1D58";
				case 'v': return "\u1D5B";
				case 'w': return "\u02B7";
				case 'x': return "\u02E3";
				case 'y': return "\u02B8";
				case 'z': return "\u1DBB";
				default: return c.ToString();
			}
		}

		public string CleanRoomName(string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException(nameof(input), "Input cannot be null.");
			}

			if (input.Contains(@"\pxqc;"))
			{
				string result = input.Replace(@"\pxqc;", string.Empty);
				return result;
			}

			return input;
		}
		public Dictionary<string, Dictionary<string, int>> GetProccessing(CadDocument doc)
		{


		

			var layEntiTypeEntity = new Dictionary<string, Dictionary<ObjectType, List<Entity>>>();


			foreach (var entity in doc.Entities)
			{
				var lName = entity.Layer.Name;
				if (!layEntiTypeEntity.ContainsKey(lName))
				{
					layEntiTypeEntity.Add(lName, new Dictionary<ObjectType, List<Entity>>());
				}

				var dOE = layEntiTypeEntity[lName];
				if (!dOE.ContainsKey(entity.ObjectType))
				{
					dOE.Add(entity.ObjectType, new List<Entity>());
				}
				dOE[entity.ObjectType].Add(entity);

				
			}
			var roomVertices = ACadSharp.Examples.Program.GetRoomVertices(layEntiTypeEntity);
			var pBlockCountInRooms = ACadSharp.Examples.Program.CountPBlockInRooms(layEntiTypeEntity, roomVertices);
			return pBlockCountInRooms;
		}
	}
}