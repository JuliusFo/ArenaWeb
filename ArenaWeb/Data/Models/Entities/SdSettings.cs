using System.ComponentModel.DataAnnotations.Schema;

namespace ArenaWeb.Data.Models.Entities
{
	public class SdSettings
	{
		[Column(TypeName = "numeric(18,0)")]
		public decimal SdSettingsId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Value { get; set; }

		public string ValueType { get; set; }
	}
}