HttpClient httpClient = new HttpClient();
string requestURL = $"https://api.openweathermap.org/data/2.5/weather?lat={51.5074}&lon={-0.1278}&appid={"33afe64195d2a19c92588b64b1cd2a49"}";
HttpResponseMessage response = await httpClient.GetAsync(requestURL);
if (response.IsSuccessStatusCode)
{
    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
}
else
{
    Console.WriteLine($"Lỗi: {response.StatusCode}");
}