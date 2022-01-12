// See https://aka.ms/new-console-template for more information
using System.Text;

var client = new HttpClient();

int dayOfWeek = (int)DateTime.Now.DayOfWeek;
String jsonStr;
if (dayOfWeek < 6)
{
    jsonStr = "{    \"EmpID\": \"16210\",\"RecordDate\": \"" + DateTime.Now.ToString("MM/dd yyyy") + " 00:00:00\",\"WorkPlaceAM\": \"辦公室\",\"WorkPlacePM\": \"辦公室\",\"WorkProject\": \"顧問專案\",\"Symptom\": \"false\",\"Seat\": \"固定座位\",\"SeatNo\": \"\"}";
}
else
{
    jsonStr = "{    \"EmpID\": \"16210\",\"RecordDate\": \"" + DateTime.Now.ToString("MM/dd yyyy") + " 00:00:00\",\"WorkPlaceAM\": \"住家\",\"WorkPlacePM\": \"住家\",\"WorkProject\": \"休/例假\",\"Symptom\": \"false\"}";
}
var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
var result = client.PostAsync("https://smartim.kpmg.com.tw/HealthCheck/Web/SelfCheck/Create", content).Result;
Console.WriteLine(result.StatusCode);