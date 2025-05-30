export const environment = {
    production: true,
    API: 'https://localhost:7054/api',
    msalConfig: {
        auth: {
          //  clientId: 'enter-clientId',
        //  clientId: "edf4c1cb-b781-4915-948f-5bdf84db18c2",
          clientId: "d93857e0-78cc-4a43-aa14-2b373dec66f5",
          // Full directory URL, in the form of https://login.microsoftonline.com/<tenant>
          authority: "https://login.microsoftonline.com/b41b72d0-4e9f-4c26-8a69-f949f367c91d",
        //  authority: "https://login.microsoftonline.com/b41b72d0-4e9f-4c26-8a69-f949f367c91d",
         //   authority: 'enter-authority' 
        }
    },
    apiConfig: {
      //  scopes: ['api://74ba30ce-6fac-4822-9f2e-265c36261b74/wearther'],
        scopes: ['api://74ba30ce-6fac-4822-9f2e-265c36261b74/wearther'],
        uri: 'https://localhost:7054/api'
    }
};
