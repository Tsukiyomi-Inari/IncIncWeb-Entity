// HourlyWorkerModel.cs
//         Title: Hourly Worker Web
//	     Created: November 23rd 2021
// Last Modified: December 4th 2021
//    Written By: Katherine Bellman
//	
//	Description: Model for HourlyWorker class and is inherited by the SeniorWorker class

using System.ComponentModel.DataAnnotations;

namespace IncIncWeb.Models
{
	public class WorkerModel
	{
		/// <summary>
		/// Worker's Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Worker first name
		/// </summary>
		[Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a first name")]
		[Display(Name = "First Name:")]
		public string FirstName { get; set; }

		/// <summary>
		/// Worker last name
		/// </summary>
		[Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a last name")]
		[Display(Name = "Last Name:")]
		public string LastName { get; set; }



		/// <summary>
		/// Number of messages sent by Worker
		/// </summary>
		[Required(AllowEmptyStrings = false, ErrorMessage = "You must enter the number of messages sent")]
		[Range((int)1, 15000, ErrorMessage = "Messages sent be be between 1 to 15000")]
		[Display(Name = "Messages Sent:")]
		public string Messages { get; set; }


	}
}
