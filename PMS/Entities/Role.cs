using System;
namespace PMS.Entities
{
    /// <summary>
    /// To make roles strongly typed and avoid passing them around as strings,
    /// so instead of 'Admin' we can use Role.Admin.
    /// </summary>
	public enum Role
	{
        Admin,
        User
    }
}

