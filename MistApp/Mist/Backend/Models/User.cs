﻿namespace Mist.Backend.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
	}
}
