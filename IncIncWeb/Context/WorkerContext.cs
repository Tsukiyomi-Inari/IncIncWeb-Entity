// HourlyWorkerContext.cs
//         Title: Hourly Worker Web
//		   Created: November 23rd 2021
// Last Modified: December 4th 2021
//    Written By: Katherine Bellman
//	
//	Description: Context for relationships to the HourlyWorkerModel to be used with Entity Framework

using IncIncWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace IncIncWeb.Context
{
	public class WorkerContext : DbContext
	{
		/// <summary>
		/// Contructor for WorkerContext utilizing base options
		/// </summary>
		// <param name="options"></param>
		public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
		{

		}

		/// <summary>
		/// Only Hourly Worker  as the entity to be described/used
		/// </summary>
		public DbSet<WorkerModel> Worker { get; set; }
	}
}
