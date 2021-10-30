```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Logs logs = new Logs(client);

HttpResponseMessage result = await logs.GetLogs();
```