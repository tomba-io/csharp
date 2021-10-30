```cs
using Tomba;

Client client = new Client();

client
  .SetKey("ta_xxxx") // Your Key
  .SetSecret("ts_xxxx") // Your Secret
;

LeadsAttributes leadsAttributes = new LeadsAttributes(client);

HttpResponseMessage result = await leadsAttributes.UpdateLeadAttribute("[Lead_Attributes_ID]");
```