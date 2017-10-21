<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaMenu.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class ="container">

            <div class ="page-header">
            <h1>Pizza Menu</h1>
            <p class ="lead">P ZA 4 U</p>
            </div>

            
            <div class="form-group">
                <label>Size: </label>
                <asp:DropDownList ID="sizedrpdwnlst" runat="server" CssClass="form-control" Autopostback ="true" OnSelectedIndexChanged="recalculateTotalCost">
                    <asp:ListItem Text="Choose One..." Value ="" Selected="True" />
                    <asp:ListItem Text="Small (12 inch - $12)" Value="Small" />
                    <asp:ListItem Text="Medium (14 inch - $14)" Value="Medium" />
                    <asp:ListItem Text="Large (16 inch - $16)" Value="Large" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Crust: </label>
                <asp:DropDownList ID="crustdrpdwnlst" runat="server" CssClass="form-control" Autopostback ="true" OnSelectedIndexChanged="recalculateTotalCost">
                    <asp:ListItem Text="Choose One..." Value ="" Selected="True" />
                    <asp:ListItem Text="Regular" Value="Regular" />
                    <asp:ListItem Text="Thin" Value="Thin" />
                    <asp:ListItem Text="Thick (+ $2)" Value="Thick" />

                </asp:DropDownList>
            </div>

            <div class="checkbox"><label><asp:CheckBox ID="sausagechkbx" runat="server" Autopostback ="true" OnCheckedChanged ="recalculateTotalCost" /> Sausage</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="pepperonichkbx" runat="server" Autopostback ="true" OnCheckedChanged ="recalculateTotalCost" /> Pepperoni</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="onionschkbx" runat="server" Autopostback ="true" OnCheckedChanged ="recalculateTotalCost" /> Onions</label></div>
            <div class="checkbox"><label><asp:CheckBox ID="greenpepperschkbx" runat="server" Autopostback ="true" OnCheckedChanged ="recalculateTotalCost" /> Green Peppers</label></div>

            <h3>Deliver to:</h3>

            <div class="form-group">
                <label>Name:</label>
                <asp:TextBox ID="nametxtbx" runat="server" CssClass="form-control" Autopostback ="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Address:</label>
                <asp:TextBox ID="addresstxtbx" runat="server" CssClass="form-control" Autopostback ="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>ZIP Code:</label>
                <asp:TextBox ID="ziptxtbx" runat="server" CssClass="form-control" Autopostback ="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Phone Number:</label>
                <asp:TextBox ID="phonetxtbx" runat="server" CssClass="form-control" Autopostback ="true"></asp:TextBox>
            </div>
            
            
            <h3>Payment:</h3>

            <div class="radio"><label><asp:RadioButton ID="cashradiobtn" runat="server" GroupName="PaymentGroup" Checked ="true"/> Cash</label></div>
            <div class="radio"><label><asp:RadioButton ID="creditradiobtn" runat="server" GroupName="PaymentGroup" /> Credit</label></div>

            <asp:Button ID="orderbtn" runat="server" Text="Order" CssClass="btn btn-large btn-primary" OnClick="orderbtn_Click"/>
            <asp:Label ID="validationlbl" runat="server" Text="" CssClass ="bg-danger" Visible ="false"></asp:Label>
            <h3>Total Cost:<asp:Label ID="totallbl" runat="server" Text=""></asp:Label></h3>


            <p>&nbsp;</p>
            <p>&nbsp;</p>

        </div>
    </form>
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
