﻿using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Ventura.Interfaces;


namespace Ventura.Accumulator.EntropyExtractors
{
	/// <summary>
	/// Makes a REST call to an API provided by Random.org (https://www.random.org/bytes/)
	/// The entropy comes from atmospheric noise.
	/// </summary>
	public class RandomOrgExtractor: EntropyExtractorBase, IEntropyExtractor
	{
		public RandomOrgExtractor(IEventEmitter eventEmitter) : base(eventEmitter)
		{
		}
		protected override Func<byte[]> ExtractEntropicData()
		{
			return () =>
			{
				using (WebClient wc = new WebClient())
				{
					var response = wc.DownloadString("https://www.random.org/cgi-bin/randbyte?nbytes=30&format=d");

					response = Regex.Replace(response, @"\n", " ");
					return response.Split(' ').Where(n => !string.IsNullOrEmpty(n)).Select(byte.Parse).ToArray();
				}
			};
		}
	}
}
