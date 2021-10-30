```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

Sources sources = new Sources(client);

HttpResponseMessage result = await sources.EmailSources("b.mohamed@tomba.io");
```