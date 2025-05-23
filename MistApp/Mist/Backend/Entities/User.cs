﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Mist.Backend.Entities
{
	[Table("users")]
	public class User
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string Role {  get; set; }
	}
}