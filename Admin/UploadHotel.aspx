<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadHotel.aspx.cs" ValidateRequest="false" Inherits="UploadHotel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="border: 1px solid #224472; border-radius: 5px 5px 5px 5px;width:350px;height:220px;padding:10px;">
     <div style="padding:10px;font-size:16px;font-weight:bold;text-align:center">Upload Hotel</div>
    <hr />
      <table>
 <tr><td colspan="2">Import file from Microsoft Office Excel CSV (Comma Separated Values) File
 <br />File Format : <a href="../CSVLoad/Hotels.csv">Download </a>
  </td></tr>
        <tr  ><td style="width:100px;text-align:right;padding-right:20px;    " > 
            File Path</td>
        <td >
             <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
 
                                 
        </tr>
        
        <tr  ><td style="width:100px;text-align:right;padding-right:20px;    " > 
            &nbsp;</td>
        <td >
             <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </td>
 
                                 
        </tr>
        
        <tr><td colspan="2" >&nbsp;</td></tr>
        <tr><td ></td><td>
            <asp:Button ID="BtnExport" runat="server" Text="Upload Data" Width ="100px" 
                onclick="BtnExport_Click" /></td></tr>
        </table>

</table>
    </div>
    </form>
</body>
</html>
