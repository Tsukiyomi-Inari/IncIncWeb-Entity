// HourlyWorkerModel.cs
//         Title: Hourly Worker Web
// Last Modified: November 23th 2021
//    Written By: Katherine Bellman
//	
//	Description: Model for Hourly/SeniorWorker class


using System.ComponentModel.DataAnnotations;


namespace IncIncWeb.Models
{
	public class WorkerModel
	{
		//worker ID
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
		/// True if the worker is a senior worker, False if not.
		/// </summary>
		[Required]
		[Display(Name = "Worker Type:")]
		public bool IsSeniorWorker { get; set; }

		/// <summary>
		/// Number of messages sent by Worker
		/// </summary>
		[Required(AllowEmptyStrings = false, ErrorMessage = "You must enter the number of messages sent")]
		[Range((int)1, 15000, ErrorMessage = "Messages sent be be between 1 to 15000")]
		[Display(Name = "Messages Sent:")]
		public string Messages { get; set; }

		///// <summary>
		///// Worker pay
		///// </summary>
		//public decimal Pay { get; set; }

		///// <summary>
		///// Total workers
		///// </summary>
		//public int TotalWorkers { get; set; }

		///// <summary>
		///// Total Pay
		///// </summary>
		//public decimal TotalPay { get; set; }

		///// <summary>
		///// Average Pay
		///// </summary>
		//public decimal AveragePay { get; set; }

		///// <summary>
		///// Total Messages Sent
		///// </summary>
		//public int TotalMessages { get; set; }

		//public new string ToString { get; set; }

		///// <summary>
		///// Parameterized
		///// </summary>
		///// <param name="firstName"></param>
		///// <param name="lastName"></param>
		///// <param name="messages"></param>
		//public WorkerModel(string firstName, string lastName, string messages)
		//{

		//}

		///// <summary>
		///// Default
		///// </summary>
		//public WorkerModel()
		//{

		//}
	}
}
