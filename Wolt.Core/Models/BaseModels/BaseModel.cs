using System;
namespace Wolt.Core.Models.BaseModels
{
	public abstract class BaseModel
	{
		public string Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdateAt { get; set; }
    }
}

