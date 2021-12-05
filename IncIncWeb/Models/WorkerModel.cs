// HourlyWorkerModel.cs
//         Title: Hourly Worker Web
//	     Created: November 23rd 2021
// Last Modified: December 4th 2021
//    Written By: Katherine Bellman
//	
//	Description: Model for HourlyWorker class and is inherited by the SeniorWorker class

using System;
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
		/// Logs time Worker was entered
		/// </summary>
		[Display(Name = "Date Entered: ")]
		public DateTime DateEntered { get; private set; }

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


		[Display(Name = "Pay:")]
		public string Pay
		{

			get
			{
				double employeeMessages = Convert.ToDouble(Messages); // to pass Worker's Messages value to for calculation
				double returnRate = 0; // Gets the payrate according to num

				//====== 2D Array for Pay calculations =====
				double[] messagesSent = { 1, 1250, 2500, 3750, 5000 };
				double[] messagesPayRate = { 0.02, 0.024, 0.028, 0.034, 0.04 };

				//loop through to arrays to find correct range and return the associated rate from second array
				for (int counter = 0; counter < messagesSent.Length; counter++)
				{
					//compare to find coresponding range for messages sent
					if (employeeMessages >= messagesSent[counter])
					{
						//return the rate that is at the same index as coresponding range
						returnRate = messagesPayRate[counter];
					}
				}

				//calculate inputed worker total pay
				double result = returnRate * employeeMessages;
				//convert calculation result  to decimal to pass to employeePay 
				return result.ToString("C");
			}
		}
	}
}
