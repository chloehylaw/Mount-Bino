using UnityEngine;

namespace Map
{
	public enum NodeType
	{
		MinorEnemy,
		EliteEnemy,
		RestSite,
		RandomEvent,
		Boss,
		SpecialistEnemy
	}
}

namespace Map
{
	[CreateAssetMenu]
	public class NodeBlueprint : ScriptableObject
	{
		public Sprite sprite;
		public NodeType nodeType;
	}
}