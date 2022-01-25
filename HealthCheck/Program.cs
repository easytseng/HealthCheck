// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

var client = new HttpClient();

var formContent = new FormUrlEncodedContent(new[]
{
    new KeyValuePair<string, string>("EmpID", "fLUNdyN8Hx0JQXpP2LxtYA%3D%3D"),
    new KeyValuePair<string, string>("QueryYear", "NLGCGG8dDFGDq/oQTs7XWw%3D%3D")
});

var getHolidayResponse = await client.PostAsync("https://smartsync.kpmg.com.tw/kpmgdashboard/MeetingRoom/GetKPMGCalendarHolidayList.ashx", formContent);
var contents = await getHolidayResponse.Content.ReadAsStringAsync();
var root = (JContainer)JToken.Parse(contents);
var list = root.DescendantsAndSelf().OfType<JProperty>().Where(p => p.Name == "Holiday").Select(p => p.Value.Value<string>());
var holidayList = list.ToArray();

var today = DateTime.Now.ToString("yyyy/MM/dd");




string jsonString = File.ReadAllText("config.txt");
JObject json = JObject.Parse(jsonString);
JObject requestJson;
if(holidayList.Contains(today)){
    requestJson = json.GetValue("HolidaySetting").ToObject<JObject>();
}
else
{
    requestJson = json.GetValue("WorkingdaySetting").ToObject<JObject>();
}
requestJson.Add("RecordDate", DateTime.Now.ToString("MM/dd yyyy") + " 00:00:00");

String jsonStr =  requestJson.ToString();

var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
var result = client.PostAsync("https://smartim.kpmg.com.tw/HealthCheck/Web/SelfCheck/Create", content).Result;
Console.WriteLine(result.StatusCode);