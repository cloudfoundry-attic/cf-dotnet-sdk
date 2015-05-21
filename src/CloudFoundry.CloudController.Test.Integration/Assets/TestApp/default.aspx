<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <pre>
          <% foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
             { %>
            <%= de.Key %> = <%= de.Value %><br />
          <% } %>
        </pre>
    </div>
    </form>
</body>
</html>
