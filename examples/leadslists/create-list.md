```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

LeadsLists leadsLists = new LeadsLists(client);

HttpResponseMessage result = await leadsLists.CreateList();
```