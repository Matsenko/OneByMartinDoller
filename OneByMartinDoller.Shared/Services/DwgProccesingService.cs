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
		public Dictionary<string, Dictionary<string, int>> GetProccessing(CadDocument doc)
		{
		
			
			var textL = new Dictionary<string, List<Entity>>();
			var textM = new Dictionary<string, List<MText>>();

			var roomLabel = doc.Layers.FirstOrDefault(l => l.Name == "Room Lable");
			var roomLabelEntities = new List<Entity>();
			var eTypeValueEntity = new Dictionary<ObjectType, List<Entity>>();
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

				if (!eTypeValueEntity.ContainsKey(entity.ObjectType))
				{
					eTypeValueEntity.Add(entity.ObjectType, new List<Entity>());
				}
				eTypeValueEntity[entity.ObjectType].Add(entity);
				if (entity is TextEntity)
				{
					var text = (TextEntity)entity;

					if (!textL.ContainsKey(text.Value))
					{
						textL.Add(text.Value, new List<Entity>());
					}
					textL[text.Value].Add(entity);
				}
				if (entity is MText)
				{
					var text = (MText)entity;

					if (!textM.ContainsKey(text.Value))
					{
						textM.Add(text.Value, new List<MText>());
					}
					textM[text.Value].Add((text));
				}

				if (entity.Layer == roomLabel)
				{
					roomLabelEntities.Add(entity);
				}
			}
			var roomVertices = ACadSharp.Examples.Program.GetRoomVertices(layEntiTypeEntity);
			var pBlockCountInRooms = ACadSharp.Examples.Program.CountPBlockInRooms(layEntiTypeEntity, roomVertices);
			return pBlockCountInRooms;
		}
	}
}
