<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Simon_Reynolds_Technical_Test_v2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simon Reynolds Technical Task</title>
</head>
<body>
    <form id="Form1" runat="server" class="container">
        <div id="divGrid" runat="server">
            <asp:ListView ID="lvCustomerDetails" runat="server" OnItemCommand="lvCustomerDetails_ItemCommand" Style="width: 550px">
                <LayoutTemplate runat="server">
                    <table style="border: 0; padding: 0px,0px,0px,1px">
                        <tr style="background-color: #E5E5FE">
                            <th style="width: 150px">Customer Name</th>
                            <th style="width: 100px">Age</th>
                            <th style="width: 100px">Post Code</th>
                            <th style="width: 100px">Height</th>
                            <th style="width: 100px">Edit</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder">
                        </tr>

                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <table style="border: 0; padding: 0px,0px,0px,1px">

                        <tr>
                            <td style="width: 150px; text-align: center">
                                <%# Eval("Name") %>
                            </td>
                            <td style="width: 100px; text-align: center">
                                <%# Eval("Age") %>
                            </td>
                            <td style="width: 100px; text-align: center">
                                <%# Eval("PostCode") %>
                            </td>
                            <td style="width: 100px; text-align: center">
                                <%# Eval("Height") %>
                            </td>
                            <td style="width: 100px; text-align: center">
                                <asp:Button runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Container.DataItemIndex %>' /></td>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>

            </asp:ListView>

            <asp:Button ID="btnAdd" Text="Add New Customer" runat="server" OnClick="btnAdd_Click" />
            <br />
            <br />
            <div id="divEditPanel" runat="server" visible="false" style="border: solid" width="550px">
                <table>
                    <tr>
                        <td>Customer Name</td>
                        <td>
                            <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Age</td>
                        <td>
                            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Post Code</td>
                        <td>
                            <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Height</td>
                        <td>
                            <asp:TextBox ID="txtHeight" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" runat="server" /></td>
                        <td>
                            <asp:Button ID="btnSubmitAdd" Text="Add" OnClick="btnSubmitAdd_Click" Enabled="false" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>

    <script>

        //javavascript validation
        document.getElementById("Form1").addEventListener("input", function () {
            var name = document.getElementById("txtCustomerName").value.trim();
            var age = document.getElementById("txtAge").value.trim();
            var postCode = document.getElementById("txtPostCode").value.trim();
            var height = document.getElementById("txtHeight").value.trim();

            const heightValue = parseFloat(height.value);

            if (name !== "" && age !== "" && !isNaN(age) && age < 110 && postCode !== "" && height !== "" && !isNaN(height)) {
                document.getElementById("btnSubmitAdd").disabled = false;

            } else {
                document.getElementById("btnSubmitAdd").disabled = true;

            }


        });

    </script>
</body>
</html>
