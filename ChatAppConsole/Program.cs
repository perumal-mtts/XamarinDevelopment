﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ChatAppService.Services;

namespace MessageSender
{
	class MessageSender
	{
		public const string API_KEY = "AIzaSyCWxbqeD_FNYb6FGYw-32GpFEf3h0iR4Ps";
		public const string MESSAGE = "Hello, Xamarin!";

		static void Main(string[] args)
		{

			UserService se = new UserService(new UserRepository());
			se.ApproveFriendRequest(new ChatAppService.Models.FriendRequest()
			{
				FromUserId = "89",
				ToUserId ="0"
			});

			var jGcmData = new JObject();
			var jData = new JObject();

			jData.Add("message", MESSAGE);
			jGcmData.Add("to", "/topics/global");
			jGcmData.Add("data", jData);

			var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
			try
			{
				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));

					client.DefaultRequestHeaders.TryAddWithoutValidation(
						"Authorization", "key=" + API_KEY);

					Task.WaitAll(client.PostAsync(url,
						new StringContent(jGcmData.ToString(), Encoding.Default, "application/json"))
							.ContinueWith(response =>
							{
								Console.WriteLine(response);
								Console.WriteLine("Message sent: check the client device notification tray.");
								Console.ReadLine();

							}));

				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Unable to send GCM message:");
				Console.Error.WriteLine(e.StackTrace);
			}
		}
	}
}