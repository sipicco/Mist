﻿namespace Mist.Backend.DTOs
{
	public class CreateUserDto
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
	}
}
