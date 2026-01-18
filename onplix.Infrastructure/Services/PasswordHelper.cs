using onplix.Application.Interfaces;

namespace onplix.Infrastructure.Services
{
	public class PasswordHelper : IPasswordHelper
	{
		/// <summary>
		/// Hash a password using BCrypt with automatic salt
		/// </summary>
		/// <param name="password">Password to hash</param>
		/// <param name="workFactor">Complexity (default is 12)</param>
		/// <returns>Hashed password string</returns>
		public string HashPassword(string password, int workFactor = 12)
		{
			if (string.IsNullOrEmpty(password))
			{
				throw new ArgumentException("The password cannot be left blank.", nameof(password));
			}

			if (workFactor < 4 || workFactor > 31)
			{
				throw new ArgumentException("Work factor must be from 4 to 31", nameof(workFactor));
			}

			return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
		}

		/// <summary>
		/// Verify password with saved hash
		/// </summary>
		/// <param name="password">Password to check</param>
		/// <param name="hashedPassword">Saved hash string</param>
		/// <returns>True if password matches, False otherwise</returns>
		public bool VerifyPassword(string password = "", string hashedPassword = "")
		{
			if (string.IsNullOrEmpty(password))
			{
				throw new ArgumentException("The password cannot be left blank.", nameof(password));
			}

			if (string.IsNullOrEmpty(hashedPassword))
			{
				throw new ArgumentException("Hash không được để trống", nameof(hashedPassword));
			}

			return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
		}
	}
}
