```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Count count = new Count(client);

HttpResponseMessage result = await count.EmailCount("tomba.io");
```