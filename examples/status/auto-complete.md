```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Status status = new Status(client);

HttpResponseMessage result = await status.AutoComplete("google");
```