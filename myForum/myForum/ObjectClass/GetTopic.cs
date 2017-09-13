using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace myForum
{
    public class GetTopic 
    {
		public string ToJsonString(Topic topic)
		{
			return JsonConvert.SerializeObject(topic);
		}

		public Topic ToObject(String json)
		{
			Topic topic = JsonConvert.DeserializeObject<Topic>(json);
			return topic;
		}

		public List<Topic> List(String json)
		{
			List<Topic> list = JsonConvert.DeserializeObject<List<Topic>>(json);
			return list;
		}

		public String ListToJson(List<Topic> topics)
		{
			String json = JsonConvert.SerializeObject(topics);
			return json;
		}
    }
}

