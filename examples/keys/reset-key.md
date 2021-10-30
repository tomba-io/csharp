```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Keys keys = new Keys(client);

HttpResponseMessage result = await keys.ResetKey("");
```