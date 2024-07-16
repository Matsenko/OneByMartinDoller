using ACadSharp;
using ACadSharp.Entities;
using OneByMartinDollerSite.Services.IServices;

namespace OneByMartinDollerSite.Services
{
	public class DwgProccesingService: IDwgProccessingService
	{
		
		public Dictionary<string, Dictionary<string, int>> GetProccessing(CadDocument doc)
		{
			var lE = new Dictionary<string, Entity>();
			var l = new List<Entity>();
			var textL = new Dictionary<string, List<Entity>>();
			var textM = new Dictionary<string, List<MText>>();

			var roomLabel = doc.Layers.FirstOrDefault(l => l.Name == "Room Lable");
			var roomLabelEntities = new List<Entity>();
			var eTypeValueEntity = new Dictionary<ObjectType, List<Entity>>();
			var layEntiTypeEntity = new Dictionary<string, Dictionary<ObjectType, List<Entity>>>();
			var cEntite = doc.Entities.Where(x => x.Layer.Name == "Circuitry");

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
			var lines = layEntiTypeEntity["0-CountArea"].Values.First();
			var pLines = new List<List<LwPolyline.Vertex>>();
			foreach (var line in lines)
			{
				pLines.Add(((LwPolyline)line).Vertices);
			}

			var pointV = (MText)layEntiTypeEntity["A-LABEL-GF"].Values.First().First();
			var point = pointV.InsertPoint;
			var indexOfRoom = ACadSharp.Examples.Program.EnterInRoomIndexes(pLines, point);

			var findRoom = new Dictionary<string, int>();

			var allRooms = layEntiTypeEntity["A-LABEL-GF"].Values.First().ToList();
			allRooms.AddRange(layEntiTypeEntity["A-LABEL-FF"].Values.First().ToList());

			foreach (MText point1 in allRooms)
			{
				findRoom.Add(point1.Value, ACadSharp.Examples.Program.EnterInRoomIndexes(pLines, new CSMath.XYZ(point1.InsertPoint.X + (point1.RectangleWidth / 2), point1.InsertPoint.Y, point1.InsertPoint.Z)));
			}
			var roomVertices = ACadSharp.Examples.Program.GetRoomVertices(layEntiTypeEntity);
			var pBlockCountInRooms = ACadSharp.Examples.Program.CountPBlockInRooms(layEntiTypeEntity, roomVertices);
			var r = textL.OrderBy(x => x.Value.Count()).ToList();
			return pBlockCountInRooms;
		}
	}
}
