```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Usage usage = new Usage(client);

HttpResponseMessage result = await usage.GetUsage();
```