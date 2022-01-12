// See https://aka.ms/new-console-template for more information
using System.Text;

var client = new HttpClient();
String jsonStr = "{    \"EmpID\": \"16210\",    \"RecordDate\": \"2020/12/31\",    \"WorkPlaceAM\": \"辦公室\",    \"WorkPlacePM\": \"辦公室\",    \"WorkProject\": \"顧問專案\",    \"Symptom\": \"false\",    \"Seat\": \"固定座位\",    \"SeatNo\": \"\"}";
var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
var result = client.PostAsync("https://smartim.kpmg.com.tw/HealthCheck/Web/SelfCheck/Create", content).Result;
Console.WriteLine(result.StatusCode);